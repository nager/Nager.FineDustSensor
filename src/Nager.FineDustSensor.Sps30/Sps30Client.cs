using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Nager.DataFragmentationHandler;
using Nager.FineDustSensor.Sps30.Helpers;
using Nager.FineDustSensor.Sps30.Models;
using Nager.FineDustSensor.Sps30.Responses;

namespace Nager.FineDustSensor.Sps30
{
    /// <summary>
    /// Sensirion Sps30 Client (SHDLC protocol, UART interface)
    /// </summary>
    public class Sps30Client : IDisposable
    {
        private readonly ILogger<Sps30Client> _logger;
        private readonly TimeSpan _commandTimeout = new TimeSpan(0, 0, 10);
        private readonly IDeviceCommunication _deviceCommunication;
        private readonly DataPackageHandler _dataPackageHandler;
        private readonly int _packageHeaderLength = 4;
        private event Action<ICommandResponse>? CommandResponseReceived;

        private bool _disposedValue;

        private readonly Dictionary<byte, string> _errorMessages = new()
        {
            { 0x00, "No error" },
            { 0x01, "Wrong data length for this command (too much or little data)" },
            { 0x02, "Unknown command" },
            { 0x03, "No access right for command" },
            { 0x04, "Illegal command parameter or parameter out of allowed range" },
            { 0x28, "Internal function argument out of range" },
            { 0x43, "Command not allowed in current state" }
        };

        /// <summary>
        /// Sensirion Sps30 Client (SHDLC protocol, UART interface)
        /// </summary>
        /// <remarks>https://sensirion.com/media/documents/8600FF88/64A3B8D6/Sensirion_PM_Sensors_Datasheet_SPS30.pdf</remarks>
        /// <param name="deviceCommunication"></param>
        /// <param name="logger"></param>
        public Sps30Client(
            IDeviceCommunication deviceCommunication,
            ILogger<Sps30Client>? logger = default)
        {
            this._logger = logger ?? new NullLogger<Sps30Client>();

            this._deviceCommunication = deviceCommunication;

            var dataPackageAnalyzer = new StartEndTokenDataPackageAnalyzer(0x7E, 0x7E);
            this._dataPackageHandler = new DataPackageHandler(dataPackageAnalyzer);
            this._dataPackageHandler.NewDataPackage += this.DataPackageHandlerNewDataPackage;

            this._deviceCommunication.DataReceived += this._dataPackageHandler.AddData;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                }

                this._deviceCommunication.DataReceived -= this._dataPackageHandler.AddData;
                this._dataPackageHandler.NewDataPackage -= this.DataPackageHandlerNewDataPackage;

                this._disposedValue = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        private string? GetErrorMessage(byte errorCode)
        {
            if (this._errorMessages.TryGetValue(errorCode, out var errorMessage))
            {
                return errorMessage;
            }

            return null;
        }

