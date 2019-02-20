using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using FileHelpers;
using Newtonsoft.Json;

namespace Sellbrite.Models
{
	[IgnoreFirst]
	[DelimitedRecord(",")]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public class Product
	{
		public string Sku { get; set; }
		public string Parent_Sku { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Brand { get; set; }
		public string Condition { get; set; }
		public string Condition_Note { get; set; }
		public float? Price { get; set; }
		public float? Msrp { get; set; }
		public string Category_Name { get; set; }
		public string Manufacturer { get; set; }
		public string Manufacturer_Model_Number { get; set; }
		public string Upc { get; set; }
		public string Ean { get; set; }
		public string Isbn { get; set; }
		public string Gtin { get; set; }
		public string Gcid { get; set; }
		public string Asin { get; set; }
		public string Epid { get; set; }
		public float? Package_Height { get; set; }
		public float? Package_Length { get; set; }
		public float? Package_Width { get; set; }
		public float? Package_Weight { get; set; }

		public string Feature_1 { get; set; }
		public string Feature_2 { get; set; }
		public string Feature_3 { get; set; }
		public string Feature_4 { get; set; }
		public string Feature_5 { get; set; }

		public string Variation_1 { get; set; }
		public string Variation_2 { get; set; }
		public string Variation_3 { get; set; }
		public string Variation_4 { get; set; }
		public string Variation_5 { get; set; }

		public string Product_Image_1 { get; set; }
		public string Product_Image_2 { get; set; }
		public string Product_Image_3 { get; set; }
		public string Product_Image_4 { get; set; }
		public string Product_Image_5 { get; set; }
		public string Product_Image_6 { get; set; }
		public string Product_Image_7 { get; set; }
		public string Product_Image_8 { get; set; }
		public string Product_Image_9 { get; set; }
		public string Product_Image_10 { get; set; }
		public string Product_Image_11 { get; set; }
		public string Product_Image_12 { get; set; }

		public string Ebay_Title { get; set; }
		public string Fourth_Category { get; set; }
		public string Item_Description { get; set; }
		public string Model { get; set; }
		public string Second_Category { get; set; }
		public string Third_Category { get; set; }
		public string Delete { get; set; }

		public static List<Product> ParseProductsFromList(string filename)
		{
			string json = File.ReadAllText(filename);
			List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);
			return products;
		}
	}
}
