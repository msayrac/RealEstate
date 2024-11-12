using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public interface IWhoWeAreRepository
    {
        Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync();
        void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto);

        void DeleteWhoWeAreDetail(int id);

        void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto);

        Task<GetByIDWhoWeAreDetailDto> GetGetByIDWhoWeAreDetail(int id);

    }
}
