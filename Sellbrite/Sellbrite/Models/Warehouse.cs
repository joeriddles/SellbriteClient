using Newtonsoft.Json;

namespace Sellbrite.Models
{
	public class Warehouse
	{
		public string Uuid { get; set; }
		public string Name { get; set; }
		[JsonProperty(PropertyName = "inventory_master")]
		public string InventoryMaster { get; set; }
		[JsonProperty(PropertyName = "address_1")]
		public string Address1 { get; set; }
		[JsonProperty(PropertyName = "address_2")]
		public string Address2 { get; set; }
		public string City { get; set; }
		[JsonProperty(PropertyName = "state_region")]
		public string StateRegion { get; set; }
		[JsonProperty(PropertyName = "postal_code")]
		public string PostalCode { get; set; }
		[JsonProperty(PropertyName = "country_code")]
		public string CountryCode { get; set; }
		public bool Archived { get; set; }
	}
}
