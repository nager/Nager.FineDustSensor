using Microsoft.Extensions.Logging;
using Nager.FineDustSensor.Sps30;

/*
 * https://sensirion.com/media/documents/8600FF88/64A3B8D6/Sensirion_PM_Sensors_Datasheet_SPS30.pdf
 */

using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.SetMinimumLevel(LogLevel.Warning);
    builder.AddConsole();
});

try
{
    using var deviceCommunication = new SerialPortDeviceCommunication("COM5");

    using var sps30Client = new Sps30Client(deviceCommunication, loggerFactory.CreateLogger<Sps30Client>());
    await deviceCommunication.ConnectAsync();

    await sps30Client.StopMeasurementAsync();
    await Task.Delay(1000);

    //Console.WriteLine("Start Fan Cleaning");
    //await sps30Client.StartMeasurementAsync();
    //await Task.Delay(1000);
    //await sps30Client.StartFanCleaningAsync();
    //await Task.Delay(10000);

    Console.WriteLine("Read Version");
    var versionResponse = await sps30Client.ReadVersionAsync();
    if (versionResponse != null)
    {
        Console.WriteLine($"Firmware V{versionResponse.FirmwareMajorVersion}.{versionResponse.FirmwareMinorVersion}, Hardware V{versionResponse.HardwareRevision}, SHDLC V{versionResponse.ShdlcProtocolMajorVersion}.{versionResponse.ShdlcProtocolMinorVersion}");
    }

    await Task.Delay(1000);

    Console.WriteLine("Start Measurement");
    await sps30Client.StartMeasurementAsync();

    var startDelay = 5000;
    Console.WriteLine($"Wait {startDelay / 1000}s until the first measurement");
    await Task.Delay(startDelay);

    Console.WriteLine($"  PM1  |  PM2.5 | PM4");

    for (var i = 0; i < 1000; i++)
    {
        var measurementResponse = await sps30Client.ReadMeasuredValuesAsync();
        if (measurementResponse != null)
        {
            Console.WriteLine($"{measurementResponse.MassConcentrationPm1:00.000} | {measurementResponse.MassConcentrationPm2_5:00.000} | {measurementResponse.MassConcentrationPm4:00.000}");
        }
                
        await Task.Delay(1000);
    }

    await sps30Client.StopMeasurementAsync();

    Console.WriteLine("Press any key for quit");
    Console.ReadLine();

    await deviceCommunication.DisconnectAsync();
}
catch (Exception ex)
{
    Console.WriteLine("Fehler: " + ex.Message);
}
