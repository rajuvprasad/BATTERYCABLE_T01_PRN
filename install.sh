#!/usr/bin/env bash
#
# install.sh - Build and install "Battery Cable EOL Tester V2.0" on a client PC.
#
# Target: Windows 10/11, run from Git Bash (or MSYS2) in an *elevated* shell
#         ("Run as administrator"), from the repository root.
#
# What it does:
#   1. Verifies prerequisites (.NET Framework 4.8, MSBuild, 32-bit ACE OLEDB 12.0,
#      ADLINK PCIS-DASK driver).
#   2. Builds the solution in Release configuration.
#   3. Copies the application into the install directory (an existing CLT.accdb
#      database is kept, never overwritten).
#   4. Copies the user manual to D:\Manual (path hard-coded in the app) and
#      creates D:\PartImage.
#   5. Grants the local Users group write access to the install directory (the
#      app writes the database and label print files next to the exe).
#   6. Creates Desktop and Start Menu shortcuts.
#
# Usage:
#   ./install.sh [--install-dir <windows path>] [--skip-build] [--build-only]
#                [--no-shortcuts] [--help]

set -euo pipefail

APP_NAME="Battery Cable EOL Tester V2.0"
MANUFACTURER="Iracrat Technologies"
EXE_NAME="Battery Cable EOL (V2).exe"
DB_NAME="CLT.accdb"

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
SOLUTION="$SCRIPT_DIR/Battery Cable EOL (V2).sln"
PROJECT_DIR="$SCRIPT_DIR/Cable Line Test"
BUILD_DIR="$PROJECT_DIR/bin/Release"

INSTALL_DIR_WIN=""
SKIP_BUILD=0
BUILD_ONLY=0
SHORTCUTS=1

ADLINK_DLL_CANDIDATES=(
    "/c/ADLINK/PCIS-DASK/Lib/PCI-Dask.dll"
    "/c/Windows/SysWOW64/PCI-Dask.dll"
    "/c/Windows/System32/PCI-Dask.dll"
)

# ---------------------------------------------------------------------------
# Helpers
# ---------------------------------------------------------------------------
info()  { printf '\033[1;34m[INFO]\033[0m  %s\n' "$*"; }
ok()    { printf '\033[1;32m[ OK ]\033[0m  %s\n' "$*"; }
warn()  { printf '\033[1;33m[WARN]\033[0m  %s\n' "$*" >&2; }
die()   { printf '\033[1;31m[FAIL]\033[0m  %s\n' "$*" >&2; exit 1; }

usage() {
    sed -n '2,22p' "${BASH_SOURCE[0]}" | sed 's/^# \{0,1\}//'
    exit 0
}

# Run a PowerShell snippet (Windows PowerShell 5.1, always present on Win10/11).
ps() { powershell.exe -NoProfile -NonInteractive -ExecutionPolicy Bypass -Command "$1" | tr -d '\r'; }

# Same, but in the 32-bit PowerShell host (the app runs as a 32-bit process).
ps32() {
    local ps32_exe="/c/Windows/SysWOW64/WindowsPowerShell/v1.0/powershell.exe"
    [[ -x "$ps32_exe" ]] || ps32_exe="powershell.exe"
    "$ps32_exe" -NoProfile -NonInteractive -ExecutionPolicy Bypass -Command "$1" | tr -d '\r'
}

to_unix() { cygpath -u "$1"; }
to_win()  { cygpath -w "$1"; }

# ---------------------------------------------------------------------------
# Arguments
# ---------------------------------------------------------------------------
while [[ $# -gt 0 ]]; do
    case "$1" in
        --install-dir)  INSTALL_DIR_WIN="${2:?--install-dir needs a value}"; shift 2 ;;
        --skip-build)   SKIP_BUILD=1; shift ;;
        --build-only)   BUILD_ONLY=1; shift ;;
        --no-shortcuts) SHORTCUTS=0; shift ;;
        -h|--help)      usage ;;
        *)              die "Unknown option: $1 (see --help)" ;;
    esac
done

# ---------------------------------------------------------------------------
# Environment checks
# ---------------------------------------------------------------------------
case "$(uname -s)" in
    MINGW*|MSYS*|CYGWIN*) ;;
    *) die "This is a Windows (.NET Framework WinForms) application. Run this script from Git Bash on Windows." ;;
esac

command -v cygpath >/dev/null        || die "cygpath not found - please run from Git Bash."
command -v powershell.exe >/dev/null || die "powershell.exe not found on PATH."
[[ -f "$SOLUTION" ]]                 || die "Solution not found: $SOLUTION (run from the repository root)."

