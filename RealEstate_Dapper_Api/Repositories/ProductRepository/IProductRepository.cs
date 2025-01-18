using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
	public interface IProductRepository
	{
		Task<List<ResultProductDto>> GetAllProductAsync();
		Task<List<ResultProductAdvertsListWithCategoryByEmployeeDto>> GetProductAdvertsListByEmployeeAsyncByTrue(int id);
		Task<List<ResultProductAdvertsListWithCategoryByEmployeeDto>> GetProductAdvertsListByEmployeeAsyncByFalse(int id);

		Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
		void ProductDealOfTheStatusChangeToTrue(int id);
		void ProductDealOfTheStatusChangeToFalse(int id);
		Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync();
		Task CreateProduct(CreateProductDto createProductDto);







	}
}
