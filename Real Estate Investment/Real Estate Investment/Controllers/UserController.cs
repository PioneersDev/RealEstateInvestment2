using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using RealEstateInvestment.CLS;
using RealEstateInvestment.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RealEstateInvestment.Controllers
{
    [CustomAuthorize("User")]
    public class UserController : Controller
    {
        
        ApplicationDbContext _erpContext = new ApplicationDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        public UserController()
        {
        }

        public UserController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        public ActionResult Index()
        {
            var users = _erpContext.Users.ToList();
            return View(users);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int userId)
        {
            if (userId == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                //get User Data from Userid
                var user = await UserManager.FindByIdAsync(userId);

                //List Logins associated with user
                var logins = user.Logins;

                //Gets list of Roles associated with current user
                var rolesForUser = await UserManager.GetRolesAsync(userId);

                using (var transaction = _erpContext.Database.BeginTransaction())
                {
                    foreach (var login in logins.ToList())
                    {
                        await UserManager.RemoveLoginAsync(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                    }

                    if (rolesForUser.Count() > 0)
                    {
                        foreach (var item in rolesForUser.ToList())
                        {
                            // item should be the name of the role
                            var result = await UserManager.RemoveFromRoleAsync(user.Id, item);
                        }
                    }

                    //Delete User
                    await UserManager.DeleteAsync(user);
                    return Json(new { }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Error occurred while deleting user: {0}", ex.ToString());
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        public ActionResult Edit(int userId)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var user = UserManager.FindById(userId);
            var userRole = user.Roles.FirstOrDefault().RoleId;
            var RoleName = context.Roles.Where(a => a.Id == userRole).FirstOrDefault().Name;
            var userApplicationId = context.RoleApplications.Where(r => r.RoleId == userRole).Select(a => a.ApplicationId).FirstOrDefault();
            var returnedObj = new EditUserModel { user = user, userRole = RoleName, userApplicationId = userApplicationId };
            ViewBag.apps = context.Applications.ToList();
            ViewBag.Roles = RoleManager.Roles.ToList();
            return View(returnedObj);
        }

        [HttpPost]
        public ActionResult Edit(EditUserModel model)
        {
            var user =UserManager.FindById(model.user.Id);
            user.UserName = model.user.UserName;
            //user.DomainUser = model.user.DomainUser;
            //user.MachineName = model.user.MachineName;
            //user.Machine_Ip = model.user.Machine_Ip;
            UserManager.Update(user);

            var roles =  UserManager.GetRoles(user.Id);
            UserManager.RemoveFromRoles(user.Id, roles.ToArray());
            UserManager.AddToRole(user.Id, model.userRole);

            return RedirectToAction("Index");
        }
        public ActionResult ResetPassword(int userid)
        {
            if (userid == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminResetPasswordViewModel model = new AdminResetPasswordViewModel() { Id = userid };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(AdminResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var removePassword = UserManager.RemovePassword(model.Id);
            if (removePassword.Succeeded)
            {
                //Removed Password Success
                var AddPassword = UserManager.AddPassword(model.Id, model.NewPassword);
                if (AddPassword.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
    public class BranchListedData
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
    }
    public class AccountMangerListedData
    {
        public int AccountManagerId { get; set; }
        public string AccountManagerName { get; set; }
    }
}