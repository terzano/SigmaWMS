using System.Web.Mvc;

namespace Sigma.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {

            context.MapRoute(
               "Admin_default",
               "Admin/{culture}/{controller}/{action}/{id}",
               new
               {
                   culture = System.Threading.Thread.CurrentThread.CurrentCulture.Name,
                   controller = "Home",
                   action = "Index",
                   id = UrlParameter.Optional
               },
               new[] { "Sigma.Web.Areas.Admin.Controllers" }
            );

        }
    }
}
