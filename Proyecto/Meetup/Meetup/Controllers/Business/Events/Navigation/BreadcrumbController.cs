using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Meetup.Models.Navigation;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data;


namespace Meetup.Controllers.Business.Events.Navigation
{
    public class BreadcrumbController : Controller
    {
        // GET: Breadcrumb
        public ActionResult Index()
        {

            BreadcrumbBuilder my = new BreadcrumbBuilder();

            ; var currentitem = LinkManager.GetItemUrl(RenderingContext.Current.ContextItem);

            Item homeItem = GetHomeItem();
            List<Item> itemsdesdehome = Sitecore.Context.Item.Axes.GetAncestors().SkipWhile(item => item.ID != homeItem.ID).ToList();

            foreach (var x in itemsdesdehome)
            {
                NavigationItem navitem = new NavigationItem();
                navitem.Url = LinkManager.GetItemUrl(x);
                navitem.Title = x.DisplayName;
                navitem.Active = false;

                my.Breadcrumb.Add(navitem);


            }
            NavigationItem currentnavitem = new NavigationItem();
            currentnavitem.Url = currentitem;
            currentnavitem.Title = RenderingContext.Current.ContextItem.DisplayName;
            currentnavitem.Active = true;
            my.Breadcrumb.Add(currentnavitem);

            return View(my);
        }
        public ActionResult sideBradcrum()
        {


            Item nodeSideMenu = Sitecore.Context.Database.GetItem(new ID("{81CF5BD6-6990-4722-84E6-02737ED3149C}"));
            List<Item> SideNavItems = nodeSideMenu.GetChildren().ToList();
            List<SideMenu> sideMenuNav = new List<SideMenu>();

            foreach (var node in SideNavItems)
            {
                SideMenu sideMenuitem = new SideMenu();
                sideMenuitem.Node.Url = LinkManager.GetItemUrl(node);
                sideMenuitem.Node.Title = node.DisplayName;
                sideMenuitem.Node.Active = RenderingContext.Current.ContextItem.ID == node.ID;
                List<Item> nodeitems = node.GetChildren().ToList();
                foreach (var item in nodeitems)
                {
                    NavigationItem currentnavitem = new NavigationItem();
                    currentnavitem.Url = LinkManager.GetItemUrl(item);
                    currentnavitem.Title = item.DisplayName;
                    var activeparent = item.Parent;

                    sideMenuitem.Node.Active = sideMenuitem.Node.Active ? sideMenuitem.Node.Active : RenderingContext.Current.ContextItem.Parent.ID == node.ID;
                    sideMenuitem.Breadcrumb.Add(currentnavitem);
                }
                sideMenuNav.Add(sideMenuitem);

            }
            return View(sideMenuNav);
        }

        public Item GetHomeItem()
        {


            string homePath = Sitecore.Context.Site.StartPath;
            Item homeItem = Sitecore.Context.Database.GetItem(homePath);

            return homeItem;
        }

        public bool IsActive(Item subnode)
        {

            var currentintemparent = RenderingContext.Current.ContextItem.Parent;


            return subnode.ID == currentintemparent.ID;
        }


    }
}
