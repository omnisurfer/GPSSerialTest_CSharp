namespace GPSTesterApp
{
    partial class GPSTestApp
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
            this.components = new System.ComponentModel.Container();
            this.ctbControlPort = new System.Windows.Forms.ComboBox();
            this.ctbTestPort = new System.Windows.Forms.ComboBox();
            this.ctbControlBaud = new System.Windows.Forms.ComboBox();
            this.ctbControlParity = new System.Windows.Forms.ComboBox();
            this.ctbControlStopBits = new System.Windows.Forms.ComboBox();
            this.ctbControlDataBits = new System.Windows.Forms.ComboBox();
            this.btnOpenControlPort = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ctbTestBaud = new System.Windows.Forms.ComboBox();
            this.ctbTestParity = new System.Windows.Forms.ComboBox();
            this.ctbTestStopBits = new System.Windows.Forms.ComboBox();
            this.ctbTestDataBits = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCloseControlPort = new System.Windows.Forms.Button();
            this.btnCloseTestPort = new System.Windows.Forms.Button();
            this.btnOpenTestPort = new System.Windows.Forms.Button();
            this.tabControlSerialPort = new System.Windows.Forms.TabControl();
            this.tabControlSettings = new System.Windows.Forms.TabPage();
            this.tabControlOutput = new System.Windows.Forms.TabPage();
            this.tbControl = new System.Windows.Forms.TextBox();
            this.tabTestSerialPort = new System.Windows.Forms.TabControl();
            this.tabTestSettings = new System.Windows.Forms.TabPage();
            this.tabTestOutput = new System.Windows.Forms.TabPage();
            this.tbTest = new System.Windows.Forms.TextBox();
            this.tbControlDebugOut = new System.Windows.Forms.TextBox();
            this.tbTestDebugOut = new System.Windows.Forms.TextBox();
            this.tabDebug = new System.Windows.Forms.TabControl();
            this.tabControlDebug = new System.Windows.Forms.TabPage();
            this.tabTestDebug = new System.Windows.Forms.TabPage();
            this.tabSimDebug = new System.Windows.Forms.TabPage();
            this.btnLoadSimData = new System.Windows.Forms.Button();
            this.tbSimStream = new System.Windows.Forms.TextBox();
            this.btnSimDataRcv = new System.Windows.Forms.Button();
            this.lbSimStream = new System.Windows.Forms.Label();
            this.timerSimDebug = new System.Windows.Forms.Timer(this.components);
            this.tabControlSerialPort.SuspendLayout();
            this.tabControlSettings.SuspendLayout();
            this.tabControlOutput.SuspendLayout();
            this.tabTestSerialPort.SuspendLayout();
            this.tabTestSettings.SuspendLayout();
            this.tabTestOutput.SuspendLayout();
            this.tabDebug.SuspendLayout();
            this.tabControlDebug.SuspendLayout();
            this.tabTestDebug.SuspendLayout();
            this.tabSimDebug.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctbControlPort
            // 
            this.ctbControlPort.FormattingEnabled = true;
            this.ctbControlPort.Location = new System.Drawing.Point(3, 19);
            this.ctbControlPort.MaxDropDownItems = 9;
            this.ctbControlPort.Name = "ctbControlPort";
            this.ctbControlPort.Size = new System.Drawing.Size(121, 21);
            this.ctbControlPort.TabIndex = 0;
            // 
            // ctbTestPort
            // 
            this.ctbTestPort.FormattingEnabled = true;
            this.ctbTestPort.Location = new System.Drawing.Point(3, 19);
            this.ctbTestPort.Name = "ctbTestPort";
            this.ctbTestPort.Size = new System.Drawing.Size(121, 21);
            this.ctbTestPort.TabIndex = 3;
            // 
            // ctbControlBaud
            // 
            this.ctbControlBaud.FormattingEnabled = true;
            this.ctbControlBaud.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.ctbControlBaud.Location = new System.Drawing.Point(3, 59);
            this.ctbControlBaud.Name = "ctbControlBaud";
            this.ctbControlBaud.Size = new System.Drawing.Size(121, 21);
            this.ctbControlBaud.TabIndex = 4;
            // 
            // ctbControlParity
            // 
            this.ctbControlParity.FormattingEnabled = true;
            this.ctbControlParity.Location = new System.Drawing.Point(3, 99);
            this.ctbControlParity.Name = "ctbControlParity";
            this.ctbControlParity.Size = new System.Drawing.Size(121, 21);
            this.ctbControlParity.TabIndex = 5;
            // 
            // ctbControlStopBits
            // 
            this.ctbControlStopBits.FormattingEnabled = true;
            this.ctbControlStopBits.Location = new System.Drawing.Point(150, 19);
            this.ctbControlStopBits.Name = "ctbControlStopBits";
            this.ctbControlStopBits.Size = new System.Drawing.Size(121, 21);
            this.ctbControlStopBits.TabIndex = 6;
            // 
            // ctbControlDataBits
            // 
            this.ctbControlDataBits.FormattingEnabled = true;
            this.ctbControlDataBits.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.ctbControlDataBits.Location = new System.Drawing.Point(150, 59);
            this.ctbControlDataBits.Name = "ctbControlDataBits";
            this.ctbControlDataBits.Size = new System.Drawing.Size(121, 21);
            this.ctbControlDataBits.TabIndex = 7;
            // 
            // btnOpenControlPort
            // 
            this.btnOpenControlPort.Location = new System.Drawing.Point(12, 4);
            this.btnOpenControlPort.Name = "btnOpenControlPort";
            this.btnOpenControlPort.Size = new System.Drawing.Size(148, 23);
            this.btnOpenControlPort.TabIndex = 8;
            this.btnOpenControlPort.Text = "Open Control Port";
            this.btnOpenControlPort.UseVisualStyleBackColor = true;
            this.btnOpenControlPort.Click += new System.EventHandler(this.btnOpenControlPort_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "COM Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Baud Rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Parity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(147, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Stop Bits";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(147, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Data Bits";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "COM Port";
            // 
            // ctbTestBaud
            // 
            this.ctbTestBaud.FormattingEnabled = true;
            this.ctbTestBaud.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.ctbTestBaud.Location = new System.Drawing.Point(3, 59);
            this.ctbTestBaud.Name = "ctbTestBaud";
            this.ctbTestBaud.Size = new System.Drawing.Size(121, 21);
            this.ctbTestBaud.TabIndex = 15;
            // 
            // ctbTestParity
            // 
            this.ctbTestParity.FormattingEnabled = true;
            this.ctbTestParity.Location = new System.Drawing.Point(3, 99);
            this.ctbTestParity.Name = "ctbTestParity";
            this.ctbTestParity.Size = new System.Drawing.Size(121, 21);
            this.ctbTestParity.TabIndex = 16;
            // 
            // ctbTestStopBits
            // 
            this.ctbTestStopBits.FormattingEnabled = true;
            this.ctbTestStopBits.Location = new System.Drawing.Point(150, 19);
            this.ctbTestStopBits.Name = "ctbTestStopBits";
            this.ctbTestStopBits.Size = new System.Drawing.Size(121, 21);
            this.ctbTestStopBits.TabIndex = 17;
            // 
            // ctbTestDataBits
            // 
            this.ctbTestDataBits.FormattingEnabled = true;
            this.ctbTestDataBits.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.ctbTestDataBits.Location = new System.Drawing.Point(150, 59);
            this.ctbTestDataBits.Name = "ctbTestDataBits";
            this.ctbTestDataBits.Size = new System.Drawing.Size(121, 21);
            this.ctbTestDataBits.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Baud Rate";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Parity";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(147, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Stop Bits";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(147, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Data Bits";
            // 
            // btnCloseControlPort
            // 
            this.btnCloseControlPort.Location = new System.Drawing.Point(166, 4);
            this.btnCloseControlPort.Name = "btnCloseControlPort";
            this.btnCloseControlPort.Size = new System.Drawing.Size(148, 23);
            this.btnCloseControlPort.TabIndex = 23;
            this.btnCloseControlPort.Text = "Close Control Port";
            this.btnCloseControlPort.UseVisualStyleBackColor = true;
            this.btnCloseControlPort.Click += new System.EventHandler(this.btnCloseControlPort_Click);
            // 
            // btnCloseTestPort
            // 
            this.btnCloseTestPort.Location = new System.Drawing.Point(166, 234);
            this.btnCloseTestPort.Name = "btnCloseTestPort";
            this.btnCloseTestPort.Size = new System.Drawing.Size(148, 23);
            this.btnCloseTestPort.TabIndex = 25;
            this.btnCloseTestPort.Text = "Close Test Port";
            this.btnCloseTestPort.UseVisualStyleBackColor = true;
            this.btnCloseTestPort.Click += new System.EventHandler(this.btnCloseTestPort_Click);
            // 
            // btnOpenTestPort
            // 
            this.btnOpenTestPort.Location = new System.Drawing.Point(12, 234);
            this.btnOpenTestPort.Name = "btnOpenTestPort";
            this.btnOpenTestPort.Size = new System.Drawing.Size(148, 23);
            this.btnOpenTestPort.TabIndex = 24;
            this.btnOpenTestPort.Text = "Open Test Port";
            this.btnOpenTestPort.UseVisualStyleBackColor = true;
            this.btnOpenTestPort.Click += new System.EventHandler(this.btnOpenTestPort_Click);
            // 
            // tabControlSerialPort
            // 
            this.tabControlSerialPort.Controls.Add(this.tabControlSettings);
            this.tabControlSerialPort.Controls.Add(this.tabControlOutput);
            this.tabControlSerialPort.Location = new System.Drawing.Point(12, 33);
            this.tabControlSerialPort.Name = "tabControlSerialPort";
            this.tabControlSerialPort.SelectedIndex = 0;
            this.tabControlSerialPort.Size = new System.Drawing.Size(514, 186);
            this.tabControlSerialPort.TabIndex = 26;
            // 
            // tabControlSettings
            // 
            this.tabControlSettings.Controls.Add(this.ctbControlPort);
            this.tabControlSettings.Controls.Add(this.label1);
            this.tabControlSettings.Controls.Add(this.ctbControlBaud);
            this.tabControlSettings.Controls.Add(this.label2);
            this.tabControlSettings.Controls.Add(this.label3);
            this.tabControlSettings.Controls.Add(this.ctbControlParity);
            this.tabControlSettings.Controls.Add(this.ctbControlStopBits);
            this.tabControlSettings.Controls.Add(this.label4);
            this.tabControlSettings.Controls.Add(this.label5);
            this.tabControlSettings.Controls.Add(this.ctbControlDataBits);
            this.tabControlSettings.Location = new System.Drawing.Point(4, 22);
            this.tabControlSettings.Name = "tabControlSettings";
            this.tabControlSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabControlSettings.Size = new System.Drawing.Size(506, 160);
            this.tabControlSettings.TabIndex = 1;
            this.tabControlSettings.Text = "Control Port Settings";
            this.tabControlSettings.UseVisualStyleBackColor = true;
            // 
            // tabControlOutput
            // 
            this.tabControlOutput.Controls.Add(this.tbControl);
            this.tabControlOutput.Location = new System.Drawing.Point(4, 22);
            this.tabControlOutput.Name = "tabControlOutput";
            this.tabControlOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tabControlOutput.Size = new System.Drawing.Size(506, 160);
            this.tabControlOutput.TabIndex = 0;
            this.tabControlOutput.Text = "Control Serial Output";
            this.tabControlOutput.UseVisualStyleBackColor = true;
            // 
            // tbControl
            // 
            this.tbControl.Location = new System.Drawing.Point(3, 6);
            this.tbControl.Multiline = true;
            this.tbControl.Name = "tbControl";
            this.tbControl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbControl.Size = new System.Drawing.Size(497, 148);
            this.tbControl.TabIndex = 29;
            // 
            // tabTestSerialPort
            // 
            this.tabTestSerialPort.Controls.Add(this.tabTestSettings);
            this.tabTestSerialPort.Controls.Add(this.tabTestOutput);
            this.tabTestSerialPort.Location = new System.Drawing.Point(12, 263);
            this.tabTestSerialPort.Name = "tabTestSerialPort";
            this.tabTestSerialPort.SelectedIndex = 0;
            this.tabTestSerialPort.Size = new System.Drawing.Size(510, 186);
            this.tabTestSerialPort.TabIndex = 27;
            // 
            // tabTestSettings
            // 
            this.tabTestSettings.Controls.Add(this.label6);
            this.tabTestSettings.Controls.Add(this.ctbTestPort);
            this.tabTestSettings.Controls.Add(this.label7);
            this.tabTestSettings.Controls.Add(this.ctbTestBaud);
            this.tabTestSettings.Controls.Add(this.label8);
            this.tabTestSettings.Controls.Add(this.ctbTestDataBits);
            this.tabTestSettings.Controls.Add(this.label10);
            this.tabTestSettings.Controls.Add(this.ctbTestParity);
            this.tabTestSettings.Controls.Add(this.label9);
            this.tabTestSettings.Controls.Add(this.ctbTestStopBits);
            this.tabTestSettings.Location = new System.Drawing.Point(4, 22);
            this.tabTestSettings.Name = "tabTestSettings";
            this.tabTestSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabTestSettings.Size = new System.Drawing.Size(502, 160);
            this.tabTestSettings.TabIndex = 1;
            this.tabTestSettings.Text = "Test Port Settings";
            this.tabTestSettings.UseVisualStyleBackColor = true;
            // 
            // tabTestOutput
            // 
            this.tabTestOutput.Controls.Add(this.tbTest);
            this.tabTestOutput.Location = new System.Drawing.Point(4, 22);
            this.tabTestOutput.Name = "tabTestOutput";
            this.tabTestOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tabTestOutput.Size = new System.Drawing.Size(502, 160);
            this.tabTestOutput.TabIndex = 0;
            this.tabTestOutput.Text = "Test Serial Output";
            this.tabTestOutput.UseVisualStyleBackColor = true;
            // 
            // tbTest
            // 
            this.tbTest.Location = new System.Drawing.Point(3, 6);
            this.tbTest.Multiline = true;
            this.tbTest.Name = "tbTest";
            this.tbTest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTest.Size = new System.Drawing.Size(493, 148);
            this.tbTest.TabIndex = 30;
            // 
            // tbControlDebugOut
            // 
            this.tbControlDebugOut.Location = new System.Drawing.Point(5, 6);
            this.tbControlDebugOut.Multiline = true;
            this.tbControlDebugOut.Name = "tbControlDebugOut";
            this.tbControlDebugOut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbControlDebugOut.Size = new System.Drawing.Size(464, 148);
            this.tbControlDebugOut.TabIndex = 28;
            // 
            // tbTestDebugOut
            // 
            this.tbTestDebugOut.Location = new System.Drawing.Point(6, 6);
            this.tbTestDebugOut.Multiline = true;
            this.tbTestDebugOut.Name = "tbTestDebugOut";
            this.tbTestDebugOut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbTestDebugOut.Size = new System.Drawing.Size(463, 148);
            this.tbTestDebugOut.TabIndex = 29;
            // 
            // tabDebug
            // 
            this.tabDebug.Controls.Add(this.tabControlDebug);
            this.tabDebug.Controls.Add(this.tabTestDebug);
            this.tabDebug.Controls.Add(this.tabSimDebug);
            this.tabDebug.Location = new System.Drawing.Point(541, 33);
            this.tabDebug.Name = "tabDebug";
            this.tabDebug.SelectedIndex = 0;
            this.tabDebug.Size = new System.Drawing.Size(483, 186);
            this.tabDebug.TabIndex = 30;
            // 
            // tabControlDebug
            // 
            this.tabControlDebug.Controls.Add(this.tbControlDebugOut);
            this.tabControlDebug.Location = new System.Drawing.Point(4, 22);
            this.tabControlDebug.Name = "tabControlDebug";
            this.tabControlDebug.Padding = new System.Windows.Forms.Padding(3);
            this.tabControlDebug.Size = new System.Drawing.Size(475, 160);
            this.tabControlDebug.TabIndex = 0;
            this.tabControlDebug.Text = "ControlDebug";
            this.tabControlDebug.UseVisualStyleBackColor = true;
            // 
            // tabTestDebug
            // 
            this.tabTestDebug.Controls.Add(this.tbTestDebugOut);
            this.tabTestDebug.Location = new System.Drawing.Point(4, 22);
            this.tabTestDebug.Name = "tabTestDebug";
            this.tabTestDebug.Padding = new System.Windows.Forms.Padding(3);
            this.tabTestDebug.Size = new System.Drawing.Size(475, 160);
            this.tabTestDebug.TabIndex = 1;
            this.tabTestDebug.Text = "TestDebug";
            this.tabTestDebug.UseVisualStyleBackColor = true;
            // 
            // tabSimDebug
            // 
            this.tabSimDebug.Controls.Add(this.btnLoadSimData);
            this.tabSimDebug.Controls.Add(this.tbSimStream);
            this.tabSimDebug.Controls.Add(this.btnSimDataRcv);
            this.tabSimDebug.Controls.Add(this.lbSimStream);
            this.tabSimDebug.Location = new System.Drawing.Point(4, 22);
            this.tabSimDebug.Name = "tabSimDebug";
            this.tabSimDebug.Padding = new System.Windows.Forms.Padding(3);
            this.tabSimDebug.Size = new System.Drawing.Size(475, 160);
            this.tabSimDebug.TabIndex = 2;
            this.tabSimDebug.Text = "SimDebug";
            this.tabSimDebug.UseVisualStyleBackColor = true;
            // 
            // btnLoadSimData
            // 
            this.btnLoadSimData.Location = new System.Drawing.Point(167, 9);
            this.btnLoadSimData.Name = "btnLoadSimData";
            this.btnLoadSimData.Size = new System.Drawing.Size(89, 23);
            this.btnLoadSimData.TabIndex = 32;
            this.btnLoadSimData.Text = "Load Sim Data";
            this.btnLoadSimData.UseVisualStyleBackColor = true;
            this.btnLoadSimData.Click += new System.EventHandler(this.btnLoadSimData_Click);
            // 
            // tbSimStream
            // 
            this.tbSimStream.Location = new System.Drawing.Point(6, 43);
            this.tbSimStream.Multiline = true;
            this.tbSimStream.Name = "tbSimStream";
            this.tbSimStream.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbSimStream.Size = new System.Drawing.Size(464, 111);
            this.tbSimStream.TabIndex = 29;
            // 
            // btnSimDataRcv
            // 
            this.btnSimDataRcv.Location = new System.Drawing.Point(72, 9);
            this.btnSimDataRcv.Name = "btnSimDataRcv";
            this.btnSimDataRcv.Size = new System.Drawing.Size(89, 23);
            this.btnSimDataRcv.TabIndex = 31;
            this.btnSimDataRcv.Text = "Sim Data Rcv";
            this.btnSimDataRcv.UseVisualStyleBackColor = true;
            this.btnSimDataRcv.Click += new System.EventHandler(this.btnSimRcv_Click);
            // 
            // lbSimStream
            // 
            this.lbSimStream.AutoSize = true;
            this.lbSimStream.Location = new System.Drawing.Point(6, 19);
            this.lbSimStream.Name = "lbSimStream";
            this.lbSimStream.Size = new System.Drawing.Size(60, 13);
            this.lbSimStream.TabIndex = 23;
            this.lbSimStream.Text = "Sim Stream";
            // 
            // timerSimDebug
            // 
            this.timerSimDebug.Interval = 1000;
            this.timerSimDebug.Tick += new System.EventHandler(this.timerDebug_Tick);
            // 
            // GPSTestApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 462);
            this.Controls.Add(this.tabDebug);
            this.Controls.Add(this.tabTestSerialPort);
            this.Controls.Add(this.tabControlSerialPort);
            this.Controls.Add(this.btnCloseTestPort);
            this.Controls.Add(this.btnOpenTestPort);
            this.Controls.Add(this.btnCloseControlPort);
            this.Controls.Add(this.btnOpenControlPort);
            this.Name = "GPSTestApp";
            this.Text = "GPS Test App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GPSTestApp_FormClosing);
            this.Load += new System.EventHandler(this.GPSTestApp_Load);
            this.Shown += new System.EventHandler(this.GPSTestApp_Shown);
            this.tabControlSerialPort.ResumeLayout(false);
            this.tabControlSettings.ResumeLayout(false);
            this.tabControlSettings.PerformLayout();
            this.tabControlOutput.ResumeLayout(false);
            this.tabControlOutput.PerformLayout();
            this.tabTestSerialPort.ResumeLayout(false);
            this.tabTestSettings.ResumeLayout(false);
            this.tabTestSettings.PerformLayout();
            this.tabTestOutput.ResumeLayout(false);
            this.tabTestOutput.PerformLayout();
            this.tabDebug.ResumeLayout(false);
            this.tabControlDebug.ResumeLayout(false);
            this.tabControlDebug.PerformLayout();
            this.tabTestDebug.ResumeLayout(false);
            this.tabTestDebug.PerformLayout();
            this.tabSimDebug.ResumeLayout(false);
            this.tabSimDebug.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ctbControlPort;
        private System.Windows.Forms.ComboBox ctbTestPort;
        private System.Windows.Forms.ComboBox ctbControlBaud;
        private System.Windows.Forms.ComboBox ctbControlParity;
        private System.Windows.Forms.ComboBox ctbControlStopBits;
        private System.Windows.Forms.ComboBox ctbControlDataBits;
        private System.Windows.Forms.Button btnOpenControlPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ctbTestBaud;
        private System.Windows.Forms.ComboBox ctbTestParity;
        private System.Windows.Forms.ComboBox ctbTestStopBits;
        private System.Windows.Forms.ComboBox ctbTestDataBits;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnCloseControlPort;
        private System.Windows.Forms.Button btnCloseTestPort;
        private System.Windows.Forms.Button btnOpenTestPort;
        private System.Windows.Forms.TabControl tabControlSerialPort;
        private System.Windows.Forms.TabPage tabControlOutput;
        private System.Windows.Forms.TabPage tabControlSettings;
        private System.Windows.Forms.TabControl tabTestSerialPort;
        private System.Windows.Forms.TabPage tabTestOutput;
        private System.Windows.Forms.TabPage tabTestSettings;
        private System.Windows.Forms.TextBox tbControl;
        private System.Windows.Forms.TextBox tbTest;
        private System.Windows.Forms.TextBox tbControlDebugOut;
        private System.Windows.Forms.TextBox tbTestDebugOut;
        private System.Windows.Forms.TabControl tabDebug;
        private System.Windows.Forms.TabPage tabControlDebug;
        private System.Windows.Forms.TabPage tabTestDebug;
        private System.Windows.Forms.TextBox tbSimStream;
        private System.Windows.Forms.Label lbSimStream;
        private System.Windows.Forms.Button btnSimDataRcv;
        private System.Windows.Forms.Timer timerSimDebug;
        private System.Windows.Forms.Button btnLoadSimData;
        private System.Windows.Forms.TabPage tabSimDebug;
    }
}

