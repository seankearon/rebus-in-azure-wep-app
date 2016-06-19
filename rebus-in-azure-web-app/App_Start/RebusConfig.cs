using System.Timers;
using Autofac;
using rebus_in_azure_web_app.Monitoring;
using Rebus.Autofac;
using Rebus.Config;
using Rebus.Routing.TypeBased;

namespace rebus_in_azure_web_app
{
    public static class RebusConfig
    {
        public static void ConfigureRebus(IContainer container)
        {
            var adapter = new AutofacContainerAdapter(container);

            Configure.With(adapter)
                .Logging(l => l.None())
                .Transport(t => t
                    .UseAzureServiceBus("PUT YOUR AZURE SERVICE BUS CONNECTION STRING OR NAME HERE", "my-rebus-queue")
                    .AutomaticallyRenewPeekLock())
                // .Transport(x => x.UseFileSystem(@"c:\rebus", "my-rebus-queue"))
                .Routing(r => r.TypeBased().Map<Heartbeat>("my-rebus-queue"))
                .Start();

            var timer = container.ResolveKeyed<Timer>("heartbeat");
            timer.Start();
        }
    }
}