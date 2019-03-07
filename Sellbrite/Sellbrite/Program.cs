using System;
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
			// List<string> inventoryFileLines = File.ReadAllLines("../../../../SellbriteMasterInventory.csv").Skip(3).ToList();
			// List<Inventory> inventories = Inventory.ParseInventoriesFromList(inventoryFileLines);

			// List<Product> products = Product.ParseProductsFromList("../../../../products.json");

			SellbriteClient client = new SellbriteClient();

			// List<Order> orders = client.GetOpenOrders();
			// orders.ForEach(order => Console.WriteLine($"{order.DisplayRef} {order.ShippingEmail}"));

			List<Warehouse> warehouses = client.GetWarehouses();

			if (warehouses.Count < 1)
				return;

			client.UpdateItemDescription("J11014", "<style>.top{margin-bottom:30px;}.top li{margin-left:5%;margin-right:5%;margin-top:10px;line-height:120%;list-style-position:outside;}</style><div class=\"top\">Tektro Disc Brake Pads</div><style>table{border-collapse:collapse;width:100%;}td{text-align: left;padding: 8px;font-weight:350;}tr:nth-child(even){background-color:#f2f2f2}th{background-color:#eb212e;color:white;text-align:left;padding:8px;}.desc ul{font-size:24px;font-weight:600;margin-left:-25px;padding-top:35px;border-top:3px solid #f0f0f0;}.desc li{list-style:none;border-bottom:4px solid #eb212e;width:142px;}</style><div class=\"desc\"><ul><li> TECH SPECS</li></ul></div><table><tr><td><strong><table><tr><td><strong>Heat Sink</strong></td> <td>No</td></tr><tr><td><strong>Backing Plate Material</strong></td> <td>Steel</td></tr><tr><td><strong>Pad Shape Number</strong></td> <td>31</td></tr><tr><td><strong>Compound</strong></td> <td>Resin</td></tr></table>");

			// List<SellbriteInventory> sellbriteInventories =
			//	SellbriteInventory.ConvertToSellbrite(inventories, warehouses[0].Uuid);

			// List<SellbriteProduct> sellbriteProducts = SellbriteProduct.ConvertToSellbrite(products);

			// client.PostProducts(sellbriteProducts);
			// client.PutInventories(sellbriteInventories);
		}
	}
}
