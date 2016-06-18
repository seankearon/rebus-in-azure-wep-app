using System.Web.Http;

namespace rebus_in_azure_web_app
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(AutofacConfig.Register);
            GlobalConfiguration.Configuration.EnsureInitialized();
        }
    }
}