        private void DataPackageHandlerNewDataPackage(DataPackage dataPackage)
        {
            this._logger.LogTrace($"{nameof(DataPackageHandlerNewDataPackage)} - New package received {BitConverter.ToString(dataPackage.RawData)}");

            var cleanData = ByteStuffingHelper.Remove(dataPackage.Data.ToArray()).AsSpan();

            if (cleanData.Length < this._packageHeaderLength)
            {
                this._logger.LogError($"{nameof(DataPackageHandlerNewDataPackage)} - Response length too short");
                return;
            }

            var addr = cleanData[0];
            var cmd = cleanData[1];
            var state = cleanData[2];
            var length = cleanData[3];

            var packageWithoutChecksum = cleanData.Slice(0, cleanData.Length - 1);
            var calculatedChecksum = ChecksumHelper.CalculateChecksum(packageWithoutChecksum);
            var receivedChecksum = cleanData.Slice(cleanData.Length - 1)[0];

            if (calculatedChecksum != receivedChecksum)
            {
                this._logger.LogError($"{nameof(DataPackageHandlerNewDataPackage)} - Checksum invalid");
                return;
            }

            var errorFlag = BitHelper.GetBit(state, 0);
            var errorMessage = this.GetErrorMessage(state);

            if (!string.IsNullOrEmpty(errorMessage) && state != 0x00)
            {
                this._logger.LogError($"{nameof(DataPackageHandlerNewDataPackage)} - {errorMessage}");
            }

            if (length == 0)
            {
                this._logger.LogTrace($"{nameof(DataPackageHandlerNewDataPackage)} - Command confirmation {cmd:X2}");
            }

            switch ((Sps30Command)cmd)
            {
                case Sps30Command.StartMeasurement:
                    this.CommandResponseReceived?.Invoke(new NoDataCommandResponse(Sps30Command.StartMeasurement));
                    break;
                case Sps30Command.StopMeasurement:
                    this.CommandResponseReceived?.Invoke(new NoDataCommandResponse(Sps30Command.StopMeasurement));
                    break;
                case Sps30Command.Sleep:
                    this.CommandResponseReceived?.Invoke(new NoDataCommandResponse(Sps30Command.Sleep));
                    break;
                case Sps30Command.WakeUp:
                    this.CommandResponseReceived?.Invoke(new NoDataCommandResponse(Sps30Command.WakeUp));
                    break;
                case Sps30Command.ReadVersion:
                    this.ProcessReadVersion(packageWithoutChecksum);
                    break;
                case Sps30Command.ReadMeasuredValue:
                    this.ProcessReadMeasuredValue(packageWithoutChecksum);
                    break;
                default:
                    this._logger.LogError($"{nameof(DataPackageHandlerNewDataPackage)} - Unknown response {cmd:X2}, {BitConverter.ToString(dataPackage.Data.ToArray())}");
                    break;
            }
        }

        private void ProcessReadVersion(Span<byte> dataWithHeader)
        {
            var data = dataWithHeader.Slice(this._packageHeaderLength);

            var firmwareMajorVersion = Convert.ToInt32(data[0]);
            var firmwareMinorVersion = Convert.ToInt32(data[1]);
            var hardwareRevision = Convert.ToInt32(data[3]);
            var shdlcProtocolMajorVersion = Convert.ToInt32(data[5]);
            var shdlcProtocolMinorVersion = Convert.ToInt32(data[6]);

            var versionResponse = new VersionResponse
            {
                FirmwareMajorVersion = firmwareMajorVersion,
                FirmwareMinorVersion = firmwareMinorVersion,
                HardwareRevision = hardwareRevision,
                ShdlcProtocolMajorVersion = shdlcProtocolMajorVersion,
                ShdlcProtocolMinorVersion = shdlcProtocolMinorVersion
            };

            this.CommandResponseReceived?.Invoke(versionResponse);
        }

