using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Sellbrite.Models
{
	public class SellbriteInventoryContainer
	{
		[JsonProperty(PropertyName = "inventory")]
		public IEnumerable<SellbriteInventory> Inventory { get; set; }
	}

	public class SellbriteInventory
	{
		[JsonProperty(PropertyName = "sku")]
		public string Sku { get; set; }
		[JsonProperty(PropertyName = "warehouse_uuid")]
		public string WarehouseUuid { get; set; }
		[JsonProperty(PropertyName = "available")]
		public int Available { get; set; }
		[JsonProperty(PropertyName = "bin_location")]
		public string BinLocation { get; set; }

		public static SellbriteInventory ConvertToSellbrite(Inventory inventory, string warehouseUuid)
		{
			return new SellbriteInventory
			{
				Sku = inventory.Sku,
				WarehouseUuid = warehouseUuid,
				Available = inventory.Quantity,
				BinLocation = inventory.BinLocation
			};
		}

		public static List<SellbriteInventory> ConvertToSellbrite(List<Inventory> inventories, string warehouseUuid)
		{
			return inventories.Select(inventory => ConvertToSellbrite(inventory, warehouseUuid)).ToList();
		}
	}
}
