using RealEstate_Dapper_Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
	public interface ICategoryRepository
	{
		Task<List<ResultCategoryDto>> GetAllCategory();
		Task CreateCategory(CreateCategoryDto createDto);

		Task DeleteCategory(int id);

		Task UpdateCategory(UpdateCategoryDto updateCategoryDto);
		
		Task<GetByIdCategoryDto> GetCategory(int id);


	}
}
