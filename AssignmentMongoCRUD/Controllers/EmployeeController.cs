using AssignmentMongoCRUD.Models.RequestViewModel;
using AssignmentMongoCRUD.Models.ResponseViewModel;
using AssignmentMongoCRUD.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssignmentMongoCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IServiceProvider serviceProvider)
        {
            _employeeService = serviceProvider.GetRequiredService<IEmployeeService>();
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeResponseModel>> GetAllEmployeesAsync()
        {

            var result = await _employeeService.GetAllAsync();
            return result;

        }

        [HttpGet("{id}")]
        public async Task<EmployeeResponseModel> GetEmployeeByIdAsync(string id)
        {
            var result = await _employeeService.GetByIdAsync(id);

            return result;
        }

        [HttpPost]
        public async Task AddEmployeeAsync(EmployeeRequestModel employee)
        {
            await _employeeService.CreateAsync(employee);
        }

        [HttpPut("{id}")]
        public async Task UpdateEmployeeAsync(string id, EmployeeRequestModel employee)
        {
            await _employeeService.UpdateAsync(id, employee);
        }

        [HttpDelete("{id}")]
        public async Task DeleteEmployeeByIdAsync(string id)
        {
            await _employeeService.DeleteAsync(id);
        }
    }
}
