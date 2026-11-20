namespace Cable_Line_Test
{
    partial class MaxView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox_MaxView = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_MaxView)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_MaxView
            // 
            this.pictureBox_MaxView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_MaxView.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_MaxView.Name = "pictureBox_MaxView";
            this.pictureBox_MaxView.Size = new System.Drawing.Size(1264, 681);
            this.pictureBox_MaxView.TabIndex = 0;
            this.pictureBox_MaxView.TabStop = false;
            // 
            // MaxView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pictureBox_MaxView);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "MaxView";
            this.Text = "MAX VIEW";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_MaxView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_MaxView;
    }
}