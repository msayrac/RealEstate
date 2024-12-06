﻿using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.StatisticsRepositories
{
	public class StatisticsRepository : IStatisticsRepository
	{
		private readonly Context _context;

		public StatisticsRepository(Context context)
		{
			_context = context;
		}

		public int ActiveCategoryCount()
		{
			string query = "Select Count(*) From Category Where CategoryStatus=1";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public int ActiveEmployeeCount()
		{
			string query = "Select Count(*) From Employee Where Status=1";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public int ApertmentCount()
		{
			string query = "Select Count(*) From Product Where Title like '%Daire%'";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public decimal AverageProductPriceByRent()
		{
			string query = "Select AVG(Price) From Product Where Type='Kiralık'";

			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<decimal>(query);
				return values;
			}
		}

		public decimal AverageProductPriceBySale()
		{
			string query = "Select AVG(Price) From Product Where Type='Satılık'";

			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<decimal>(query);
				return values;
			}
		}

		public int AverageRoomCount()
		{
			string query = "Select AVG(RoomCount) From ProductDetails";

			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public int CategoryCount()
		{
			string query = "Select Count(*) From Category";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public string CategoryNameByMaxProductCount()
		{
			string query = "Select Top(1) CategoryName, Count(*) From Product inner join Category on Product.Productcategory=Category.CategoryID Group By CategoryName Order By Count(*) Desc";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<string>(query);
				return values;
			}
		}

		public string CityNameByMaxProductCount()
		{
			string query = "Select Top(1)  City, Count(*) as 'product_count' From Product Group By City Order By product_count Desc";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<string>(query);
				return values;
			}
		}

		public int DifferentCityCount()
		{
			string query = "Select Count(Distinct(City)) From Product";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public string EmployeeNameByMaxProductCount()
		{
			string query = "Select Name, Count(*) as 'product_count' From Product Join Employee on Employee.EmployeeID=Product.EmployeeID Group By Name Order By product_count Desc";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<string>(query);
				return values;
			}
		}

		public decimal LastProductPrice()
		{
			string query = "Select Top(1) Price From Product Order By ProductID Desc";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<decimal>(query);
				return values;
			}
		}

		public string NewestBuildingYear()
		{
			string query = "Select Top(1) BuildYear From ProductDetails Order By BuildYear Desc";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<string>(query);
				return values;
			}
		}

		public string OldestBuildingYear()
		{
			string query = "Select Top(1) BuildYear From ProductDetails Order By BuildYear Asc";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<string>(query);
				return values;
			}
		}

		public int PassiveCategoryCount()
		{
			string query = "Select Count(*) From Category Where CategoryStatus=0";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public int ProductCount()
		{
			string query = "Select Count(*) From Product";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}
	}
}
