using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sellbrite.Tests
{
	[TestClass]
	public class SellbriteClientTests
	{
		[TestMethod]
		public void SellbriteClient_GetWarehouses_SuccessfulStatusCode()
		{
			SellbriteClient client = new SellbriteClient();
			var statusCode = client.GetWarehouses();
			Assert.AreEqual("OK", statusCode.ToString());
		}
	}
}
