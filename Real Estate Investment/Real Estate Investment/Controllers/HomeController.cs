using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using RealEstateInvestment.Models;
using RealEstateInvestment.CLS;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RealEstateInvestment.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        #region userManager
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        public HomeController()
        {
        }

        public HomeController(ApplicationUserManager userManager, ApplicationRoleManager roleManager, ApplicationSignInManager signInManager)
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
        #endregion
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: true);
            switch (result)
            {
                case SignInStatus.Success:
                    {
                        var userId = User.Identity.GetUserId<int>();
                        Session["UserId"] = userId;
                        Session["UserName"] = model.UserName;
                        Session["Menu"] = null;
                        return RedirectToLocal(returnUrl);
                    }
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "محاولة تسجيل دخول غير صحيحة");
                    return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View("Login", model);
        }

        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
        public ActionResult RenderMenu()
        {
            List<MenuTree> MenuList = new List<MenuTree>();
            if (Session["Menu"] == null)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                //int UserId = int.Parse(Session["UserId"].ToString());
                var CurrentUser = User.Identity.GetUserId<int>();
                var user = UserManager.FindById(CurrentUser);
                string RoleName = UserManager.GetRoles(user.Id).FirstOrDefault();


                //var roles = UserManager.GetRoles(user.Id);
                int RoleId = RoleManager.FindByName(RoleName).Id;
                var RoleMenus = context.RoleMenus.Where(a => a.RoleId == RoleId).ToList();

                MenuLogic Logic = new MenuLogic();
                for (int i = 0; i < RoleMenus.Count; i++)
                {
                    int x = RoleMenus[i].MenuId;
                    var menu = context.Menus.Where(a => a.MenuId == x).FirstOrDefault();

                    MenuTree FullTree = Logic.getFullMenu(new MenuTree() { MainMenu = menu.MainMenu, id = menu.MenuId, text = menu.MenuText, flagUrl = menu.MenuName });
                    var sameMainMenu = (from a in MenuList where a.id == FullTree.id select a).FirstOrDefault();

                    if (sameMainMenu != null)
                    {
                        Logic.SaveChanges(sameMainMenu, FullTree);
                    }
                    else
                    {
                        MenuList.Add(FullTree);
                    }
                    //int MainMenu = Logic.getMainMenuId(RoleMenus[i].MenuId);
                    //MenuTree FullMenuTree = Logic.GetFullMenuTree(MainMenu);
                }
                Session["Menu"] = MenuList;
            }
            return View(Session["Menu"] as List<MenuTree>);
        }
        public ActionResult getRoles(int id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var Roles = context.RoleApplications.Where(a => a.ApplicationId == id).Select(b => new { Id = b.RoleId, Name = RoleManager.FindById(b.RoleId).Name }).ToList();

            SelectList roles = new SelectList(Roles, "Name", "Name");
            ViewBag.roles = roles;
            return PartialView();
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult FirstUse(string returnUrl)
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        public ActionResult AddToGroupSignalr(string connectionId)
        {
            try
            {
                var CurrentUser = User.Identity.GetUserId<int>();
                var user = UserManager.FindById(CurrentUser);
                string RoleName = UserManager.GetRoles(user.Id).FirstOrDefault();
                NotificationHub._instance.addToGroup(RoleName, connectionId);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch { return Json(false, JsonRequestBehavior.AllowGet); }

        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}
