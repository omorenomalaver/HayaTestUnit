using System;

// Created: Daniel Swain
// 
// This represents a custom object for holding the navigation menu items in our nav list.
namespace HayaTestUnit.Models
{
	public class MasterPageItem
	{
		// The title for the detail page (i.e. the menu item).
		public string Title { get; set; }

		// The type of the detail page.
		public Type TargetType { get; set; }
	}
}
