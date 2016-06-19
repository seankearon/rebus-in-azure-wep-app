using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace rebus_in_azure_web_app
{
    public static class AutofacConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // http://autofac.readthedocs.org/en/latest/integration/webapi.html#quick-start 
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyModules(typeof(AutofacConfig).Assembly);

            var container = builder.Build();

            RebusConfig.ConfigureRebus(container);

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}