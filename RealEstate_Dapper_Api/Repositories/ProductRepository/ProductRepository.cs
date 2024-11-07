using Dapper;
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
			string query = "Select P.ProductID, P.Title,P.Price,P.City,P.District,C.CategoryName From Product P join Category C on C.CategoryID=P.ProductCategory";

			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
				return values.ToList();
			}
		}
	}
}
