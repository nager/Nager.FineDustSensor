using Nager.FineDustSensor.Sps30.Models;

namespace Nager.FineDustSensor.Sps30.Responses
{
    public class NoDataCommandResponse : ICommandResponse
    {
        public Sps30Command Command { get; private set; }

        public NoDataCommandResponse(Sps30Command command)
        {
            this.Command = command;
        }
    }
}
