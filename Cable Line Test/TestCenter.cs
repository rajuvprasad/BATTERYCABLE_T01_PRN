using Cable_Line_Test.Resources;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cable_Line_Test
{
    public partial class TestCenter : Form
    {
        private bool blink;
        private string barcodePrintFileName = string.Empty;
        private string machineID = string.Empty;
        private bool startingNGCableValidated = false;
        private bool startingNGCableValidation = false;
        private bool endingNGCableValidated = false;
        private bool endingNGCableValidation = false;
        private ushort card;
        private int baseValue = 2;
        private UInt32 digitalOutputValue;
        private int bitsConnected = 0;
        private int failCounter = 0;
        private int passCounter = 0;
        private List<UInt32> powerValues = new List<UInt32>();
        private List<UInt16> bitsToCheck = new List<UInt16>();
        private List<UInt16> bitsToCheckNGMaster = new List<UInt16>();
        private List<UInt16> bitsToCheckLineTest = new List<UInt16>();
        private UInt16[] powers;
        private string lotNo = string.Empty;
        private string traceabilityCode = string.Empty;
        // Single timestamp per test so the traceability code date, RECORD_DATE and the running serial day always agree (even across midnight)
        private DateTime testDateTime;
        private System.Media.SoundPlayer player;
        private bool breakLoop = false;
        private bool firstTime;

        private Stopwatch sw = new Stopwatch();
        private Int32 alcInput_TimeInterval = 200;
        private Stopwatch releasePin_sw = new Stopwatch();
        private Int32 releasePin_TimeInterval = 10000;

        private void FirstCharacterEntered()
        {
            sw.Start();
        }

        public TestCenter()
        {
            InitializeComponent();
            statusStrip1.Padding = new Padding(statusStrip1.Padding.Left, statusStrip1.Padding.Top, statusStrip1.Padding.Left, statusStrip1.Padding.Bottom);
        }

        private void TestCenter_Load(object sender, EventArgs e)
        {
            card = (ushort)DASK.Register_Card(DASK.PCI_7432, 0);
            player = new System.Media.SoundPlayer();

            var configSettings = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configSettings.AppSettings.Settings;

            if (settings["MACHINE_ID"] != null)
            {
                lbl_MacId.Text = settings["MACHINE_ID"].Value;
                machineID = settings["MACHINE_ID"].Value;
            }

            txt_ALC.Focus();
        }

        private void resizePictureBoxImage(PictureBox pictureBox)
        {
            var imageSize = pictureBox.Image.Size;
            var fitSize = pictureBox.ClientSize;
            pictureBox.SizeMode = imageSize.Width > fitSize.Width || imageSize.Height > fitSize.Height ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage;
        }

        private void txt_ALC_TextChanged(object sender, EventArgs e)
        {
            if (txt_ALC.Text.Trim().Length == 1)
                FirstCharacterEntered();
            else if (txt_ALC.Text.Trim().Length == 4)
            {
                sw.Stop();
                if (sw.ElapsedMilliseconds < alcInput_TimeInterval)
                {
                    //Input is from the BarCode Scanner
                    txt_ALC.ReadOnly = true;

                    bool isPartExists = false;
                    barcodePrintFileName = string.Empty;

                    using (OleDbConnection dbCon = new OleDbConnection(Properties.Settings.Default.CLTConnectionString))
                    using (var cmd = dbCon.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM PART_DETAILS WHERE ALC = @alcCode AND IS_ACTIVE = @isActive";
                        cmd.Parameters.AddWithValue("alcCode", txt_ALC.Text);
                        cmd.Parameters.AddWithValue("isActive", true);
                        dbCon.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            txt_CarMaker.Text = reader["CAR_MAKER"].ToString();
                            txt_PartName.Text = reader["PART_NAME"].ToString();
                            txt_PartNumber.Text = reader["PART_NUMBER"].ToString();
                            txt_ATMT.Text = reader["TRANSMISSION"].ToString();
                            txt_CarModel.Text = reader["CAR_MODEL"].ToString();
                            txt_Engine.Text = reader["ENGINE"].ToString();
                            txt_Variant.Text = reader["VARIANT"].ToString();
                            string imagePath = reader["IMAGE_PATH"].ToString();
                            if (imagePath.Length > 0)
                            {
                                pictureBox_PartImage.Image = Image.FromFile(imagePath);
                                resizePictureBoxImage(pictureBox_PartImage);
                            }
                            barcodePrintFileName = reader["BARCODE_PRN_FILE_NAME"].ToString();

                            isPartExists = true;
                        }
                    }

                    if (isPartExists)
                    {
                        using (OleDbConnection dbCon = new OleDbConnection(Properties.Settings.Default.CLTConnectionString))
                        {
                            dbCon.Open();
                            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM DIGITAL_IO_LINE_DETAILS WHERE DILD_PART_NUMBER = '" + txt_PartNumber.Text + "' ORDER BY SL_NO", dbCon);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dGV_DIO_Line_Details_Test.AutoGenerateColumns = false;
                            dGV_DIO_Line_Details_Test.DataSource = dataTable;
                            dGV_DIO_Line_Details_Test.ClearSelection();
                        }

                        display_Data();

                        foreach (DataGridViewRow row in dGV_DIO_Line_Details_Test.Rows)
                        {
                            string val = row.Cells["LINE"].Value.ToString();
                            if (!val.Equals("99"))
                            {
                                bitsToCheckLineTest.Add(Convert.ToUInt16(row.Index));
                                if (!val.StartsWith("R"))
                                {
                                    bitsToCheckNGMaster.Add(Convert.ToUInt16(row.Index));
                                }
                            }
                        }

                        btn_Next.Enabled = true;
                        lbl_Status_Text.Text = "START";
                        lbl_Status_Text.BackColor = Color.Lime;
                        txt_Message_Text.Text = Constants.Messages.Connect_NG_Master;
                        startingNGCableValidation = true;
                        start_CheckAsync();
                    }
                    else
                    {
                        // Show a message box saying part does not exist in database...
                        MessageBox.Show("Scanned Part Does NOT Exist...");
                        lbl_Status_Text.Text = "READY";
                        lbl_Status_Text.BackColor = Color.Yellow;
                        txt_Message_Text.Text = Constants.Messages.System_Ready;
                        txt_ALC.Text = "";
                        txt_ALC.ReadOnly = false;
                        txt_ALC.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Manual Input is not allowed. Please use Barcode Scanner.");
                    txt_ALC.Text = "";
                    txt_ALC.Focus();
                }
                sw.Reset();
            }
            else
            {
                Console.WriteLine("Do Nothing...");
            }
        }

        private void display_Data()
        {
            dGV_Data.DataSource = null;
            using (OleDbConnection dbCon = new OleDbConnection(Properties.Settings.Default.CLTConnectionString))
            {
                dbCon.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM TESTING_DATA WHERE RECORD_DATE >= #" + DateTime.Today.ToShortDateString() + "# AND RECORD_DATE <= #" + DateTime.Today.ToShortDateString() + "# AND PARTDETAILS_PART_NUMBER = '" + txt_PartNumber.Text + "' ORDER BY ID DESC", dbCon);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dGV_Data.AutoGenerateColumns = false;
                dGV_Data.DataSource = dataTable;
                dGV_Data.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                dGV_Data.ClearSelection();
            }

            int i = dGV_Data.Rows.Count;

            if (i > 0)
            {
                int okRecords = 0;
                txt_Total.Text = i.ToString();

                foreach (DataGridViewRow row in dGV_Data.Rows)
                {
                    row.Cells["SlNo"].Value = i--;
                    if (row.Cells["OVERALL_STATUS"].Value.ToString() == "OK")
                        okRecords++;
                }

                txt_OK.Text = okRecords.ToString();
                txt_NG.Text = (Int32.Parse(txt_Total.Text) - okRecords).ToString();
                txt_PPM.Text = ((Int32.Parse(txt_NG.Text) * 1000000) / Int32.Parse(txt_Total.Text)).ToString();
            }
            else
            {
                txt_Total.Text = "0";
                txt_OK.Text = "0";
                txt_NG.Text = "0";
                txt_PPM.Text = "0";
            }
            dGV_Data.Refresh();
        }

        private async void start_CheckAsync()
        {
            if (startingNGCableValidation || endingNGCableValidation)
                bitsToCheck = bitsToCheckNGMaster;
            else
                bitsToCheck = bitsToCheckLineTest;

            powers = bitsToCheck.ToArray();

            powerValues.Clear();
            foreach (UInt32 power in powers)
                powerValues.Add((UInt32)Math.Pow(baseValue, power));

            // to avoid flicker
            digitalOutputValue = (UInt32)Math.Pow(baseValue, 24) - 1;
            DASK.DO_WritePort(card, 0, digitalOutputValue);
            await Task.Delay(300);
            DASK.DO_WritePort(card, 0, 0);

            do
            {
                bitsConnected = 0;
                failCounter = 0;
                passCounter = 0;
                for (int i = 0; i < powers.Length; i++)
                {
                    digitalOutputValue = (UInt32)Math.Pow(baseValue, powers[i]);

                    DASK.DO_WritePort(card, 0, digitalOutputValue);
                    await Task.Delay(100);
                    DASK.DI_ReadPort(card, 0, out uint digitalInputValue);

                    if (powerValues.Contains(digitalInputValue))
                    {
                        bitsConnected++;
                        if (digitalOutputValue != digitalInputValue)
                        {
                            dGV_DIO_Line_Details_Test.Rows[powers[i]].Cells["STATUS"].Value = Constants.LineStatus.Changed;
                            dGV_DIO_Line_Details_Test.Rows[powers[i]].DefaultCellStyle.BackColor = Color.OrangeRed;
                            failCounter++;
                        }
                        else
                        {
                            dGV_DIO_Line_Details_Test.Rows[powers[i]].Cells["STATUS"].Value = Constants.LineStatus.Pass;
                            dGV_DIO_Line_Details_Test.Rows[powers[i]].DefaultCellStyle.BackColor = Color.Lime;
                            passCounter++;
                        }
                    }
                    else
                    {
                        dGV_DIO_Line_Details_Test.Rows[powers[i]].Cells["STATUS"].Value = Constants.LineStatus.Open;
                        dGV_DIO_Line_Details_Test.Rows[powers[i]].DefaultCellStyle.BackColor = dGV_DIO_Line_Details_Test.DefaultCellStyle.BackColor;
                    }
                }
                if (breakLoop)
                {
                    break;
                }
            } while (bitsConnected != bitsToCheck.Count);

            if (!breakLoop)
            {
                if (startingNGCableValidation)
                {
                    if (failCounter == bitsToCheck.Count)
                    {
                        lbl_Status_Text.Text = "NG PASS";
                        lbl_Status_Text.BackColor = Color.Lime;
                        txt_Message_Text.Text = Constants.Messages.NG_Master_Pass;
                        startingNGCableValidated = true;
                        player.Stream = Properties.Sounds.pass;
                        player.Play();
                    }
                    else
                    {
                        lbl_Status_Text.Text = "NG FAIL";
                        lbl_Status_Text.BackColor = Color.OrangeRed;
                        txt_Message_Text.Text = Constants.Messages.NG_Master_Fail;
                        startingNGCableValidated = false;
                        player.Stream = Properties.Sounds.beep;
                        player.Play();
                    }
                    check_CableReleasePin();
                }
                else if (endingNGCableValidation)
                {
                    if (failCounter == bitsToCheck.Count)
                    {
                        lbl_Status_Text.Text = "NG PASS";
                        lbl_Status_Text.BackColor = Color.Lime;
                        txt_Message_Text.Text = Constants.Messages.NG_Master_Pass;
                        endingNGCableValidated = true;
                        player.Stream = Properties.Sounds.pass;
                        player.Play();
                    }
                    else
                    {
                        lbl_Status_Text.Text = "NG FAIL";
                        lbl_Status_Text.BackColor = Color.OrangeRed;
                        txt_Message_Text.Text = Constants.Messages.NG_Master_Fail;
                        endingNGCableValidated = false;
                        player.Stream = Properties.Sounds.beep;
                        player.Play();
                    }
                    check_CableReleasePin();
                }
                else
                {
                    generate_LotNumber();

                    if (passCounter == bitsToCheck.Count)
                    {
                        lbl_Status_Text.Text = "PASS";
                        lbl_Status_Text.BackColor = Color.Lime;
                        txt_Message_Text.Text = Constants.Messages.Test_Cable_Pass;
                        if (!string.IsNullOrWhiteSpace(barcodePrintFileName) && !(barcodePrintFileName == "NO_BARCODE_PRINT_FILE"))
                            printBarcodeLabel();
                        save_Testing_Data();
                        player.Stream = Properties.Sounds.pass;
                        player.Play();
                        check_CableReleasePin();
                    }
                    else
                    {
                        // releasePin_sw.Stop();
                        lbl_Status_Text.Text = "FAIL";
                        lbl_Status_Text.BackColor = Color.OrangeRed;
                        txt_Message_Text.Text = Constants.Messages.Test_Cable_Fail;

                        BlinkStatus();
                        save_Testing_Data();
                        checkAsync_NGResetPin();
                    }
                }
            }
            else
            {
                breakLoop = false;
            }
        }

        // Reads today's last PASS lot number for this part from PART_RUNNING_SERIAL (0 if none yet today)
        private int getLotNumber(OleDbConnection dbCon)
        {
            using (var cmd = dbCon.CreateCommand())
            {
                cmd.CommandText = "SELECT RUNNING_LOT_NUMBER FROM PART_RUNNING_SERIAL WHERE PART_NUMBER = @partnumber AND TEST_DAY_DATE = @testDay";
                cmd.Parameters.AddWithValue("partnumber", txt_PartNumber.Text);
                cmd.Parameters.AddWithValue("testDay", GetDateAlone(testDateTime));
                object result = cmd.ExecuteScalar();
                return int.TryParse(result?.ToString(), out int lastLotNumber) ? lastLotNumber : 0;
            }
        }

        // Lot number resets daily and runs per part. Failed cables also consume a lot number in TESTING_DATA
        // (the running serial is only advanced on PASS), so skip any traceability code already used for this part today.
        private void generate_LotNumber()
        {
            testDateTime = GetDateWithoutMilliseconds(DateTime.Now);

            using (OleDbConnection dbCon = new OleDbConnection(Properties.Settings.Default.CLTConnectionString))
            {
                dbCon.Open();
                int lotNumber = getLotNumber(dbCon);
                bool traceabilityCodeExists;
                do
                {
                    lotNumber++;
                    lotNo = lotNumber.ToString("D7");
                    traceabilityCode = testDateTime.ToString("yyMMdd") + "I" + machineID.Substring(2) + "G1A" + lotNo;

                    using (var cmd = dbCon.CreateCommand())
                    {
                        cmd.CommandText = "SELECT COUNT(*) FROM TESTING_DATA WHERE PARTDETAILS_PART_NUMBER = @partnumber AND RECORD_DATE = @recordDate AND TRACEABILITY_CODE = @traceabilityCode";
                        cmd.Parameters.AddWithValue("partnumber", txt_PartNumber.Text);
                        cmd.Parameters.AddWithValue("recordDate", GetDateAlone(testDateTime));
                        cmd.Parameters.AddWithValue("traceabilityCode", traceabilityCode);
                        traceabilityCodeExists = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                } while (traceabilityCodeExists);
            }
        }

        private void save_Testing_Data()
        {
            bool isPass = lbl_Status_Text.Text.Equals("PASS");

            using (OleDbConnection dbCon = new OleDbConnection(Properties.Settings.Default.CLTConnectionString))
            {
                dbCon.Open();
                using (OleDbTransaction tx = dbCon.BeginTransaction())
                {
                    try
                    {
                        using (var cmd = dbCon.CreateCommand())
                        {
                            cmd.Transaction = tx;
                            cmd.CommandText = " INSERT INTO TESTING_DATA (MACHINE_ID, LOT_NUMBER, TRACEABILITY_CODE, RECORD_DATE, [DATETIME], OVERALL_STATUS, PARTDETAILS_PART_NUMBER) " +
                                " VALUES (@macId, @lotNumber, @traceabilityCode, @recordDate, @date, @status, @partnumber) ";
                            cmd.Parameters.AddWithValue("macId", machineID);
                            cmd.Parameters.AddWithValue("lotNumber", lotNo);
                            cmd.Parameters.AddWithValue("traceabilityCode", traceabilityCode);
                            cmd.Parameters.AddWithValue("recordDate", GetDateAlone(testDateTime));
                            cmd.Parameters.AddWithValue("date", testDateTime);
                            cmd.Parameters.AddWithValue("status", isPass ? "OK" : "NG");
                            cmd.Parameters.AddWithValue("partnumber", txt_PartNumber.Text);
                            cmd.ExecuteNonQuery();
                        }

                        // Advance the running serial for this part/day (only if PASS)
                        if (isPass)
                        {
                            int rowsUpdated;
                            using (var cmd = dbCon.CreateCommand())
                            {
                                cmd.Transaction = tx;
                                cmd.CommandText = " UPDATE PART_RUNNING_SERIAL SET TEST_DAY_LAST_DATE_TIME = @lastDateTime, TRACEABILITY_CODE = @traceabilityCode, RUNNING_LOT_NUMBER = @lotNumber " +
                                    " WHERE PART_NUMBER = @partnumber AND TEST_DAY_DATE = @testDay ";
                                cmd.Parameters.AddWithValue("lastDateTime", testDateTime);
                                cmd.Parameters.AddWithValue("traceabilityCode", traceabilityCode);
                                cmd.Parameters.AddWithValue("lotNumber", lotNo);
                                cmd.Parameters.AddWithValue("partnumber", txt_PartNumber.Text);
                                cmd.Parameters.AddWithValue("testDay", GetDateAlone(testDateTime));
                                rowsUpdated = cmd.ExecuteNonQuery();
                            }

                            if (rowsUpdated == 0)
                            {
                                using (var cmd = dbCon.CreateCommand())
                                {
                                    cmd.Transaction = tx;
                                    cmd.CommandText = " INSERT INTO PART_RUNNING_SERIAL (PART_NUMBER, TEST_DAY_DATE, TEST_DAY_LAST_DATE_TIME, TRACEABILITY_CODE, RUNNING_LOT_NUMBER) " +
                                        " VALUES (@partnumber, @testDay, @lastDateTime, @traceabilityCode, @lotNumber) ";
                                    cmd.Parameters.AddWithValue("partnumber", txt_PartNumber.Text);
                                    cmd.Parameters.AddWithValue("testDay", GetDateAlone(testDateTime));
                                    cmd.Parameters.AddWithValue("lastDateTime", testDateTime);
                                    cmd.Parameters.AddWithValue("traceabilityCode", traceabilityCode);
                                    cmd.Parameters.AddWithValue("lotNumber", lotNo);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("Error saving test data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            display_Data();
        }

        private DateTime GetDateWithoutMilliseconds(DateTime d)
        {
            return new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
        }

        private DateTime GetDateAlone(DateTime d)
        {
            return new DateTime(d.Year, d.Month, d.Day);
        }

        private async void BlinkStatus()
        {
            blink = true;
            player.Stream = Properties.Sounds.beep;
            do
            {
                player.Play();
                lbl_Status_Text.BackColor = lbl_Status_Text.BackColor == Color.Lime ? Color.OrangeRed : Color.Lime;
                lbl_Status_Text.Text = lbl_Status_Text.Text == "CHANGED" ? string.Empty : "CHANGED";
                //lbl_Status_Text.Text = lbl_Status_Text.Text == Constants.TestStatus.Changed ? Constants.TestStatus.Start : Constants.TestStatus.Changed;
                //txt_Message_Text.BackColor = txt_Message_Text.BackColor == Color.White ? Color.SkyBlue : Color.White;
                await Task.Delay(300);
            } while (blink);
        }

        // Method to check if the battery cable is removed from the gig (signal coming at pin 24)
        // This method will be called when NG cable pass/fail and Test cable pass
        private async void check_CableReleasePin()
        {
            // Time delay of 12 secs between cable releases
            if (!startingNGCableValidation && !endingNGCableValidation)
            {
                if (!firstTime)
                {
                    do
                    {
                        await Task.Delay(50);
                    } while (releasePin_sw.ElapsedMilliseconds < releasePin_TimeInterval);
                }
                firstTime = false;
            }

            bool pinState = false;
            DASK.DO_WriteLine(card, 0, 24, 1);
            do
            {
                DASK.DI_ReadLine(card, 0, 24, out ushort state);
                pinState = Convert.ToBoolean(state);
                await Task.Delay(50);
            } while (!pinState);

            if (pinState)
            {
                if (startingNGCableValidation)
                {
                    lbl_Status_Text.Text = "START";
                    lbl_Status_Text.BackColor = Color.Lime;
                    if (startingNGCableValidated)
                    {
                        startingNGCableValidation = false;
                        startingNGCableValidated = false;
                        txt_Message_Text.Text = Constants.Messages.Connect_Test_Cable;
                        firstTime = true;
                        if (!releasePin_sw.IsRunning)
                            releasePin_sw.Start();
                        else
                            releasePin_sw.Restart();
                    }
                    else
                    {
                        txt_Message_Text.Text = Constants.Messages.Connect_NG_Master;
                    }
                    start_CheckAsync();
                }
                else if (endingNGCableValidation)
                {
                    if (endingNGCableValidated)
                    {
                        endingNGCableValidation = false;
                        endingNGCableValidated = false;
                        clearForm_WaitForBarcodeScan();
                    }
                    else
                    {
                        lbl_Status_Text.Text = "START";
                        lbl_Status_Text.BackColor = Color.Lime;
                        txt_Message_Text.Text = Constants.Messages.Connect_NG_Master;
                        start_CheckAsync();
                    }
                }
                else
                {
                    lbl_Status_Text.Text = "START";
                    lbl_Status_Text.BackColor = Color.Lime;
                    txt_Message_Text.Text = Constants.Messages.Connect_Test_Cable;
                    // await Task.Delay(10000);
                    releasePin_sw.Restart();
                    start_CheckAsync();
                }
            }
            else
            {
                Console.WriteLine("check_CableReleasePin: This log message should never be displayed...");
            }
        }

        // Method to check if the failed battery cable is placed in the bin (signal coming at pin 25)
        // This method will be called when Test cable fail
        private async void checkAsync_NGResetPin()
        {
            bool pinState = false;
            DASK.DO_WriteLine(card, 0, 25, 1);
            do
            {
                DASK.DI_ReadLine(card, 0, 25, out ushort state);
                pinState = Convert.ToBoolean(state);
                await Task.Delay(50);
            } while (!pinState);

            if (pinState)
            {
                blink = false;
                lbl_Status_Text.Text = "START";
                lbl_Status_Text.BackColor = Color.Lime;
                txt_Message_Text.Text = Constants.Messages.Connect_Test_Cable;
            }
            else
            {
                Console.WriteLine("check_NGResetPin: This log message should never be displayed...");
            }
            releasePin_sw.Restart();
            start_CheckAsync();
        }

        private void clearForm_WaitForBarcodeScan()
        {
            lbl_Status_Text.Text = "READY";
            lbl_Status_Text.BackColor = Color.Yellow;
            txt_Message_Text.Text = Constants.Messages.System_Ready;

            powerValues.Clear();
            bitsToCheck.Clear();
            bitsToCheckNGMaster.Clear();
            bitsToCheckLineTest.Clear();

            dGV_DIO_Line_Details_Test.DataSource = null;
            dGV_DIO_Line_Details_Test.Refresh();

            dGV_Data.DataSource = null;
            dGV_Data.Refresh();

            txt_CarMaker.Text = string.Empty;
            txt_PartName.Text = string.Empty;
            txt_PartNumber.Text = string.Empty;
            txt_ATMT.Text = string.Empty;
            txt_CarModel.Text = string.Empty;
            txt_Engine.Text = string.Empty;
            txt_Variant.Text = string.Empty;

            txt_Total.Text = string.Empty;
            txt_OK.Text = string.Empty;
            txt_NG.Text = string.Empty;
            txt_PPM.Text = string.Empty;

            txt_ALC.ReadOnly = false;
            txt_ALC.Text = string.Empty;
            txt_ALC.Focus();
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            breakLoop = true;
            //Console.WriteLine("Date Time : " + DateTime.Now);
            //printDoc.Print();
            if (MessageBox.Show("Do you really want to move on to a different part?", "Confirm Move", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                btn_Next.Enabled = false;
                lbl_Status_Text.Text = "START";
                lbl_Status_Text.BackColor = Color.Lime;
                txt_Message_Text.Text = Constants.Messages.Connect_NG_Master;
                endingNGCableValidation = true;
            }
            start_CheckAsync();
        }

        private void printBarcodeLabel()
        {
            string printFileText = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, barcodePrintFileName));

            printFileText = printFileText.Replace("@alcCode@", txt_ALC.Text);
            printFileText = printFileText.Replace("@partNumber@", txt_PartNumber.Text);
            printFileText = printFileText.Replace("@partName@", txt_PartName.Text);
            printFileText = printFileText.Replace("@carMaker@", txt_CarMaker.Text);
            printFileText = printFileText.Replace("@carModel@", txt_CarModel.Text);
            printFileText = printFileText.Replace("@transmission@", txt_ATMT.Text);
            printFileText = printFileText.Replace("@engine@", txt_Engine.Text);
            printFileText = printFileText.Replace("@variant@", txt_Variant.Text);
            printFileText = printFileText.Replace("@lotNo@", lotNo);
            printFileText = printFileText.Replace("@traceabilityCode@", traceabilityCode);
            printFileText = printFileText.Replace("@ddMMyy@", GetDateTime(DateTime.Now, "ddMMyy"));
            printFileText = printFileText.Replace("@HH:mm:ss@", GetDateTime(DateTime.Now, "HH:mm:ss"));
            printFileText = printFileText.Replace("@machineID@", machineID);
            printFileText = printFileText.Replace("@machineID_NoAlphabet@", machineID.Substring(2));

            string tmpFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Common.Constants.tmpLabelPrintFileName);
            File.WriteAllText(tmpFileName, printFileText);
            Common.RawPrinterHelper.SendFileToPrinter(Common.Constants.printerName, tmpFileName);
        }

        private string GetDateTime(DateTime d, string format)
        {
            return (d.ToString(format));
        }

        private void pictureBox_PartImage_MouseClick(object sender, MouseEventArgs e)
        {
            bool isNullOrEmpty = ((PictureBox)sender) == null || ((PictureBox)sender).Image == null;
            if (!isNullOrEmpty)
            {
                MaxView view = new MaxView();
                view.setImage(((PictureBox)sender).Image);
                view.Show();
            }
        }
    }
}
