using System;

namespace rebus_in_azure_web_app.Monitoring
{
    public class Heartbeat
    {
        public Heartbeat()
        {
            TimestampUtc = DateTime.UtcNow;
        }

        public string Details { get; set; }
        public DateTime TimestampUtc { get; set; }
    }
}