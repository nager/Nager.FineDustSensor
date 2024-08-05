namespace Nager.FineDustSensor.Sps30.Responses
{
    public class VersionResponse : ICommandResponse
    {
        public int FirmwareMajorVersion { get; set; }
        public int FirmwareMinorVersion { get; set; }
        public int HardwareRevision { get; set; }
        public int ShdlcProtocolMajorVersion { get; set; }
        public int ShdlcProtocolMinorVersion { get; set; }
    }
}
