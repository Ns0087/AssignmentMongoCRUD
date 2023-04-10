using AssignmentMongoCRUD.DAL.Entities;
using AssignmentMongoCRUD.DAL.Repositories.Interfaces;
using AssignmentMongoCRUD.Extensions;
using AssignmentMongoCRUD.Models.RequestViewModel;
using AssignmentMongoCRUD.Models.ResponseViewModel;
using AssignmentMongoCRUD.Services.Interfaces;
using MongoDB.Driver;

namespace AssignmentMongoCRUD.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        private IMongoCollection<Employee> employeeCollection;

        public EmployeeService(IServiceProvider service)
        {
            _employeeRepository = service.GetRequiredService<IEmployeeRepository>();
        }

        public async Task CreateAsync(EmployeeRequestModel employee)
        {
            try
            {
                await _employeeRepository.CreateAsync(employee.ModelViewToEntity<EmployeeRequestModel, Employee>());
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                var employee = GetByIdAsync(id);
                if(employee != null)
                {
                    await _employeeRepository.DeleteAsync(id);
                }else
                {
                    throw new Exception("Please Enter a valid EmployeeId!!");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<EmployeeResponseModel>> GetAllAsync()
        {
            try
            {
                var employees = await _employeeRepository.GetAllAsync();

                List<EmployeeResponseModel> result = new List<EmployeeResponseModel>();

                foreach (var employee in employees)
                {
                    result.Add(employee.ModelViewToEntity<Employee, EmployeeResponseModel>());
                }

                return result;
            }catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<EmployeeResponseModel> GetByIdAsync(string id)
        {
            try
            {
                var employee = await _employeeRepository.GetByIdAsync(id);
                if(employee != null)
                {
                    return employee.ModelViewToEntity<Employee, EmployeeResponseModel>();
                }
                else
                {
                    throw new Exception("Please Enter valid Employee Id!!");
                }
            }catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateAsync(string id, EmployeeRequestModel updateEmployee)
        {
            try
            {
                var employee = GetByIdAsync(id);
                if (employee != null && id == updateEmployee.Id)
                {
                    var emp = updateEmployee.ModelViewToEntity<EmployeeRequestModel, Employee>();
                    await _employeeRepository.UpdateAsync(id, emp);
                }
                else
                {
                    throw new Exception("Please Enter a valid EmployeeId!!");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
