using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Meetup.Models.EventIntro;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;

namespace Meetup.Controllers.Business.EventList
{
    public class EventListController : Controller
    {
        // GET: EventList
        public ActionResult ListOfEvents()
        {

            var item = RenderingContext.Current.ContextItem;
            List<EventDetails> listOfEvents = new List<EventDetails>();
            if (item?.TemplateID.ToString() != "{02A9BA7C-253C-4903-B441-E8577A55FE9E}")
                return null;

            var events = item.GetChildren();

            foreach (Item e in events)
            {
                EventDetails eventItem = new EventDetails();
                eventItem.ContentHeading = new HtmlString(FieldRenderer.Render(e, "ContentHeading"));
                eventItem.EventImage = new HtmlString(FieldRenderer.Render(e, "DecorationBanner", "class='img-responsive'&mw=333 mh=500"));
                var link = LinkManager.GetItemUrl(e).ToString();
                eventItem.ContentBody = new HtmlString(link);
                listOfEvents.Add(eventItem);

            }

            return View(listOfEvents);
        }
    }
}
