using System;

namespace rebus_in_azure_web_app.Monitoring
{
    public static class Heart
    {
        public static long Beats;
        public static DateTime LastRefresh = DateTime.UtcNow;

        public static void Beat()
        {
            if (Beats < long.MaxValue)
            {
                Beats++;
            }
            else
            {
                Beats = 0;
                LastRefresh = DateTime.UtcNow;
            }
        }

        public static string Report()
        {
            return $"Heart beats {Beats}, last refreshed {LastRefresh} (UTC).";
        }
    }
}