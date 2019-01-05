using System;

namespace Sellbrite
{
	class Program
	{
		private static void Main(string[] args)
		{
			SellbriteClient client = new SellbriteClient();
			client.GetWarehouses();
		}
	}
}
