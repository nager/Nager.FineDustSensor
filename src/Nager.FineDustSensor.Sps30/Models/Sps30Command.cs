namespace Nager.FineDustSensor.Sps30.Models
{
    /// <summary>
    /// Sps30 Commands
    /// </summary>
    public enum Sps30Command : byte
    {
        StartMeasurement = 0x00,
        StopMeasurement = 0x01,
        ReadMeasuredValue = 0x03,
        Sleep = 0x10,
        WakeUp = 0x11,
        StartFanCleaning = 0x56,
        ReadWriteAutoCleaningInterval = 0x80,
        DeviceInformation = 0xD0,
        ReadVersion = 0xD1,
        ReadDeviceStatusRegister = 0xD2,
        Reset = 0xD3
    };
}
