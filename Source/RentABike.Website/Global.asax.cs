using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RentABike.Website
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ////// DI
            //NinjectRegistrationsModule registrations = new NinjectRegistrationsModule();
            //StandardKernel kernel = new StandardKernel(registrations);
            //DependencyResolver.SetResolver(new NInjectDependencyResolver(kernel));
        }
    }
}