if [[ $BUILD_ONLY -eq 0 ]]; then
    net session >/dev/null 2>&1 || die "Administrator rights required. Re-open Git Bash with 'Run as administrator'."
fi

if [[ -z "$INSTALL_DIR_WIN" ]]; then
    PF86="$(ps '[Environment]::GetFolderPath("ProgramFilesX86")')"
    INSTALL_DIR_WIN="$PF86\\$MANUFACTURER\\$APP_NAME"
fi
INSTALL_DIR="$(to_unix "$INSTALL_DIR_WIN")"

# ---------------------------------------------------------------------------
# 1. Prerequisites
# ---------------------------------------------------------------------------
info "Checking prerequisites..."

# .NET Framework 4.8 runtime (Release >= 528040)
NET_RELEASE="$(ps '(Get-ItemProperty "HKLM:\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full" -ErrorAction SilentlyContinue).Release')"
if [[ -n "$NET_RELEASE" && "$NET_RELEASE" -ge 528040 ]]; then
    ok ".NET Framework 4.8 runtime present (release $NET_RELEASE)"
else
    die ".NET Framework 4.8 is not installed. Install it from https://dotnet.microsoft.com/download/dotnet-framework/net48 and re-run."
fi

# MSBuild (needed unless --skip-build)
MSBUILD=""
if [[ $SKIP_BUILD -eq 0 ]]; then
    VSWHERE="/c/Program Files (x86)/Microsoft Visual Studio/Installer/vswhere.exe"
    if [[ -x "$VSWHERE" ]]; then
        found="$("$VSWHERE" -latest -products '*' -requires Microsoft.Component.MSBuild \
                  -find 'MSBuild\**\Bin\MSBuild.exe' 2>/dev/null | tr -d '\r' | head -n1)"
        [[ -n "$found" ]] && MSBUILD="$(to_unix "$found")"
    fi
    if [[ -z "$MSBUILD" ]] && command -v msbuild.exe >/dev/null; then
        MSBUILD="$(command -v msbuild.exe)"
    fi
    [[ -n "$MSBUILD" ]] || die "MSBuild not found. Install 'Build Tools for Visual Studio' (workload: .NET desktop build tools, incl. .NET Framework 4.8 targeting pack), or use --skip-build with a prebuilt bin/Release."
    ok "MSBuild: $(to_win "$MSBUILD")"

    [[ -d "/c/Program Files (x86)/Reference Assemblies/Microsoft/Framework/.NETFramework/v4.8" ]] \
        || die ".NET Framework 4.8 Developer/Targeting Pack missing. Install it from https://dotnet.microsoft.com/download/dotnet-framework/net48 (Developer Pack)."
    ok ".NET Framework 4.8 targeting pack present"
fi

if [[ $BUILD_ONLY -eq 0 ]]; then
    # Microsoft ACE OLEDB 12.0 - must be the 32-bit provider (app is AnyCPU / Prefer32Bit).
    if ps32 '[bool]((New-Object System.Data.OleDb.OleDbEnumerator).GetElements() | Where-Object { $_.SOURCES_NAME -eq "Microsoft.ACE.OLEDB.12.0" })' | grep -qi true; then
        ok "Microsoft.ACE.OLEDB.12.0 (32-bit) provider present"
    else
        warn "Microsoft.ACE.OLEDB.12.0 (32-bit) is NOT registered. The app cannot open $DB_NAME without it."
        warn "Install the 32-bit 'Microsoft Access Database Engine 2010/2016 Redistributable' (AccessDatabaseEngine.exe)."
    fi

    # ADLINK PCIS-DASK driver DLL (32-bit)
    DASK_DLL=""
    for c in "${ADLINK_DLL_CANDIDATES[@]}"; do
        if [[ -f "$c" ]]; then DASK_DLL="$c"; break; fi
    done
    if [[ -n "$DASK_DLL" ]]; then
        ok "ADLINK PCI-Dask.dll: $(to_win "$DASK_DLL")"
    else
        warn "PCI-Dask.dll not found. Install the ADLINK PCIS-DASK driver for the DAQ card; hardware tests will fail until then."
    fi
fi

# ---------------------------------------------------------------------------
# 2. Build
# ---------------------------------------------------------------------------
if [[ $SKIP_BUILD -eq 0 ]]; then
    info "Building solution (Release)..."
    "$MSBUILD" "$(to_win "$SOLUTION")" -nologo -verbosity:minimal -m \
        -t:Rebuild -p:Configuration=Release -p:Platform="Any CPU" \
        || die "Build failed."
    ok "Build succeeded"
