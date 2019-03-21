using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateInvestment.Models;


namespace RealEstateInvestment.CLS
{
    public class MenuLogic
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public void setChlids(MenuTree Menu)
        {
            var Childs = context.Menus.Where(a => a.MainMenu == Menu.id).ToList();
            for (int i = 0; i < Childs.Count; i++)
            {
                MenuTree ChildMENU = new MenuTree() { id = Childs[i].MenuId, flagUrl = Childs[i].MenuName, text = Childs[i].MenuText };
                Menu.nodes.Add(ChildMENU);
                setChlids(ChildMENU);
            }
        }
        public List<MenuTree> getMainMenuesWithChilds()
        {
            var MainMenuesFromDB = context.Menus.Where(a => a.MainMenu == -1).ToList();
            List<MenuTree> MainMenues = new List<MenuTree>();
            for (int i = 0; i < MainMenuesFromDB.Count; i++)
            {
                MenuTree MENU = new MenuTree() { id = MainMenuesFromDB[i].MenuId, flagUrl = MainMenuesFromDB[i].MenuName, text = MainMenuesFromDB[i].MenuText };
                MainMenues.Add(MENU);
                setChlids(MENU);
            }
            return MainMenues;
        }
        public MenuTree getFullMenu(MenuTree Menu)
        {
            var MainMenu = context.Menus.Where(a => a.MenuId == Menu.MainMenu).FirstOrDefault();
            MenuTree MainTree = new MenuTree() { id = MainMenu.MenuId, text = MainMenu.MenuText, flagUrl = MainMenu.MenuName, MainMenu = MainMenu.MainMenu };
            MainTree.nodes.Add(Menu);
            if (MainMenu.MainMenu == -1)
            {
                return MainTree;
            }
            else
            {
                return getFullMenu(MainTree);
            }

        }
        public MenuTree GetFullMenuTree(int menuId)
        {
            var MenuFromDB = context.Menus.Where(a => a.MenuId == menuId).FirstOrDefault();
            MenuTree MENU = new MenuTree() { id = MenuFromDB.MenuId, text = MenuFromDB.MenuText, flagUrl = MenuFromDB.MenuName };
            setChlids(MENU);
            return MENU;

        }
        public void SaveChanges(MenuTree tree1, MenuTree tree2)
        {
            MenuTree SameMenu = null;
            for (int i = 0; i < tree1.nodes.Count; i++)
            {
                if (tree1.nodes[i].id == tree2.nodes[0].id)
                {
                    SameMenu = tree1.nodes[i];
                    SaveChanges(tree1.nodes[i], tree2.nodes[0]);
                }


            }
            if (SameMenu == null)
                tree1.nodes.Add(tree2.nodes[0]);


        }
        public void getNodes(MenuTree tree, List<MenuTree> list)
        {

            if (tree.nodes.Count > 0)
                foreach (var menu in tree.nodes)
                {
                    getNodes(new MenuTree() { id = menu.id, text = menu.text, flagUrl = menu.flagUrl, MainMenu = menu.MainMenu, nodes = menu.nodes, Icon = menu.Icon }, list);
                }
            else
                list.Add(new MenuTree() { id = tree.id, text = tree.text, flagUrl = tree.flagUrl, nodes = tree.nodes, MainMenu = tree.MainMenu, Icon = tree.Icon });

        }
    }
}
