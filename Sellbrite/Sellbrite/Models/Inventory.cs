using System.Collections.Generic;
namespace Sellbrite.Models
{
	public class Inventory
	{
		public string Sku { get; set; }
		public int Quantity { get; set; }
		public double Cost { get; set; }
		public string BinLocation { get; set; }

		public static List<Inventory> ParseInventoriesFromList(List<string> list)
		{
			if (list is null)
				return null;

			List<Inventory> inventories = new List<Inventory>();
			foreach (var line in list)
			{
				var rows = line.Split(",");

				int.TryParse(rows[1], out int quantity);
				double.TryParse(rows[2], out double cost);

				inventories.Add(new Inventory{Sku = rows[0], Quantity = quantity, Cost = cost, BinLocation = rows[3]});
			}

			return inventories;
		}
	}
}
