﻿using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
	public class ProductRepository : IProductRepository
	{
		private readonly Context _context;

		public ProductRepository(Context context)
		{
			_context = context;
		}

		public async Task<List<ResultProductDto>> GetAllProductAsync()
		{
			string query = "Select * From Product";

			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultProductDto>(query);
				return values.ToList();
			}
		}

		public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
		{
			string query = "Select P.ProductID, P.Title,P.Price,P.City,P.District,C.CategoryName, P.CoverImage,P.Type,P.Address, P.DealOfTheDay From Product P join Category C on C.CategoryID=P.ProductCategory";

			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
				return values.ToList();
			}
		}

		public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync()
		{
			string query = "Select Top(5) ProductID, Title, Price, City, District, ProductCategory, CategoryName, AdvertisementDate From Product Inner Join Category on Category.CategoryID=Product.ProductCategory Where Type='Kiralık' Order By ProductID Desc";

			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query);
				return values.ToList();
			}
		}

		public async void ProductDealOfTheStatusChangeToFalse(int id)
		{
			string query = "Update Product Set DealOfTheDay=0 Where ProductID=@productID";

			var parameters = new DynamicParameters();
			parameters.Add("@productID", id);

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async void ProductDealOfTheStatusChangeToTrue(int id)
		{
			string query = "Update Product Set DealOfTheDay=1 Where ProductID=@productID";

			var parameters = new DynamicParameters();
			parameters.Add("@productID", id);

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}


		}
	}
}
