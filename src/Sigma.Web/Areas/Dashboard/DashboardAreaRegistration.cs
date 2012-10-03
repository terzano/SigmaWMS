using System.Web.Mvc;

namespace Sigma.Web.Areas.Dashboard
{
    public class DashboardAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Dashboard";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {

            context.MapRoute(
               "Dashboard_default",
               "Dashboard/{culture}/{controller}/{action}/{id}",
               new
               {
                   culture = System.Threading.Thread.CurrentThread.CurrentCulture.Name,
                   controller = "Home",
                   action = "Index",
                   id = UrlParameter.Optional
               },
               new[] { "Sigma.Web.Areas.Dashboard.Controllers" }
            );

        }
    }
}
