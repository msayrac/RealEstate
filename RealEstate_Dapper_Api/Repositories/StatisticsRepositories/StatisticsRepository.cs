using Dapper;
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
			throw new NotImplementedException();
		}

		public int DifferentCityCount()
		{
			throw new NotImplementedException();
		}

		public string EmployeeNameByMaxProductCount()
		{
			throw new NotImplementedException();
		}

		public decimal LastProductPrice()
		{
			throw new NotImplementedException();
		}

		public string NewestBuildingYear()
		{
			throw new NotImplementedException();
		}

		public string OldestBuildingYear()
		{
			throw new NotImplementedException();
		}

		public int PassiveCategoryCount()
		{
			throw new NotImplementedException();
		}

		public int ProductCount()
		{
			throw new NotImplementedException();
		}
	}
}
