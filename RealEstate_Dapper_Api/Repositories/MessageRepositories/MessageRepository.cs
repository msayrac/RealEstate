﻿using Dapper;
using RealEstate_Dapper_Api.Dtos.MessageDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.MessageRepositories
{
	public class MessageRepository : IMessageRepository
	{

		private readonly Context _context;

		public MessageRepository(Context context)
		{
			_context = context;
		}

		public async Task<List<ResultInBoxMessageDto>> GetInBoxLast3MessageListByReceiver(int id)
		{
			string query = "Select Top(3) MessageId, Name, Subject, Detail, SendDate,IsRead, UserImageUrl From Message Inner join AppUser on AppUser.UserId=Message.Sender Where Receiver=@receiver";
			var parameters = new DynamicParameters();
			parameters.Add("@receiver", id);

			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultInBoxMessageDto>(query, parameters);
				return values.ToList();
			}


		}
	}

}
