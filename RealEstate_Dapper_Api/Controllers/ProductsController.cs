using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductRepository;
using System.Runtime.InteropServices;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductRepository _productRepository;

		public ProductsController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}


		[HttpGet]
		public async Task<IActionResult> ProductList()
		{
			var values = await _productRepository.GetAllProductAsync();
			return Ok(values);
		}

		[HttpGet("ProductListWithCategory")]
		public async Task<IActionResult> ProductListWithCategory()
		{
			var values = await _productRepository.GetAllProductWithCategoryAsync();
			return Ok(values);
		}


		[HttpGet("ProductDealOfTheStatusChangeToTrue/{id}")]
		public async Task<IActionResult> ProductDealOfTheStatusChangeToTrue(int id)
		{
			_productRepository.ProductDealOfTheStatusChangeToTrue(id);
			return Ok("İlan Günün Fırsatları Arasına Eklendi");
		}

		[HttpGet("ProductDealOfTheStatusChangeToFalse/{id}")]
		public async Task<IActionResult> ProductDealOfTheStatusChangeToFalse(int id)
		{
			_productRepository.ProductDealOfTheStatusChangeToFalse(id);
			return Ok("İlan Günün Fırsatları Arasından Çıkarıldı");
		}








	}
}
