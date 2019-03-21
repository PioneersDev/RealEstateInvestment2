using System.Web.Mvc;

namespace RealEstateInvestment.Areas.RealEstate
{
    public class RealEstateAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "RealEstate";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "RealEstate_default",
                "RealEstate/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}