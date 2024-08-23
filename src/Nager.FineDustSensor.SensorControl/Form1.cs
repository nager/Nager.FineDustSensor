using Microsoft.Extensions.Logging;
using Nager.FineDustSensor.Sps30;

namespace Nager.FineDustSensor.SensorControl
{
    public partial class Form1 : Form
    {
        private IDeviceCommunication _deviceCommunication;
        private Sps30Client _sps30Client;
        private CancellationTokenSource _cancellationTokenSource;
        private readonly ILoggerFactory _loggerFactory;

        public Form1()
        {
            this.InitializeComponent();
            this.DeactivateSensorControls();

            this.labelPM1.Text = "";
            this.labelPM2_5.Text = "";

            this._loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Trace);
                builder.AddFile("default.log", LogLevel.Trace, outputTemplate: "{Timestamp:HH:mm:ss.fff} {Level:u3} {SourceContext} {Message:lj}{NewLine}{Exception}");
            });
        }

        private void ActivateSensorControls()
        {
            this.buttonStartMeasurement.Enabled = true;
            this.buttonStopMeasurement.Enabled = true;
            this.buttonStartRecording.Enabled = true;
            this.buttonStopRecording.Enabled = false;
        }

        private void DeactivateSensorControls()
        {
            this.buttonStartMeasurement.Enabled = false;
            this.buttonStopMeasurement.Enabled = false;
            this.buttonStartRecording.Enabled = false;
            this.buttonStopRecording.Enabled = false;
        }

        private async void buttonConnect_Click(object sender, EventArgs e)
        {
            this._deviceCommunication = new SerialPortDeviceCommunication(this.textBoxSerialPort.Text, logger: this._loggerFactory.CreateLogger<SerialPortDeviceCommunication>());

            this._sps30Client = new Sps30Client(this._deviceCommunication, this._loggerFactory.CreateLogger<Sps30Client>());
            if (await this._deviceCommunication.ConnectAsync())
            {
                this.ActivateSensorControls();
                await this.GetVersionAsync();
            } else
            {
                MessageBox.Show("Cannot connect", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonDisconnect_Click(object sender, EventArgs e)
        {
            if (await this._deviceCommunication.DisconnectAsync())
            {
                this.DeactivateSensorControls();
            }
        }

        private async void buttonGetVersion_Click(object sender, EventArgs e)
        {
            await this.GetVersionAsync();
        }

        private async Task GetVersionAsync()
        {
            var versionResponse = await this._sps30Client.ReadVersionAsync();
            if (versionResponse == null)
            {
                this.labelFirmwareVersion.Text = string.Empty;
                this.labelHardwareRevision.Text = string.Empty;
                this.labelShdlcProtocol.Text = string.Empty;
                return;
            }

            this.labelFirmwareVersion.Text = $"Firmware Version: {versionResponse.FirmwareMajorVersion}.{versionResponse.FirmwareMinorVersion}";
            this.labelHardwareRevision.Text = $"Hardware Revision: {versionResponse.HardwareRevision}";
            this.labelShdlcProtocol.Text = $"Shdlc Protocol: {versionResponse.ShdlcProtocolMajorVersion}.{versionResponse.ShdlcProtocolMinorVersion}";
        }

        private void buttonStartRecording_Click(object sender, EventArgs e)
        {
            this._cancellationTokenSource = new CancellationTokenSource();
            var timeout = 1000;

            Task.Run(async () =>
            {
                while (!this._cancellationTokenSource.IsCancellationRequested)
                {
                    try
                    {
                        var dataCaptureTime = DateTime.Now;
                        var commandResponse = await this._sps30Client.ReadMeasuredValuesAsync(this._cancellationTokenSource.Token);
                        if (commandResponse == null)
                        {
                            await Task.Delay(timeout, this._cancellationTokenSource.Token);
                            continue;
                        }

                        this.labelPM1.Invoke(() =>
                        {
                            this.labelPM1.Text = commandResponse.MassConcentrationPm1.ToString("0.00");
                        });

                        this.labelPM2_5.Invoke(() =>
                        {
                            this.labelPM2_5.Text = commandResponse.MassConcentrationPm2_5.ToString("0.00");
                        });

                        this.chartFineDust.Invoke(() =>
                        {
                            this.chartFineDust.Series[0].Points.AddXY(dataCaptureTime, commandResponse.MassConcentrationPm2_5);
                            this.chartFineDust.Series[1].Points.AddXY(dataCaptureTime, commandResponse.MassConcentrationPm1);
                        });

                        await Task.Delay(timeout, this._cancellationTokenSource.Token);
                    }
                    catch (Exception exception)
                    {
                        //TODO: log failure
                    }
                }
            }, this._cancellationTokenSource.Token);

            this.buttonStartRecording.Enabled = false;
            this.buttonStopRecording.Enabled = true;
        }

        private void buttonStopRecording_Click(object sender, EventArgs e)
        {
            this._cancellationTokenSource.Cancel();

            this.buttonStopRecording.Enabled = false;
            this.buttonStartRecording.Enabled = true;
        }

        private async void buttonStartMeasurement_Click(object sender, EventArgs e)
        {
            if (!await this._sps30Client.StartMeasurementAsync())
            {
                MessageBox.Show("Cannot Start Measurement", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonStopMeasurement_Click(object sender, EventArgs e)
        {
            if (!await this._sps30Client.StopMeasurementAsync())
            {
                MessageBox.Show("Cannot Stop Measurement", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonSleep_Click(object sender, EventArgs e)
        {
            await this._sps30Client.SleepAsync();
        }

        private async void buttonWakeUp_Click(object sender, EventArgs e)
        {
            await this._sps30Client.WakeUpAsync();
        }
    }
}
