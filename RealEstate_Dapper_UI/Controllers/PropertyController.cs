﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDetailDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.Controllers
{
	public class PropertyController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public PropertyController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44373/api/Products/ProductListWithCategory");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		public async Task<IActionResult> PropertyListWithSearch(string searchKeyValue, int propertyCategoryId, string city)
		{
			ViewBag.searchKeyValue = TempData["searchKeyValue"];
			ViewBag.propertyCategoryId = TempData["propertyCategoryId"];
			ViewBag.city = TempData["city"];

			searchKeyValue = TempData["searchKeyValue"].ToString();
			propertyCategoryId = int.Parse(TempData["propertyCategoryId"].ToString());
			city = TempData["city"].ToString();
			var client = _httpClientFactory.CreateClient();

			var responseMessage = await client.GetAsync($"https://localhost:44373/api/Products/ResultProductWithSearchList?searchKeyValue={searchKeyValue}&propertyCategoryId={propertyCategoryId}&city={city}");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDto>>(jsonData);
				return View(values);
			}
			return View();

		}


		[HttpGet]
		public async Task<IActionResult> PropertySingle(int id1)
		{
			var id = 1;
			ViewBag.i = id1;
			var client = _httpClientFactory.CreateClient();

			var responseMessage = await client.GetAsync("https://localhost:44373/api/Products/GetProductByProductId?id=" + id1);
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);

			var client2 = _httpClientFactory.CreateClient();
			var responseMessage2 = await client2.GetAsync("https://localhost:44373/api/ProductDetails/GetProductDetailByProductId?id=" + id1);
			var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
			var values2 = JsonConvert.DeserializeObject<GetProductDetailByIdDto>(jsonData2);

			ViewBag.productId = values.productID;
			ViewBag.title1 = values.title.ToString();
			ViewBag.price = values.price;
			ViewBag.city = values.city;
			ViewBag.district = values.district;
			ViewBag.Address = values.Address;
			ViewBag.type = values.Type;
			ViewBag.description = values.description;
			ViewBag.date = values.AdvertisementDate;


			ViewBag.bathCount = values2.bathCount;
			ViewBag.bedCount = values2.bedRoomCount;
			ViewBag.size = values2.productSize;
			ViewBag.roomCount = values2.roomCount;
			ViewBag.garageCount = values2.garageSize;
			ViewBag.builtYear = values2.buildYear;
			ViewBag.location = values2.location;
			ViewBag.videoUrl = values2.videoUrl;



			DateTime date1 = DateTime.Now;
			DateTime date2 = values.AdvertisementDate;

			TimeSpan timeSpan = date1 - date2;
			int month = timeSpan.Days;
			ViewBag.datediff = month / 30;

			return View();

		}








	}
}
