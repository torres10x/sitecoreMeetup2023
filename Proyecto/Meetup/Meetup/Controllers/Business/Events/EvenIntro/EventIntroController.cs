using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Meetup.Models.EventIntro;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;

namespace Meetup.Controllers.Business.EvenIntro
{
    public class EventIntroController : Controller
    {
        // GET: EventIntro
        public ActionResult Index()        {
           
            return View(CreateModel());            
        }

        public static EventDetails CreateModel()
        {
            var item = RenderingContext.Current.ContextItem;
            return new EventDetails()
            {
                ContentHeading = new HtmlString(FieldRenderer.Render(item, "ContentHeading")),
                ContentBody = new HtmlString(FieldRenderer.Render(item, "ContentBody")),
                EventImage = new HtmlString(FieldRenderer.Render(item, "EventImage", "mw=400")),
                Highlights = new HtmlString(FieldRenderer.Render(item, "Highlights")),
                ContentIntro = new HtmlString(FieldRenderer.Render(item, "ContentIntro")),
                StartDate = new HtmlString(FieldRenderer.Render(item, "StartDate")),
                Duration = new HtmlString(FieldRenderer.Render(item, "Duration")),
                DifficultyLevel = new HtmlString(FieldRenderer.Render(item, "DifficultyLevel"))
            };
        }
    }
}