using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sellbrite.Models;

namespace Sellbrite.Tests
{
	[TestClass]
	public class SellbriteClientTests
	{
		[TestMethod]
		public void SellbriteClient_GetWarehouses_SuccessfulStatusCode()
		{
			SellbriteClient client = new SellbriteClient();
			List<Warehouse> warehouses = client.GetWarehouses();
			Assert.AreEqual(1, warehouses.Count);
		}

		[TestMethod]
		public void SellbriteClient_GetInventory_SuccessfulStatusCode()
		{
			SellbriteClient client = new SellbriteClient();
			List<SellbriteInventory> inventories = client.GetInventories();
			Assert.IsTrue(inventories.Count > 0);
		}
	}
}
