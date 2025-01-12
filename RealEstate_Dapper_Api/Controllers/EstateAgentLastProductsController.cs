using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentLastProductsController : ControllerBase
    {
        private readonly ILast5ProductsRepository _last5ProductRepository;

        public EstateAgentLastProductsController(ILast5ProductsRepository last5ProductRepository)
        {
            _last5ProductRepository = last5ProductRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetLast5ProductAsync(int id)
        {
            var values =await  _last5ProductRepository.GetLast5ProductAsync(id);
            return Ok(values);
        }















    }
}
