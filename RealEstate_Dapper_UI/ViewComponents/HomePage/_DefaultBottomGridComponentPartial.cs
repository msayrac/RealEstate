﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.BottomGridDtos;
using RealEstate_Dapper_UI.Dtos.SubFeatureDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
	public class _DefaultBottomGridComponentPartial : ViewComponent
	{
		private IHttpClientFactory _httpClientFactory;
		public _DefaultBottomGridComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();

			var responseMessage = await client.GetAsync("https://localhost:44373/api/BottomGrids");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultBottomGridDto>>(jsonData);
				return View(values);
			}
			return View();
		}



	}
}
