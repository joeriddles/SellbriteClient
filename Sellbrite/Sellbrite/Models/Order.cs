using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Sellbrite.Models
{
	public class Order
	{
		[JsonProperty(PropertyName = "display_ref")]
		public string DisplayRef { get; set; }
		[JsonProperty(PropertyName = "shipping_email")]
		public string ShippingEmail { get; set; }

		public List<Item> Items { get; set; }
	}

	public class Item
	{
		[JsonProperty(PropertyName = "order_item_ref")]
		public string OrderItemRef { get; set; }
		public long Quantity { get; set; }
		public string Title { get; set; }
	}
}
