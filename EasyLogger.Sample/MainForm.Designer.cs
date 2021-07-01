namespace EasyLogger.Sample
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            this.CmbLogLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtLogMessage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnLog = new System.Windows.Forms.Button();
            this.LstLogs = new System.Windows.Forms.ListBox();
            this.BtnOpenFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CmbLogLevel
            // 
            this.CmbLogLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbLogLevel.FormattingEnabled = true;
            this.CmbLogLevel.Location = new System.Drawing.Point(12, 35);
            this.CmbLogLevel.Name = "CmbLogLevel";
            this.CmbLogLevel.Size = new System.Drawing.Size(133, 21);
            this.CmbLogLevel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Log Level\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtLogMessage
            // 
            this.TxtLogMessage.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtLogMessage.Location = new System.Drawing.Point(151, 35);
            this.TxtLogMessage.Name = "TxtLogMessage";
            this.TxtLogMessage.Size = new System.Drawing.Size(276, 20);
            this.TxtLogMessage.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(151, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Log Message";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnLog
            // 
            this.BtnLog.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnLog.Location = new System.Drawing.Point(435, 35);
            this.BtnLog.Name = "BtnLog";
            this.BtnLog.Size = new System.Drawing.Size(75, 21);
            this.BtnLog.TabIndex = 4;
            this.BtnLog.Text = "Log";
            this.BtnLog.UseVisualStyleBackColor = true;
            // 
            // LstLogs
            // 
            this.LstLogs.FormattingEnabled = true;
            this.LstLogs.Location = new System.Drawing.Point(12, 62);
            this.LstLogs.Name = "LstLogs";
            this.LstLogs.Size = new System.Drawing.Size(498, 381);
            this.LstLogs.TabIndex = 5;
            // 
            // BtnOpenFile
            // 
            this.BtnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOpenFile.Location = new System.Drawing.Point(435, 9);
            this.BtnOpenFile.Name = "BtnOpenFile";
            this.BtnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.BtnOpenFile.TabIndex = 6;
            this.BtnOpenFile.Text = "Open File";
            this.BtnOpenFile.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 450);
            this.Controls.Add(this.BtnOpenFile);
            this.Controls.Add(this.LstLogs);
            this.Controls.Add(this.BtnLog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtLogMessage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbLogLevel);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button BtnOpenFile;

        private System.Windows.Forms.ListBox  LstLogs;
        private System.Windows.Forms.Label    label2;
        private System.Windows.Forms.Button   BtnLog;
        private System.Windows.Forms.ComboBox CmbLogLevel;
        private System.Windows.Forms.Label    label1;
        private System.Windows.Forms.TextBox  TxtLogMessage;

        #endregion
    }
}