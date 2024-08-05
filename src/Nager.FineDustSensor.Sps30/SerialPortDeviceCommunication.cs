using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.IO.Ports;

namespace Nager.FineDustSensor.Sps30
{
    /// <summary>
    /// SerialPort DeviceCommunication
    /// </summary>
    public class SerialPortDeviceCommunication : IDeviceCommunication
    {
        private readonly ILogger<SerialPortDeviceCommunication> _logger;
        private readonly string _portName;
        private readonly SerialPort _serialPort;
        private readonly List<byte> _receiveBuffer = new List<byte>();

        /// <inheritdoc />
        public event Action<byte[]>? DataReceived;

        /// <inheritdoc />
        public event Action<byte[]>? DataSent;

        /// <inheritdoc />
        public event Action<ConnectionState>? ConnectionStateChanged;

        /// <summary>
        /// SerialPort DeviceCommunication
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="baudRate"></param>
        /// <param name="parity"></param>
        /// <param name="dataBits"></param>
        /// <param name="stopBits"></param>
        /// <param name="logger"></param>
        public SerialPortDeviceCommunication(
            string portName,
            int baudRate = 115200,
            Parity parity = Parity.None,
            int dataBits = 8,
            StopBits stopBits = StopBits.One,
            ILogger<SerialPortDeviceCommunication>? logger = default)
        {
            this._portName = portName;

            if (logger == null)
            {
                logger = new NullLogger<SerialPortDeviceCommunication>();
            }
            this._logger = logger;

            this._serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
            this._serialPort.DataReceived += this.Receive;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (disposing)
            {
                this._serialPort.DataReceived -= this.Receive;
                this._serialPort.Dispose();
            }
        }

        /// <inheritdoc />
        public bool IsConnected
        {
            get { return this._serialPort.IsOpen; }
        }

        /// <inheritdoc />
        public string ConnectionIdentifier
        {
            get { return this._portName; }
        }

        /// <inheritdoc />
        public Task<bool> ConnectAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                this._logger.LogInformation($"{nameof(ConnectAsync)} - PortName:{this._portName}");

                this._serialPort.Open();

                return Task.FromResult(this._serialPort.IsOpen);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"{nameof(ConnectAsync)} - {exception}");
            }

            return Task.FromResult(false);
        }

        /// <inheritdoc />
        public Task<bool> DisconnectAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                this._serialPort.Close();
                return Task.FromResult(true);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"{nameof(DisconnectAsync)} - {exception}");
            }

            return Task.FromResult(false);
        }

        private void Disconnected()
        {
            this._logger.LogInformation($"{nameof(Disconnected)}");

            this.ConnectionStateChanged?.Invoke(ConnectionState.Disconnected);
        }

        /// <inheritdoc />
        public Task<bool> SendAsync(
            byte[] data,
            CancellationToken cancellationToken = default)
        {
            this.DataSent?.Invoke(data);

            if (this._logger.IsEnabled(LogLevel.Debug))
            {
                this._logger.LogDebug($"{nameof(SendAsync)} - {BitConverter.ToString(data)}");
            }

            this._serialPort.Write(data, 0, data.Length);

            return Task.FromResult(true);
        }

        private void Receive(object sender, SerialDataReceivedEventArgs e)
        {
            var buffer = new byte[this._serialPort.BytesToRead];

            this._serialPort.Read(buffer, 0, buffer.Length);
            this.DataReceived?.Invoke(buffer);
        }
    }
}
