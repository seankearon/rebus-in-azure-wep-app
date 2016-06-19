using System.Web.Http;
using rebus_in_azure_web_app.Monitoring;

namespace rebus_in_azure_web_app.Controllers
{
    public class HeartbeatController: ApiController
    {
        [HttpGet]
        [Route("heartbeat")]
        public string Heartbeat()
        {
            return Heart.Report();
        }
    }
}