        private void ProcessReadMeasuredValue(Span<byte> dataWithHeader)
        {
            var data = dataWithHeader.Slice(this._packageHeaderLength);

            if (data.Length == 0)
            {
                this._logger.LogError($"{nameof(DataPackageHandlerNewDataPackage)} - No sensor data available");
                return;
            }

            if (data.Length < 40)
            {
                this._logger.LogError($"{nameof(DataPackageHandlerNewDataPackage)} - Invalid data length for ReadMeasuredValue");
                return;
            }

            var floatByteLength = 4;

            var tempMassConcentrationPm1_0 = data.Slice(0, floatByteLength);
            tempMassConcentrationPm1_0.Reverse();

            var tempMassConcentrationPm2_5 = data.Slice(4, floatByteLength);
            tempMassConcentrationPm2_5.Reverse();

            var tempMassConcentrationPm4_0 = data.Slice(8, floatByteLength);
            tempMassConcentrationPm4_0.Reverse();

            var tempMassConcentrationPm10 = data.Slice(12, floatByteLength);
            tempMassConcentrationPm10.Reverse();

            var tempNumberConcentrationPm0_5 = data.Slice(16, floatByteLength);
            tempNumberConcentrationPm0_5.Reverse();

            var tempNumberConcentrationPm1_0 = data.Slice(20, floatByteLength);
            tempNumberConcentrationPm1_0.Reverse();

            var tempNumberConcentrationPm2_5 = data.Slice(24, floatByteLength);
            tempNumberConcentrationPm2_5.Reverse();

            var tempNumberConcentrationPm4_0 = data.Slice(28, floatByteLength);
            tempNumberConcentrationPm4_0.Reverse();

            var tempNumberConcentrationPm10 = data.Slice(32, floatByteLength);
            tempNumberConcentrationPm10.Reverse();

            var tempTypicalParticleSize = data.Slice(36, floatByteLength);
            tempTypicalParticleSize.Reverse();

            var massConcentrationPm1 = BitConverter.ToSingle(tempMassConcentrationPm1_0); // µg/m³
            var massConcentrationPm2_5 = BitConverter.ToSingle(tempMassConcentrationPm2_5); // µg/m³
            var massConcentrationPm4 = BitConverter.ToSingle(tempMassConcentrationPm4_0); // µg/m³
            var massConcentrationPm10 = BitConverter.ToSingle(tempMassConcentrationPm10); // µg/m³

            var numberConcentrationPm0_5 = BitConverter.ToSingle(tempNumberConcentrationPm0_5); // partikel pro cm³
            var numberConcentrationPm1 = BitConverter.ToSingle(tempNumberConcentrationPm1_0); // partikel pro cm³
            var numberConcentrationPm2_5 = BitConverter.ToSingle(tempNumberConcentrationPm2_5); // partikel pro cm³
            var numberConcentrationPm4 = BitConverter.ToSingle(tempNumberConcentrationPm4_0); // partikel pro cm³
            var numberConcentrationPm10 = BitConverter.ToSingle(tempNumberConcentrationPm10); // partikel pro cm³

            var typicalParticleSize = BitConverter.ToSingle(tempTypicalParticleSize); //µm

            var measurementResponse = new MeasurementCommandResponse
            {
                MassConcentrationPm1 = massConcentrationPm1,
                MassConcentrationPm2_5 = massConcentrationPm2_5,
                MassConcentrationPm4 = massConcentrationPm4,
                MassConcentrationPm10 = massConcentrationPm10,
                NumberConcentrationPm0_5 = numberConcentrationPm0_5,
                NumberConcentrationPm1 = numberConcentrationPm1,
                NumberConcentrationPm2_5 = numberConcentrationPm2_5,
                NumberConcentrationPm4 = numberConcentrationPm4,
                NumberConcentrationPm10 = numberConcentrationPm10,
                TypicalParticleSize = typicalParticleSize
            };

            this.CommandResponseReceived?.Invoke(measurementResponse);
        }

        private async Task<SendCommandResult> SendCommandAsync(
            byte[] commandBytes,
            CancellationToken cancellationToken = default)
        {
            var sendBytes = ByteStuffingHelper.Add(commandBytes);

            using var commandTimeoutCancellationTokenSource = new CancellationTokenSource(this._commandTimeout);
            using var commandFinishCancellationTokenSource = new CancellationTokenSource();
            using var linkedCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(
                cancellationToken,
                commandFinishCancellationTokenSource.Token,
                commandTimeoutCancellationTokenSource.Token);

            ICommandResponse? response = null;

            void responseReceived(ICommandResponse commandResponse)
            {
                commandFinishCancellationTokenSource.Cancel();
                response = commandResponse;
            }

            try
            {
                this.CommandResponseReceived += responseReceived;

                var sendSuccessful = await this._deviceCommunication.SendAsync(sendBytes, linkedCancellationTokenSource.Token);

                await Task.Delay(Timeout.InfiniteTimeSpan, linkedCancellationTokenSource.Token).ContinueWith(task =>
                {
                    if (commandTimeoutCancellationTokenSource.IsCancellationRequested)
                    {
                        //commandResponse.State = CommandResponseState.Timeout;
                        this._logger.LogError($"{nameof(SendCommandAsync)} - No response received in the specified timeout {this._commandTimeout.TotalMilliseconds}ms");
                    }
                }, CancellationToken.None);

                return new SendCommandResult
                {
                    SendSuccessful = sendSuccessful,
                    CommandResponse = response
                };
            }
            catch (Exception exception)
            {
                this._logger.LogError(exception, $"{nameof(SendCommandAsync)}");

                return new SendCommandResult
                {
                    SendSuccessful = false
                };
            }
            finally
            {
                this.CommandResponseReceived -= responseReceived;
            }
        }

