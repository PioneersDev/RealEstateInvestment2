using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using RealEstateInvestment.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RealEstateInvestment.CLS
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {

        public CustomAuthorizeAttribute(string roleSelector)
        {
            Roles = GetRoles(roleSelector);
        }

        private string GetRoles(string roleSelector)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            var menues = context.Menus.Where(a => a.MenuName.ToLower().Contains(roleSelector.ToLower())).Select(s => s.MenuId).ToList();
            var roles = context.RoleMenus.Where(a => menues.Contains(a.MenuId)).Select(s => roleManager.FindById(s.RoleId).Name).ToList();

            string AuthorizedRoles = string.Empty;
            for (int i = 0; i < roles.Count(); i++)
            {
                if (i == 0)
                    AuthorizedRoles = roles[i];
                else
                    AuthorizedRoles += "," + roles[i];
            }
            return AuthorizedRoles;
        }
    }
}
