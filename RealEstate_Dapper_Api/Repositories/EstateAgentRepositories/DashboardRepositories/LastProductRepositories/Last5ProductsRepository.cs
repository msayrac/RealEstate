using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductRepositories
{
    public class Last5ProductsRepository : ILast5ProductsRepository
    {
        public Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
