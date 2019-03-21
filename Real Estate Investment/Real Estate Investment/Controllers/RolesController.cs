using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstateInvestment.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RealEstateInvestment.CLS;
using Microsoft.AspNet.Identity.Owin;

namespace RealEstateInvestment.Controllers
{
    [CustomAuthorize("Roles")]
    public class RolesController : Controller
    {

        #region userManager
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        public RolesController()
        {
        }

        public RolesController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
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

        ApplicationDbContext Context = new ApplicationDbContext();
        // GET: Roles
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roles = Context.RoleApplications.ToList().Select(a => new { Id = a.RoleId, Name = RoleManager.FindById(a.RoleId).Name, Application = Context.Applications.Where(ap => ap.Id == a.ApplicationId).FirstOrDefault().ApplicationName }).ToList();

            return Json(new { data = roles }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddNew()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var Applications = context.Applications.ToList();

            ViewBag.apps = new SelectList(Applications, "Id", "ApplicationName");
            return View();
        }
        [HttpPost]
        public ActionResult AddNew(RoleViewModel model)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            if (!RoleManager.RoleExists(model.Name))
            {
                var role = new ApplicationRole();
                role.Name = model.Name;
                RoleManager.Create(role);
                
               
                RoleApplication RoleApp = new RoleApplication();
                RoleApp.RoleId = RoleManager.FindByName(role.Name).Id;
                RoleApp.ApplicationId = model.ApplicationId;
                context.RoleApplications.Add(RoleApp);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public PartialViewResult Edit(int id)
        {
            ViewBag.Id = id;
            ApplicationDbContext context = new ApplicationDbContext();
            var Role =  RoleManager.Roles.Where(a => a.Id == id).FirstOrDefault();
            return PartialView();
        }
        public ActionResult Get(int id)
        {
            var RoleMenus = Context.RoleMenus.Where(a => a.RoleId == id).ToList();

            MenuLogic Logic = new MenuLogic();
            List<MenuTree> MenuList = new List<MenuTree>();
            for (int i = 0; i < RoleMenus.Count; i++)
            {
                int x = RoleMenus[i].MenuId;
                var menu = Context.Menus.Where(a => a.MenuId == x).FirstOrDefault();

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
            //var tree = MenuList.Select()
            return Json(MenuList, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult EditRoleTree(int RoleId, MenuTree tree)
        {
            var RoleMenus = Context.RoleMenus.Where(a => a.RoleId == RoleId).ToList();
            MenuLogic Logic = new MenuLogic();
            List<MenuTree> MenuList = new List<MenuTree>();
            try
            {
                List<MenuTree> listtree = new List<MenuTree>();
                Logic.getNodes(tree, listtree);
                foreach (MenuTree t in listtree)
                {
                    Context.RoleMenus.Add(new RoleMenu() { MenuId = t.id, RoleId = RoleId });
                }
                Context.SaveChanges();
            }
            catch 
            {
                return Json(new { success = false });
            }

            for (int i = 0; i < RoleMenus.Count; i++)
            {
                int x = RoleMenus[i].MenuId;
                var menu = Context.Menus.Where(a => a.MenuId == x).FirstOrDefault();

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

            MenuTree FullTree2 = Logic.getFullMenu(new MenuTree() { MainMenu = tree.MainMenu, id = tree.id, text = tree.text, flagUrl = tree.flagUrl, nodes = tree.nodes });
            var sameMainMenu2 = (from a in MenuList where a.id == FullTree2.id select a).FirstOrDefault();

            if (sameMainMenu2 != null)
            {
                Logic.SaveChanges(sameMainMenu2, FullTree2);
            }
            else
            {
                MenuList.Add(FullTree2);
            }
            //var tree = MenuList.Select()
            return Json(MenuList, JsonRequestBehavior.AllowGet);

        }
        public ActionResult getAllMenus()
        {
            var RoleMenus = Context.Menus.Where(a => a.MenuName != " " && a.MenuName != null && a.MenuName != string.Empty).ToList();
            MenuLogic Logic = new MenuLogic();
            List<MenuTree> MenuList = new List<MenuTree>();
            for (int i = 0; i < RoleMenus.Count; i++)
            {
                int x = RoleMenus[i].MenuId;
                var menu = Context.Menus.Where(a => a.MenuId == x).FirstOrDefault();

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
            //var tree = MenuList.Select()
            return Json(MenuList, JsonRequestBehavior.AllowGet);

        }
        public ActionResult RemoveTree(int RoleId, MenuTree tree)
        {

            MenuLogic Logic = new MenuLogic();
            List<MenuTree> MenuList = new List<MenuTree>();
            try
            {
                List<MenuTree> listtree = new List<MenuTree>();
                Logic.getNodes(tree, listtree);
                foreach (MenuTree t in listtree)
                {
                    var menu = Context.RoleMenus.Where(a => a.MenuId == t.id && a.RoleId == RoleId).FirstOrDefault();
                    Context.RoleMenus.Remove(menu);
                }
                Context.SaveChanges();
            }
            catch 
            {
                return Json(false);
            }
            var RoleMenus = Context.RoleMenus.Where(a => a.RoleId == RoleId).ToList();
            for (int i = 0; i < RoleMenus.Count; i++)
            {
                int x = RoleMenus[i].MenuId;
                var menu = Context.Menus.Where(a => a.MenuId == x).FirstOrDefault();

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

            //MenuTree FullTree2 = Logic.getFullMenu(new MenuTree() { MainMenu = tree.MainMenu, id = tree.id, text = tree.text, flagUrl = tree.flagUrl, nodes = tree.nodes });
            //var sameMainMenu2 = (from a in MenuList where a.id == FullTree2.id select a).FirstOrDefault();

            //if (sameMainMenu2 != null)
            //{
            //    Logic.SaveChanges(sameMainMenu2, FullTree2);
            //}
            //else
            //{
            //    MenuList.Add(FullTree2);
            //}
            //var tree = MenuList.Select()
            return Json(MenuList, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            RoleManager.Delete(RoleManager.Roles.Where(a => a.Id == id).FirstOrDefault());
            context.RoleApplications.Remove(context.RoleApplications.Where(a => a.RoleId == id).FirstOrDefault());
            context.SaveChanges();
            return Json(true);

        }
        [HttpPost]
        public ActionResult Save ( string RoleId,  MenuTree tree)
        {
           return RedirectToAction("Index");
        }
    }
}