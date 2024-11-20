using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ServiceDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultServicesComponentPartial : ViewComponent
    {
        private IHttpClientFactory _httpClientFactory;

        public _DefaultServicesComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:44373/api/Services");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);

                ViewBag.serviceName =value.Select(x=>x.ServiceName).FirstOrDefault();

                return View();
            }


            return View();
        }



    }
}
