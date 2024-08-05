using Nager.FineDustSensor.Sps30.Models;

namespace Nager.FineDustSensor.Sps30.Helpers
{
    public static class CommandHelper
    {
        private const byte StartStopCharacter = 0x7E;

        public static byte[] BuildCommand(Sps30Command command, byte[] data)
        {
            // 00-00-00-00-00-00-00-00
            // |  |  |  |  |  |  |  |
            // |  |  |  |  |  |  |  └───── Stop
            // |  |  |  |  |  |  └──────── Checksum     
            // |  |  |  |  |  └─────────── Data
            // |  |  |  |  └────────────── Data
            // |  |  |  └───────────────── Length L
            // |  |  └──────────────────── Command CMD
            // |  └─────────────────────── Address ADR
            // └────────────────────────── Start

            if (data.Length > 254)
            {
                throw new Exception("Data length to long");
            }

            byte deviceAddress = 0x00;
            byte commandId = (byte)command;
            byte dataLength = (byte)data.Length;

            using var memoryStreamFrameContent = new MemoryStream();
            memoryStreamFrameContent.WriteByte(deviceAddress); //Address
            memoryStreamFrameContent.WriteByte(commandId);
            memoryStreamFrameContent.WriteByte(dataLength);
            memoryStreamFrameContent.Write(data, 0, data.Length);
            var package = memoryStreamFrameContent.ToArray();

            byte checksum = ChecksumHelper.CalculateChecksum(package);

            using var memoryStreamMosiFrame = new MemoryStream();
            memoryStreamMosiFrame.WriteByte(StartStopCharacter);
            memoryStreamMosiFrame.Write(package, 0, package.Length);
            memoryStreamMosiFrame.WriteByte(checksum);
            memoryStreamMosiFrame.WriteByte(StartStopCharacter);
            return memoryStreamMosiFrame.ToArray();
        }
    }
}
