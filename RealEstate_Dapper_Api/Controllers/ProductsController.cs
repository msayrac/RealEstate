﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
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

		[HttpGet("Last5ProductList")]
		public async Task<IActionResult> Last5ProductList()
		{
			var values = await _productRepository.GetLast5ProductAsync();
			return Ok(values);
		}


		[HttpGet("ProductAdvertsListByEmployeeByTrue")]
		public async Task<IActionResult> ProductAdvertsListByEmployeeByTrue(int id)
		{

			var values = await _productRepository.GetProductAdvertsListByEmployeeAsyncByTrue(id);
			return Ok(values);
		}

		[HttpGet("ProductAdvertsListByEmployeeByFalse")]
		public async Task<IActionResult> ProductAdvertsListByEmployeeByFalse(int id)
		{

			var values = await _productRepository.GetProductAdvertsListByEmployeeAsyncByFalse(id);
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
		{
			await _productRepository.CreateProduct(createProductDto);

			return Ok("İlan Başarıyla Eklendi");
		}

		[HttpGet("GetProductByProductId")]
		public async Task<IActionResult> GetProductByProductId(int id)
		{
			var values = await _productRepository.GetProductByProductId(id);
			return Ok(values);

		}

		[HttpGet("ResultProductWithSearchList")]
		public async Task<IActionResult> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryId, string city)
		{
			var values = await _productRepository.ResultProductWithSearchList(searchKeyValue, propertyCategoryId, city);
			return Ok(values);
		}

		[HttpGet("GetProductByDealOfTheDayTrueWithCategory")]
		public async Task<IActionResult> GetProductByDealOfTheDayTrueWithCategory()
		{
			var values = await _productRepository.GetProductByDealOfTheDayTrueWithCategoryAsync();

			return Ok(values);

		}



	}
}
