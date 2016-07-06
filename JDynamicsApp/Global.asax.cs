using JDynamicsApp.App_Start;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;

namespace JDynamicsApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //DI Code
            AutofacConfig.ConfigureContainer();
            Automapper.Initialize();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