        /// <summary>
        /// Start Measurement
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> StartMeasurementAsync(CancellationToken cancellationToken = default)
        {
            /*
             * Output Format
             * 0x03 - Big-endian IEEE754 float values
             * 0x05 - Big-endian unsigned 16-bit integer values
             */

            byte outputFormat = 0x03;

            var commandBytes = CommandHelper.BuildCommand(Sps30Command.StartMeasurement, [0x01, outputFormat]);
            var sendDataResult = await this.SendCommandAsync(commandBytes, cancellationToken);

            return sendDataResult.SendSuccessful;
        }

        /// <summary>
        /// Stop Measurement
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> StopMeasurementAsync(CancellationToken cancellationToken = default)
        {
            var commandBytes = CommandHelper.BuildCommand(Sps30Command.StopMeasurement, []);
            var sendDataResult = await this.SendCommandAsync(commandBytes, cancellationToken);

            return sendDataResult.SendSuccessful;
        }

        /// <summary>
        /// Read Measured Values
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MeasurementCommandResponse?> ReadMeasuredValuesAsync(CancellationToken cancellationToken = default)
        {
            var commandBytes = CommandHelper.BuildCommand(Sps30Command.ReadMeasuredValue, []);
            var sendCommandResult = await this.SendCommandAsync(commandBytes, cancellationToken);

            if (sendCommandResult.CommandResponse is MeasurementCommandResponse measurementResponse)
            {
                return measurementResponse;
            }

            return null;
        }

        /// <summary>
        /// Sleep
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task SleepAsync(CancellationToken cancellationToken = default)
        {
            var commandBytes = CommandHelper.BuildCommand(Sps30Command.Sleep, []);
            await this.SendCommandAsync(commandBytes, cancellationToken);
        }

        /// <summary>
        /// WakeUp
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task WakeUpAsync(CancellationToken cancellationToken = default)
        {
            // The UART interface is disabled and must first be activated by sending a low pulse
            await this._deviceCommunication.SendAsync([0xFF]);

            var commandBytes = CommandHelper.BuildCommand(Sps30Command.WakeUp, []);
            await this.SendCommandAsync(commandBytes, cancellationToken);
        }

        /// <summary>
        /// Read Version
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<VersionResponse?> ReadVersionAsync(CancellationToken cancellationToken = default)
        {
            var commandBytes = CommandHelper.BuildCommand(Sps30Command.ReadVersion, []);
            var sendCommandResult = await this.SendCommandAsync(commandBytes, cancellationToken);

            if (sendCommandResult.CommandResponse is VersionResponse versionResponse)
            {
                return versionResponse;
            }

            return null;
        }

        /// <summary>
        /// Start Fan Cleaning
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task StartFanCleaningAsync(CancellationToken cancellationToken = default)
        {
            var commandBytes = CommandHelper.BuildCommand(Sps30Command.StartFanCleaning, []);
            await this.SendCommandAsync(commandBytes, cancellationToken);
        }
    }
}
