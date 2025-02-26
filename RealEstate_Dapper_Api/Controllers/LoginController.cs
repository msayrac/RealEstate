﻿using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.LoginDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Tools;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly Context _context;

		public LoginController(Context context)
		{
			_context = context;
		}

		[HttpPost]
		public async Task<IActionResult> SignIn(CreateLoginDto createLoginDto)
		{
			string query = "Select * From AppUser Where UserName=@userName and Password=@password";

			string query2 = "Select UserID From AppUser Where UserName=@userName and Password=@password";

			var parameters = new DynamicParameters();

			parameters.Add("@userName", createLoginDto.Username);
			parameters.Add("@password", createLoginDto.Password);

			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<CreateLoginDto>(query, parameters);
				var values2 = await connection.QueryFirstAsync<GetAppUserIdDto>(query2, parameters);

				if (values != null)
				{
					GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
					model.Username = values.Username;
					model.Id = values2.UserId;

					var token = JwtTokenGenerator.GenerateToken(model);
					return Ok(token);
				}
				else
				{
					return Ok("Başarısız");
				}


			}

		}



	}
}
