﻿using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
	public class BottomGridRepository : IBottomGridRepository
	{
		private readonly Context _context;

		public BottomGridRepository(Context context)
		{
			_context = context;
		}

		public async Task CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
		{
			string query = "insert into BottomGrid (Icon,Title,Description) values (@icon, @title,@description)";

			var parameters = new DynamicParameters();
			parameters.Add("@icon", createBottomGridDto.Icon);
			parameters.Add("@title", createBottomGridDto.Title);
			parameters.Add("@description", createBottomGridDto.Description);

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task DeleteBottomGrid(int id)
		{
			string query = "Delete From BottomGrid Where BottomGridID=@bottomGridID";

			var parameter = new DynamicParameters();
			parameter.Add("@bottomGridID", id);

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameter);
			}
		}

		public async Task<List<ResultBottomGridDto>> GetAllBottomGrid()
		{
			string query = "Select * From BottomGrid";

			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultBottomGridDto>(query);
				return values.ToList();
			}

		}

		public async Task<GetBottomGridDto> GetBottomGrid(int id)
		{
			string query = "Select * from BottomGrid Where BottomGridID=@bottomGridID";

			var parameter = new DynamicParameters();
			parameter.Add("@bottomGridID", id);

			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<GetBottomGridDto>(query, parameter);
				return values;
			}
		}

		public async Task UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
		{
			string query = "Update BottomGrid Set Icon=@icon,Title=@title,Description=@description Where BottomGridID=@bottomGridID";

			var parameters = new DynamicParameters();
			parameters.Add("@icon", updateBottomGridDto.Icon);
			parameters.Add("@title", updateBottomGridDto.Title);
			parameters.Add("@description", updateBottomGridDto.Description);
			parameters.Add("@bottomGridID", updateBottomGridDto.BottomGridID);

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}

		}
	}
}
