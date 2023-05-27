using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meetup.Models.Navigation
{
    public class BreadcrumbBuilder
    {
		public BreadcrumbBuilder()
		{
			Breadcrumb = new List<NavigationItem>();
		}
		public List<NavigationItem> Breadcrumb { get; set; }
	}
}