namespace Nager.FineDustSensor.SensorControl
{
    partial class Form1
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine1 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine2 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine3 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine4 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine5 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            textBoxSerialPort = new TextBox();
            buttonConnect = new Button();
            buttonDisconnect = new Button();
            buttonGetVersion = new Button();
            chartFineDust = new System.Windows.Forms.DataVisualization.Charting.Chart();
            buttonStartRecording = new Button();
            buttonStartMeasurement = new Button();
            buttonStopMeasurement = new Button();
            buttonStopRecording = new Button();
            labelFirmwareVersion = new Label();
            labelHardwareRevision = new Label();
            labelShdlcProtocol = new Label();
            panel1 = new Panel();
            panel3 = new Panel();
            label4 = new Label();
            label2 = new Label();
            labelPM2_5 = new Label();
            panel2 = new Panel();
            label3 = new Label();
            label1 = new Label();
            labelPM1 = new Label();
            tabControl1 = new TabControl();
            tabPageMeasurement = new TabPage();
            tabPageManagement = new TabPage();
            groupBox1 = new GroupBox();
            label5 = new Label();
            buttonFanCleaning = new Button();
            groupBoxSensor = new GroupBox();
            buttonSleep = new Button();
            buttonWakeUp = new Button();
            groupBoxVersion = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)chartFineDust).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageMeasurement.SuspendLayout();
            tabPageManagement.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBoxSensor.SuspendLayout();
            groupBoxVersion.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxSerialPort
            // 
            textBoxSerialPort.Location = new Point(9, 10);
            textBoxSerialPort.Name = "textBoxSerialPort";
            textBoxSerialPort.Size = new Size(153, 23);
            textBoxSerialPort.TabIndex = 0;
            textBoxSerialPort.Text = "COM5";
            // 
            // buttonConnect
            // 
            buttonConnect.Location = new Point(168, 10);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(75, 23);
            buttonConnect.TabIndex = 1;
            buttonConnect.Text = "Connect";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += buttonConnect_Click;
            // 
            // buttonDisconnect
            // 
            buttonDisconnect.Location = new Point(246, 10);
            buttonDisconnect.Name = "buttonDisconnect";
            buttonDisconnect.Size = new Size(75, 23);
            buttonDisconnect.TabIndex = 2;
            buttonDisconnect.Text = "Disconnect";
            buttonDisconnect.UseVisualStyleBackColor = true;
            buttonDisconnect.Click += buttonDisconnect_Click;
            // 
            // buttonGetVersion
            // 
            buttonGetVersion.Location = new Point(195, 14);
            buttonGetVersion.Name = "buttonGetVersion";
            buttonGetVersion.Size = new Size(81, 23);
            buttonGetVersion.TabIndex = 3;
            buttonGetVersion.Text = "Refresh";
            buttonGetVersion.UseVisualStyleBackColor = true;
            buttonGetVersion.Click += buttonGetVersion_Click;
            // 
            // chartFineDust
            // 
            chartArea1.AxisX.LabelStyle.Format = "HH:mm:ss";
            chartArea1.AxisY.Interval = 10D;
            chartArea1.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.MajorGrid.Interval = 25D;
            chartArea1.AxisY.MajorGrid.IntervalOffset = 25D;
            chartArea1.AxisY.Minimum = 0D;
            stripLine1.BorderColor = Color.Aquamarine;
            stripLine1.BorderWidth = 2;
            stripLine1.ForeColor = Color.Aquamarine;
            stripLine1.IntervalOffset = 5D;
            stripLine1.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            stripLine1.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            stripLine1.StripWidthType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            stripLine1.Text = "good";
            stripLine2.BorderColor = Color.DarkCyan;
            stripLine2.ForeColor = Color.DarkCyan;
            stripLine2.IntervalOffset = 10D;
            stripLine2.Text = "fair";
            stripLine3.BorderColor = Color.Gold;
            stripLine3.ForeColor = Color.Gold;
            stripLine3.IntervalOffset = 15D;
            stripLine3.Text = "moderate";
            stripLine4.BorderColor = Color.DarkGray;
            stripLine4.ForeColor = Color.DarkGray;
            stripLine4.IntervalOffset = 20D;
            stripLine4.Text = "poor";
            stripLine5.BorderColor = Color.Black;
            stripLine5.IntervalOffset = 25D;
            stripLine5.Text = "very poor";
            chartArea1.AxisY.StripLines.Add(stripLine1);
            chartArea1.AxisY.StripLines.Add(stripLine2);
            chartArea1.AxisY.StripLines.Add(stripLine3);
            chartArea1.AxisY.StripLines.Add(stripLine4);
            chartArea1.AxisY.StripLines.Add(stripLine5);
            chartArea1.Name = "ChartArea1";
            chartFineDust.ChartAreas.Add(chartArea1);
            chartFineDust.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            chartFineDust.Legends.Add(legend1);
            chartFineDust.Location = new Point(3, 3);
            chartFineDust.Name = "chartFineDust";
            chartFineDust.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "PM2.5";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "PM1";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chartFineDust.Series.Add(series1);
            chartFineDust.Series.Add(series2);
            chartFineDust.Size = new Size(786, 315);
            chartFineDust.TabIndex = 5;
            chartFineDust.Text = "chart1";
            // 
            // buttonStartRecording
            // 
            buttonStartRecording.Location = new Point(9, 68);
            buttonStartRecording.Name = "buttonStartRecording";
            buttonStartRecording.Size = new Size(153, 23);
            buttonStartRecording.TabIndex = 6;
            buttonStartRecording.Text = "Start Recording";
            buttonStartRecording.UseVisualStyleBackColor = true;
            buttonStartRecording.Click += buttonStartRecording_Click;
            // 
            // buttonStartMeasurement
            // 
            buttonStartMeasurement.Location = new Point(9, 39);
            buttonStartMeasurement.Name = "buttonStartMeasurement";
            buttonStartMeasurement.Size = new Size(153, 23);
            buttonStartMeasurement.TabIndex = 7;
            buttonStartMeasurement.Text = "Start Measurement";
            buttonStartMeasurement.UseVisualStyleBackColor = true;
            buttonStartMeasurement.Click += buttonStartMeasurement_Click;
            // 
            // buttonStopMeasurement
            // 
            buttonStopMeasurement.Location = new Point(168, 39);
            buttonStopMeasurement.Name = "buttonStopMeasurement";
            buttonStopMeasurement.Size = new Size(153, 23);
            buttonStopMeasurement.TabIndex = 8;
            buttonStopMeasurement.Text = "Stop Measurement";
            buttonStopMeasurement.UseVisualStyleBackColor = true;
            buttonStopMeasurement.Click += buttonStopMeasurement_Click;
            // 
            // buttonStopRecording
            // 
            buttonStopRecording.Location = new Point(168, 68);
            buttonStopRecording.Name = "buttonStopRecording";
            buttonStopRecording.Size = new Size(153, 23);
            buttonStopRecording.TabIndex = 9;
            buttonStopRecording.Text = "Stop Recording";
            buttonStopRecording.UseVisualStyleBackColor = true;
            buttonStopRecording.Click += buttonStopRecording_Click;
            // 
            // labelFirmwareVersion
            // 
            labelFirmwareVersion.AutoSize = true;
            labelFirmwareVersion.Location = new Point(6, 18);
            labelFirmwareVersion.Name = "labelFirmwareVersion";
            labelFirmwareVersion.Size = new Size(94, 15);
            labelFirmwareVersion.TabIndex = 10;
            labelFirmwareVersion.Text = "FirmwareVersion";
            // 
            // labelHardwareRevision
            // 
            labelHardwareRevision.AutoSize = true;
            labelHardwareRevision.Location = new Point(6, 33);
            labelHardwareRevision.Name = "labelHardwareRevision";
            labelHardwareRevision.Size = new Size(102, 15);
            labelHardwareRevision.TabIndex = 11;
            labelHardwareRevision.Text = "HardwareRevision";
            // 
            // labelShdlcProtocol
            // 
            labelShdlcProtocol.AutoSize = true;
            labelShdlcProtocol.Location = new Point(6, 48);
            labelShdlcProtocol.Name = "labelShdlcProtocol";
            labelShdlcProtocol.Size = new Size(81, 15);
            labelShdlcProtocol.TabIndex = 11;
            labelShdlcProtocol.Text = "ShdlcProtocol";
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(textBoxSerialPort);
            panel1.Controls.Add(buttonConnect);
            panel1.Controls.Add(buttonDisconnect);
            panel1.Controls.Add(buttonStopRecording);
            panel1.Controls.Add(buttonStartRecording);
            panel1.Controls.Add(buttonStopMeasurement);
            panel1.Controls.Add(buttonStartMeasurement);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 101);
            panel1.TabIndex = 12;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLightLight;
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(labelPM2_5);
            panel3.Location = new Point(541, 10);
            panel3.Name = "panel3";
            panel3.Size = new Size(152, 61);
            panel3.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.AppWorkspace;
            label4.Location = new Point(103, 4);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 13;
            label4.Text = "µg/m³";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 4);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 11;
            label2.Text = "PM 2.5";
            // 
            // labelPM2_5
            // 
            labelPM2_5.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPM2_5.Location = new Point(3, 19);
            labelPM2_5.Name = "labelPM2_5";
            labelPM2_5.Size = new Size(146, 37);
            labelPM2_5.TabIndex = 10;
            labelPM2_5.Text = "PM2_5";
            labelPM2_5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLightLight;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(labelPM1);
            panel2.Location = new Point(383, 10);
            panel2.Name = "panel2";
            panel2.Size = new Size(152, 61);
            panel2.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.AppWorkspace;
            label3.Location = new Point(102, 4);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 12;
            label3.Text = "µg/m³";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 4);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 11;
            label1.Text = "PM 1";
            // 
            // labelPM1
            // 
            labelPM1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPM1.Location = new Point(3, 19);
            labelPM1.Name = "labelPM1";
            labelPM1.Size = new Size(146, 37);
            labelPM1.TabIndex = 10;
            labelPM1.Text = "PM1";
            labelPM1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageMeasurement);
            tabControl1.Controls.Add(tabPageManagement);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 101);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 349);
            tabControl1.TabIndex = 13;
            // 
            // tabPageMeasurement
            // 
            tabPageMeasurement.Controls.Add(chartFineDust);
            tabPageMeasurement.Location = new Point(4, 24);
            tabPageMeasurement.Name = "tabPageMeasurement";
            tabPageMeasurement.Padding = new Padding(3);
            tabPageMeasurement.Size = new Size(792, 321);
            tabPageMeasurement.TabIndex = 0;
            tabPageMeasurement.Text = "Measurement";
            tabPageMeasurement.UseVisualStyleBackColor = true;
            // 
            // tabPageManagement
            // 
            tabPageManagement.Controls.Add(groupBox1);
            tabPageManagement.Controls.Add(groupBoxSensor);
            tabPageManagement.Controls.Add(groupBoxVersion);
            tabPageManagement.Location = new Point(4, 24);
            tabPageManagement.Name = "tabPageManagement";
            tabPageManagement.Padding = new Padding(3);
            tabPageManagement.Size = new Size(792, 321);
            tabPageManagement.TabIndex = 1;
            tabPageManagement.Text = "Management";
            tabPageManagement.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(buttonFanCleaning);
            groupBox1.Location = new Point(6, 156);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(281, 89);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sensor";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 19);
            label5.Name = "label5";
            label5.Size = new Size(191, 15);
            label5.TabIndex = 12;
            label5.Text = "Start Measurement before required";
            // 
            // buttonFanCleaning
            // 
            buttonFanCleaning.Location = new Point(6, 37);
            buttonFanCleaning.Name = "buttonFanCleaning";
            buttonFanCleaning.Size = new Size(108, 23);
            buttonFanCleaning.TabIndex = 14;
            buttonFanCleaning.Text = "Fan Cleaning";
            buttonFanCleaning.UseVisualStyleBackColor = true;
            buttonFanCleaning.Click += buttonFanCleaning_Click;
            // 
            // groupBoxSensor
            // 
            groupBoxSensor.Controls.Add(buttonSleep);
            groupBoxSensor.Controls.Add(buttonWakeUp);
            groupBoxSensor.Location = new Point(6, 91);
            groupBoxSensor.Name = "groupBoxSensor";
            groupBoxSensor.Size = new Size(281, 59);
            groupBoxSensor.TabIndex = 14;
            groupBoxSensor.TabStop = false;
            groupBoxSensor.Text = "Deep Sleep";
            // 
            // buttonSleep
            // 
            buttonSleep.Location = new Point(6, 22);
            buttonSleep.Name = "buttonSleep";
            buttonSleep.Size = new Size(81, 23);
            buttonSleep.TabIndex = 12;
            buttonSleep.Text = "Sleep";
            buttonSleep.UseVisualStyleBackColor = true;
            buttonSleep.Click += buttonSleep_Click;
            // 
            // buttonWakeUp
            // 
            buttonWakeUp.Location = new Point(93, 22);
            buttonWakeUp.Name = "buttonWakeUp";
            buttonWakeUp.Size = new Size(81, 23);
            buttonWakeUp.TabIndex = 13;
            buttonWakeUp.Text = "Wake Up";
            buttonWakeUp.UseVisualStyleBackColor = true;
            buttonWakeUp.Click += buttonWakeUp_Click;
            // 
            // groupBoxVersion
            // 
            groupBoxVersion.Controls.Add(labelHardwareRevision);
            groupBoxVersion.Controls.Add(buttonGetVersion);
            groupBoxVersion.Controls.Add(labelFirmwareVersion);
            groupBoxVersion.Controls.Add(labelShdlcProtocol);
            groupBoxVersion.Location = new Point(5, 6);
            groupBoxVersion.Name = "groupBoxVersion";
            groupBoxVersion.Size = new Size(282, 79);
            groupBoxVersion.TabIndex = 12;
            groupBoxVersion.TabStop = false;
            groupBoxVersion.Text = "Version";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "FineDust SensorControl";
            ((System.ComponentModel.ISupportInitialize)chartFineDust).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPageMeasurement.ResumeLayout(false);
            tabPageManagement.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBoxSensor.ResumeLayout(false);
            groupBoxVersion.ResumeLayout(false);
            groupBoxVersion.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBoxSerialPort;
        private Button buttonConnect;
        private Button buttonDisconnect;
        private Button buttonGetVersion;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFineDust;
        private Button buttonStartRecording;
        private Button buttonStartMeasurement;
        private Button buttonStopMeasurement;
        private Button buttonStopRecording;
        private Label labelFirmwareVersion;
        private Label labelHardwareRevision;
        private Label labelShdlcProtocol;
        private Panel panel1;
        private TabControl tabControl1;
        private TabPage tabPageMeasurement;
        private TabPage tabPageManagement;
        private GroupBox groupBoxVersion;
        private Button buttonWakeUp;
        private Button buttonSleep;
        private GroupBox groupBoxSensor;
        private Label labelPM1;
        private Panel panel3;
        private Label label2;
        private Label labelPM2_5;
        private Panel panel2;
        private Label label1;
        private Label label4;
        private Label label3;
        private Button buttonFanCleaning;
        private GroupBox groupBox1;
        private Label label5;
    }
}
