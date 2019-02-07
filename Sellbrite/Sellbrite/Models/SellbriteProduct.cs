using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Sellbrite.Models
{
	public class SellbriteProduct
	{
		[JsonIgnore]
		public string Sku { get; set; }
		[JsonRequired]
		public string Name { get; set; }
		public string Asin { get; set; }
		public string Condition { get; set; }
		public string Brand { get; set; }
		public string Manufacturer { get; set; }
		[JsonProperty(PropertyName = "manufacturer_model_number")]
		public string ManufacturerModelNumber { get; set; }
		public string Description { get; set; }
		public float Price { get; set; }
		[JsonIgnore]
		public float Cost { get; set; }
		[JsonProperty(PropertyName = "package_length")]
		public float PackageLength { get; set; }
		[JsonProperty(PropertyName = "package_width")]
		public float PackageWidth { get; set; }
		[JsonProperty(PropertyName = "package_height")]
		public float PackageHeight { get; set; }
		[JsonProperty(PropertyName = "package_unit_of_length")]
		[JsonIgnore]
		public string PackageUnitOfLength { get; set; }
		[JsonProperty(PropertyName = "package_weight")]
		public float PackageWeight { get; set; }
		[JsonProperty(PropertyName = "package_unit_of_weight")]
		[JsonIgnore]
		public string PackageUnitOfWeight { get; set; }
		public float Msrp { get; set; }
		[JsonProperty(PropertyName = "category_name")]
		public string CategoryName { get; set; }
		public List<string> Features { get; set; }
		[JsonIgnore]
		public string Warranty { get; set; }
		[JsonProperty(PropertyName = "condition_note")]
		public string ConditionNote { get; set; }
		public string Upc { get; set; }
		public string Ean { get; set; }
		public string Isbn { get; set; }
		public string Gtin { get; set; }
		public string Epid { get; set; }
		[JsonProperty(PropertyName = "image_list")]
		public List<string> ImageList { get; set; }
		[JsonIgnore]
		[JsonProperty(PropertyName = "custom_attributes")]
		public CustomAttributes CustomAttributes { get; set; }

		public static SellbriteProduct ConvertToSellbrite(Product p)
		{
			List<string> features = new List<string>() { p.Feature_1, p.Feature_2, p.Feature_3, p.Feature_3, p.Feature_4, p.Feature_5 };
			features.RemoveAll(str => str is null || str.Equals(""));

			List<string> imageList = new List<string>
			{
				p.Product_Image_1, p.Product_Image_2, p.Product_Image_3, p.Product_Image_4, p.Product_Image_5,
				p.Product_Image_6, p.Product_Image_7, p.Product_Image_8, p.Product_Image_9, p.Product_Image_10,
				p.Product_Image_11, p.Product_Image_12
			};
			imageList.RemoveAll(str => str is null || str.Equals(""));

			return new SellbriteProduct()
			{
				Sku = p.Sku,
				Name = p.Name,
				Asin = p.Asin,
				Condition = p.Asin,
				Brand = p.Brand,
				Manufacturer = p.Manufacturer,
				ManufacturerModelNumber = p.Manufacturer_Model_Number,
				Description = p.Description,
				Price = p.Price,
				PackageLength = p.Package_Length,
				PackageWidth = p.Package_Width,
				PackageHeight = p.Package_Height,
				PackageWeight = p.Package_Weight,
				Msrp = p.Msrp,
				CategoryName = p.Category_Name,
				Features = features,
				ConditionNote = p.Condition_Note,
				Upc = p.Upc,
				Ean = p.Ean,
				Isbn = p.Isbn,
				Gtin = p.Gtin,
				Epid = p.Epid,
				ImageList = imageList,
				CustomAttributes = new CustomAttributes
				{
					EbayTitle = p.Ebay_Title,
					FourthCategory = p.Fourth_Category,
					ItemDescription = p.Item_Description,
					Model = p.Model,
					SecondCategory = p.Second_Category,
					ThirdCategory = p.Third_Category,
					Delete = p.Delete
				}
			};
		}

		public static List<SellbriteProduct> ConvertToSellbrite(List<Product> products)
		{
			return products.Select(ConvertToSellbrite).ToList();
		}

		public override string ToString() => JsonConvert.SerializeObject(this);
	}

	public class CustomAttributes
	{
		[JsonProperty(PropertyName = "ebay_title")]
		public string EbayTitle { get; set; }
		[JsonProperty(PropertyName = "fourth_category")]
		public string FourthCategory { get; set; }
		[JsonProperty(PropertyName = "item_description")]
		public string ItemDescription { get; set; }
		[JsonProperty(PropertyName = "model")]
		public string Model { get; set; }
		[JsonProperty(PropertyName = "second_category")]
		public string SecondCategory { get; set; }
		[JsonProperty(PropertyName = "third_category")]
		public string ThirdCategory { get; set; }
		[JsonProperty(PropertyName = "delete")]
		public string Delete { get; set; }

		public override string ToString() => JsonConvert.SerializeObject(this);
	}
}
