using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NLog;

namespace RentABike.Website
{
    public class MvcApplication : HttpApplication
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            logger.Info("Application Start");
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Context.Error; 
            logger.Log(LogLevel.Debug, ex);
        }
    }
}