using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meetup.Models.Navigation
{
	public class SideMenu : BreadcrumbBuilder
	{

		public SideMenu()
		{
			Node = new NavigationItem();
			itemsnav = new List<BreadcrumbBuilder>();
		}
		public NavigationItem Node { get; set; }
		public List<BreadcrumbBuilder> itemsnav { get; set; }
	}
}