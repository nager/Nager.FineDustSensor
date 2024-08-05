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
            tabControl1 = new TabControl();
            tabPageMeasurement = new TabPage();
            tabPageManagement = new TabPage();
            groupBoxSensor = new GroupBox();
            buttonSleep = new Button();
            buttonWakeUp = new Button();
            groupBoxVersion = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)chartFineDust).BeginInit();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageMeasurement.SuspendLayout();
            tabPageManagement.SuspendLayout();
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
            // groupBoxSensor
            // 
            groupBoxSensor.Controls.Add(buttonSleep);
            groupBoxSensor.Controls.Add(buttonWakeUp);
            groupBoxSensor.Location = new Point(6, 91);
            groupBoxSensor.Name = "groupBoxSensor";
            groupBoxSensor.Size = new Size(281, 89);
            groupBoxSensor.TabIndex = 14;
            groupBoxSensor.TabStop = false;
            groupBoxSensor.Text = "Sensor";
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
            buttonWakeUp.Location = new Point(6, 51);
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
            tabControl1.ResumeLayout(false);
            tabPageMeasurement.ResumeLayout(false);
            tabPageManagement.ResumeLayout(false);
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
    }
}
