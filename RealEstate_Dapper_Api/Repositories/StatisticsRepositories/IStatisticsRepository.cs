namespace RealEstate_Dapper_Api.Repositories.StatisticsRepositories
{
	public interface IStatisticsRepository
	{
		int CategoryCount();
		int ActiveCategoryCount();
		int PassiveCategoryCount();
		int ProductCount();

		int ApertmentCount();
		string EmployeeNameByMaxProductCount();
		string CategoryNameByMaxProductCount();
		decimal AverageProductByRent();

		decimal AverageProductBySale();
		string CityNameByMaxProductCount();
		int DifferentCityCount();
		decimal LastProductPrice();

		string NewestBuildingYear();
		string OldestBuildingYear();	
		int AverageRoomCount();
		int ActiveEmployeeCount();

		//11 dk kaldım




	}
}
