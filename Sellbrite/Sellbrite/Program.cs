using System.Collections.Generic;
using System.IO;
using System.Linq;
using Sellbrite.Models;

namespace Sellbrite
{
	public class Program
	{
		private static void Main()
		{
			List<string> fileLines = File.ReadAllLines("../../../../SellbriteMasterInventory.csv").Skip(3).ToList();
			List<Inventory> inventories = Inventory.ParseInventoriesFromList(fileLines);

			SellbriteClient client = new SellbriteClient();
			List<Warehouse> warehouses = client.GetWarehouses();

			if (warehouses.Count < 1)
				return;

			List<SellbriteInventory> sellbriteInventories =
				SellbriteInventory.ConvertToSellbrite(inventories, warehouses[0].Uuid);
			client.PutInventories(sellbriteInventories);
		}
	}
}
