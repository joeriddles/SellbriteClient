using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Sellbrite.Models;
using Newtonsoft.Json;

namespace Sellbrite
{
	public class SellbriteClient
	{
		private readonly string baseUrl = "https://api.sellbrite.com/v1/";
		private readonly string apiToken = "token";
		private readonly string apiSecret = "secret";
		private HttpClient Client { get; }

		public SellbriteClient()
		{
			HttpClientHandler handler = new HttpClientHandler();
			Client = new HttpClient(handler) { BaseAddress = new Uri(baseUrl) };
			Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			var authByteArray = Encoding.ASCII.GetBytes($"{apiToken}:{apiSecret}");
			Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authByteArray));
		}

		public List<Warehouse> GetWarehouses()
		{
			var response = Client.GetAsync("warehouses").Result;
			if (response.IsSuccessStatusCode)
			{
				List<Warehouse> warehouses = new List<Warehouse>();
				var responseString = response.Content.ReadAsStringAsync().Result;
				warehouses.AddRange(JsonConvert.DeserializeObject<List<Warehouse>>(responseString));
				return warehouses;
			}

			return null;
		}

		public List<Order> GetOpenOrders()
		{
			int i = 1;
			var response = Client.GetAsync($"orders?page={i}&sb_status=open").Result;
			List<Order> orders = new List<Order>();
			while (response.IsSuccessStatusCode)
			{
				Console.WriteLine(i);
				string responseString = response.Content.ReadAsStringAsync().Result;
				IEnumerable<Order> currentOrders = JsonConvert.DeserializeObject<IEnumerable<Order>>(responseString);

				int oldCount = orders.Count;
				orders.AddRange(currentOrders);
				if (orders.Count == oldCount)
					break;

				response = Client.GetAsync($"orders?page={i++}&sb_status=open").Result;
			}

			return orders;
		}

		public List<SellbriteInventory> GetInventories()
		{
			var response = Client.GetAsync("inventory").Result;
			if (response.IsSuccessStatusCode)
			{
				List<SellbriteInventory> sellbriteInventories = new List<SellbriteInventory>();
				var responseString = response.Content.ReadAsStringAsync().Result;
				sellbriteInventories.AddRange(JsonConvert.DeserializeObject<List<SellbriteInventory>>(responseString));
				return sellbriteInventories;
			}

			return null;
		}

		public void PutInventories(List<SellbriteInventory> inventories)
		{
			for (int i = 0; i < inventories.Count; i += 1)
			{
				Console.WriteLine($"[{i} to {i + 1})");

				HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put, $"{Client.BaseAddress}inventory");
				IEnumerable<SellbriteInventory> fiftyInventories = inventories.Skip(i).Take(1);

				SellbriteInventoryContainer container = new SellbriteInventoryContainer {Inventory = fiftyInventories};

				string contentString = JsonConvert.SerializeObject(container);
				requestMessage.Content = new StringContent(contentString, Encoding.UTF8, "application/json");
				var response = Client.SendAsync(requestMessage).Result;

				if (response.IsSuccessStatusCode)
				{
					string content = response.Content.ReadAsStringAsync().Result;
				}
				else
				{
					Console.Write("dang man: ");
					if (response.StatusCode.Equals(HttpStatusCode.NotFound))
					{
						requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{Client.BaseAddress}inventory");
						response = Client.SendAsync(requestMessage).Result;
						if (response.IsSuccessStatusCode)
						{
							Console.WriteLine("success");
						}
						else
						{
							Console.WriteLine("fail");
						}
					}
				}

				Task.Delay(500);
			}
		}

		public void PostProducts(List<SellbriteProduct> products)
		{
			int i = 1;
			foreach (var product in products)
			{
				Console.WriteLine(i + ": " + product.Sku);
				i++;

				HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{Client.BaseAddress}products/{product.Sku}");
				string contentString = JsonConvert.SerializeObject(
					product,
					Formatting.None,
					new JsonSerializerSettings
					{
						NullValueHandling = NullValueHandling.Ignore
					}
				);
				requestMessage.Content = new StringContent(contentString, Encoding.UTF8, "application/json");
				var response = Client.SendAsync(requestMessage).Result;

				if (response.IsSuccessStatusCode)
				{
					string content = response.Content.ReadAsStringAsync().Result;
				}
				else
				{
					Console.WriteLine("error");
				}
			}
		}

		public void UpdateItemDescription(string sku, string itemDescription)
		{
			if (sku == null) throw new ArgumentNullException(nameof(sku));
			if (itemDescription == null) throw new ArgumentNullException(nameof(itemDescription));

			SellbriteProduct product = new SellbriteProduct {Sku = sku, CustomAttributes = new CustomAttributes{ItemDescription = itemDescription}};
			HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{Client.BaseAddress}products/{product.Sku}");
			string contentString = JsonConvert.SerializeObject(
				product,
				Formatting.None,
				new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				}
			);
			requestMessage.Content = new StringContent(contentString, Encoding.UTF8, "application/json");
			var response = Client.SendAsync(requestMessage).Result;

			if (response.IsSuccessStatusCode)
			{
				string content = response.Content.ReadAsStringAsync().Result;
			}
			else
			{
				Console.WriteLine("error");
			}
		}
	}
}
