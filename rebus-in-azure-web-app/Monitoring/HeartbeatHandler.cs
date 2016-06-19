using System.Threading.Tasks;
using Rebus.Handlers;

namespace rebus_in_azure_web_app.Monitoring
{
    internal class HeartbeatHandler : IHandleMessages<Heartbeat>
    {
        public async Task Handle(Heartbeat h)
        {
            await Task.Run(() =>
            {
                Heart.Beat();
            });
        }
    }
}