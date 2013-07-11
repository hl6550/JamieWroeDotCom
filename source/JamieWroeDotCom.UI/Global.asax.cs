using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using JamieWroeDotCom.UI.App_Start;
using WebMatrix.WebData;

namespace JamieWroeDotCom.UI
{
    // Note: For instructions on enabling IIS7 classic mode, 
    // visit http://go.microsoft.com/fwlink/?LinkId=301868
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "Users", "Id", "UserName", true);

            NinjectHelper.ConfigureNinject();

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}