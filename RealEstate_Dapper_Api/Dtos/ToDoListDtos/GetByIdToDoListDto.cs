﻿namespace RealEstate_Dapper_Api.Dtos.ToDoListDtos
{
	public class GetByIdToDoListDto
	{
		public int ToDoListId { get; set; }
		public string Description { get; set; }
		public bool ToDoListStatus { get; set; }
	}
}