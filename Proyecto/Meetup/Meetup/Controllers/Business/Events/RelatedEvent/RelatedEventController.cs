using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using Sitecore.Links;
using Sitecore.Data.Items;
using Meetup.Models.Navigation;
using Meetup.Models.EventIntro;

namespace Meetup.Controllers.Business.RelatedEvent
{
    public class RelatedEventController : Controller
    {
		// GET: RelatedEvent
		// GET: RelatedEvents
		public ActionResult RelatedEvents()

		{
			List<NavigationItem> eventsList = new List<NavigationItem>();
			var item = RenderingContext.Current.ContextItem;
			Sitecore.Data.Fields.MultilistField multiselectField = item.Fields["related"];
			Sitecore.Data.Items.Item[] items = multiselectField.GetItems();
			if (items != null && items.Length > 0)
			{
				for (int i = 0; i < items.Length; i++)
				{
					//Allocate memory to the model
					var relatedEvent = new NavigationItem();

					Sitecore.Data.Items.Item eventitem = items[i];
					relatedEvent.Title = eventitem.DisplayName;
					relatedEvent.Url = LinkManager.GetItemUrl(eventitem);

					eventsList.Add(relatedEvent);
				}
			}

			return View(eventsList);
		}

		public ActionResult UpcomindEvents()

		{
			return View();
		}
		public ActionResult ListEvents()
		{
			List<EventDetails> listOfEvents = new List<EventDetails>();
			EventDetails currentEvent;
			var item = RenderingContext.Current.ContextItem;
			List<Item> events = item.GetChildren().ToList();
			foreach (Item i in events)
			{
				currentEvent = new EventDetails();
				currentEvent.ContentBody = new HtmlString(FieldRenderer.Render(i, "ContentBody"));
				currentEvent.ContentHeading = new HtmlString(FieldRenderer.Render(i, "ContentHeading"));
				currentEvent.StartDate = new HtmlString(FieldRenderer.Render(i, "StartDate"));
				currentEvent.EventImage = new HtmlString(FieldRenderer.Render(i, "EventImage", "width=150&height=100"));
				currentEvent.ContentIntro = new HtmlString(LinkManager.GetItemUrl(i).ToString());

				listOfEvents.Add(currentEvent);
			}

			return View(listOfEvents);
		}

	}
}
