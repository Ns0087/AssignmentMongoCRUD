using AssignmentMongoCRUD.DAL.Entities;
using AssignmentMongoCRUD.Models.RequestViewModel;
using AssignmentMongoCRUD.Models.ResponseViewModel;
using static System.Reflection.Metadata.BlobBuilder;

namespace AssignmentMongoCRUD.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeResponseModel>> GetAllAsync();
        Task<EmployeeResponseModel> GetByIdAsync(string id);
        Task CreateAsync(EmployeeRequestModel employee);
        Task UpdateAsync(string id, EmployeeRequestModel employee);
        Task DeleteAsync(string id);
    }
}
