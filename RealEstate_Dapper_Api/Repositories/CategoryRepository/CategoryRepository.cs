﻿using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly Context _context;

		public CategoryRepository(Context context)
		{
			_context = context;
		}

		public async Task CreateCategory(CreateCategoryDto createDto)
		{
			string query = "insert into Category (CategoryName, CategoryStatus) values (@categoryName, @categoryStatus)";

			var parameters = new DynamicParameters();
			parameters.Add("@categoryName", createDto.CategoryName);
			parameters.Add("@categoryStatus", true);

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task DeleteCategory(int id)
		{
			string query = "Delete From Category Where CategoryID=@categoryID";

			var parameters = new DynamicParameters();

			parameters.Add("@categoryID", id);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}

		}

		public async Task<List<ResultCategoryDto>> GetAllCategory()
		{
			string query = "Select * From Category";

			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultCategoryDto>(query);

				return values.ToList();
			}
		}

		public async Task<GetByIdCategoryDto> GetCategory(int id)
		{
			string query = "Select * From Category Where CategoryID=@CategoryID";
			var parameters = new DynamicParameters();

			parameters.Add("@CategoryID", id);
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query, parameters);
				return values;
			}
		}

		public async Task UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
			string query = "Update Category Set CategoryName=@categoryName,CategoryStatus=@categoryStatus where CategoryID=@categoryID";

			var parameters = new DynamicParameters();
			parameters.Add("@categoryID", updateCategoryDto.CategoryID);
			parameters.Add("@categoryName", updateCategoryDto.CategoryName);
			parameters.Add("@categoryStatus", updateCategoryDto.CategoryStatus);

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}

		}
	}
}
