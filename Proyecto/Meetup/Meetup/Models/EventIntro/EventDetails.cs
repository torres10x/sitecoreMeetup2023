﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meetup.Models.EventIntro
{
    public class EventDetails
    {
		public HtmlString ContentHeading { get; set; }
		public HtmlString ContentBody { get; set; }
		public HtmlString ContentIntro { get; set; }
		public HtmlString EventImage { get; set; }
		public HtmlString Highlights { get; set; }
		public HtmlString StartDate { get; set; }
		public HtmlString Duration { get; set; }
		public HtmlString DifficultyLevel { get; set; }

	}
}