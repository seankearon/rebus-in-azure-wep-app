using System;
using System.Timers;
using Autofac;
using rebus_in_azure_web_app.Monitoring;
using Rebus.Bus;
using Rebus.Handlers;

namespace rebus_in_azure_web_app.IoC
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder b)
        {
            base.Load(b);
            b.RegisterAssemblyTypes(GetType().Assembly)
                .Where(IsRebusHandler)
                .AsImplementedInterfaces();

            // Heartbeat timer.
            b.Register(c =>
            {
                var bus = c.Resolve<IBus>();
                var timer = new Timer();
                timer.Elapsed += delegate { bus.Send(new Heartbeat { Details = "My heart is beating!" }).Wait(); };
                timer.Interval = 5000;
                return timer;
            }).Named<Timer>("heartbeat");
        }

        private bool IsRebusHandler(Type t)
        {
            return typeof(IHandleMessages).IsAssignableFrom(t);
        }
    }
}