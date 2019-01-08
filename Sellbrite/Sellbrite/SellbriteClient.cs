using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

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

		public HttpStatusCode GetWarehouses()
		{
			var response = Client.GetAsync("warehouses").Result;
			Console.WriteLine(response.Content.ReadAsStringAsync().Result);
			return response.StatusCode;
		}

		public HttpStatusCode PostProduct(string sku)
		{
			HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, $"products/{sku}");
			string contentString = "{\"name\":\"test name\"}";
			requestMessage.Content = new StringContent(contentString, Encoding.UTF8, "application/json");
			var response = Client.SendAsync(requestMessage).Result;
			Console.WriteLine(response.Content.ReadAsStringAsync().Result);

			return response.StatusCode;
		}
	}
}
