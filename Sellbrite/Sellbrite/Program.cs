using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Sellbrite.Models;

namespace Sellbrite
{
	public class Program
	{
		private static void Main()
		{
			List<string> inventoryFileLines = File.ReadAllLines("../../../../SellbriteMasterInventory.csv").Skip(3).ToList();
			List<Inventory> inventories = Inventory.ParseInventoriesFromList(inventoryFileLines);

			List<Product> products = Product.ParseProductsFromList("../../../../product_data.json");

			SellbriteClient client = new SellbriteClient();
			List<Warehouse> warehouses = client.GetWarehouses();

			if (warehouses.Count < 1)
				return;

			List<SellbriteInventory> sellbriteInventories =
				SellbriteInventory.ConvertToSellbrite(inventories, warehouses[0].Uuid);

			List<SellbriteProduct> sellbriteProducts = SellbriteProduct.ConvertToSellbrite(products);

			client.PostProducts(sellbriteProducts);
			// client.PutInventories(sellbriteInventories);
		}
	}
}
