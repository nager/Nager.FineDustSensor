using Nager.FineDustSensor.Sps30.Responses;

namespace Nager.FineDustSensor.Sps30.Models
{
    internal class SendCommandResult
    {
        public bool SendSuccessful { get; set; }
        public ICommandResponse? CommandResponse { get; set; }
    }
}