fi

[[ -f "$BUILD_DIR/$EXE_NAME" ]] || die "Build output not found: $(to_win "$BUILD_DIR/$EXE_NAME")"

if [[ $BUILD_ONLY -eq 1 ]]; then
    ok "Build-only mode: output is in $(to_win "$BUILD_DIR")"
    exit 0
fi

# ---------------------------------------------------------------------------
# 3. Install application files
# ---------------------------------------------------------------------------
info "Installing to $INSTALL_DIR_WIN"

# Stop a running instance so its files can be replaced.
ps "Get-Process | Where-Object { \$_.Path -eq '$(to_win "$INSTALL_DIR/$EXE_NAME")' } | Stop-Process -Force" || true

mkdir -p "$INSTALL_DIR"

cp -f "$BUILD_DIR/$EXE_NAME"        "$INSTALL_DIR/"
cp -f "$BUILD_DIR/$EXE_NAME.config" "$INSTALL_DIR/"
cp -f "$BUILD_DIR/BarcodePrintFileNames.txt" "$INSTALL_DIR/"
cp -f "$PROJECT_DIR/Icon1.ico"      "$INSTALL_DIR/"
# Label print templates (*.prn) referenced by BarcodePrintFileNames.txt, if any ship with the build.
find "$BUILD_DIR" -maxdepth 1 -name '*.prn' -exec cp -f {} "$INSTALL_DIR/" \;

# Keep the production database on upgrades; back it up first.
if [[ -f "$INSTALL_DIR/$DB_NAME" ]]; then
    backup="$INSTALL_DIR/$DB_NAME.bak.$(date +%Y%m%d%H%M%S)"
    cp -f "$INSTALL_DIR/$DB_NAME" "$backup"
    ok "Existing database kept (backup: $(basename "$backup"))"
else
    cp -f "$BUILD_DIR/$DB_NAME" "$INSTALL_DIR/"
    ok "Fresh database installed"
fi

if [[ -n "${DASK_DLL:-}" ]]; then
    cp -f "$DASK_DLL" "$INSTALL_DIR/PCI-Dask.dll"
fi
ok "Application files copied"

# ---------------------------------------------------------------------------
# 4. Hard-coded data folders used by the app (D:\Manual, D:\PartImage)
# ---------------------------------------------------------------------------
if [[ -d "/d" ]]; then
    mkdir -p "/d/Manual" "/d/PartImage"
    cp -f "$PROJECT_DIR/Resources/usermanual.pdf" "/d/Manual/usermanual.pdf"
    ok "User manual copied to D:\\Manual, D:\\PartImage created"
else
    warn "Drive D: not present - the in-app 'User Manual' menu (D:\\Manual\\usermanual.pdf) will not work."
fi

# ---------------------------------------------------------------------------
# 5. Permissions - the app writes CLT.accdb and .prn files next to the exe
# ---------------------------------------------------------------------------
icacls "$INSTALL_DIR_WIN" //grant '*S-1-5-32-545:(OI)(CI)M' //T //Q >/dev/null \
    && ok "Users group granted modify rights on install directory" \
    || warn "Could not set permissions on $INSTALL_DIR_WIN"

# ---------------------------------------------------------------------------
# 6. Shortcuts
# ---------------------------------------------------------------------------
if [[ $SHORTCUTS -eq 1 ]]; then
    TARGET_WIN="$(to_win "$INSTALL_DIR/$EXE_NAME")"
    ICON_WIN="$(to_win "$INSTALL_DIR/Icon1.ico")"
    ps "
        \$ws = New-Object -ComObject WScript.Shell
        foreach (\$dir in @([Environment]::GetFolderPath('CommonDesktopDirectory'),
                            [Environment]::GetFolderPath('CommonPrograms'))) {
            \$lnk = \$ws.CreateShortcut((Join-Path \$dir '$APP_NAME.lnk'))
            \$lnk.TargetPath       = '$TARGET_WIN'
            \$lnk.WorkingDirectory = '$INSTALL_DIR_WIN'
            \$lnk.IconLocation     = '$ICON_WIN'
            \$lnk.Save()
        }"
    ok "Desktop and Start Menu shortcuts created"
fi

echo
ok "$APP_NAME installed successfully."
info "Launch it from the Desktop shortcut or: \"$(to_win "$INSTALL_DIR/$EXE_NAME")\""
