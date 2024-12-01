using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Repositories.EmployeeRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private readonly IEmployeeRepository _employeeRepository;
		public EmployeesController(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}


		[HttpGet]
		public async Task<IActionResult> EmployeeList()
		{
			var values =await _employeeRepository.GetAllEmployeeAsync();
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
		{
			_employeeRepository.CreateEmployee(createEmployeeDto);
			return Ok("Employee Başarılı Bir Şekilde Eklendi");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEmployee(int id)
		{
			_employeeRepository.DeleteEmployee(id);
			return Ok("Employee başarılı şekilde silindi");

		}













	}
}
