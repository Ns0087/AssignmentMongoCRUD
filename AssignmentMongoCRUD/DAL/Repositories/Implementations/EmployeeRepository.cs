using AssignmentMongoCRUD.DAL.DBContext;
using AssignmentMongoCRUD.DAL.Entities;
using AssignmentMongoCRUD.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AssignmentMongoCRUD.DAL.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private MongoClient _client;
        private readonly IMongoDatabase mongoDatabase;
        private IMongoCollection<Employee> _collection;

        public EmployeeRepository(IOptions<MongoDbSettings> settings)
        {
            _client = new MongoClient(settings.Value.ConnectionString);
            mongoDatabase = _client.GetDatabase(settings.Value.DatabaseName);
            _collection = mongoDatabase.GetCollection<Employee>(settings.Value.CollectionName);
        }
        public async Task CreateAsync(Employee employee)
        {
            try
            {
                await _collection.InsertOneAsync(employee);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            try
            {
                var result = await _collection.Find(_ => true).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public Task<Employee> GetByIdAsync(string id)
        {
            try
            {
                var employee = _collection.Find(emp => emp.Id == id).FirstOrDefaultAsync();
                return employee;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task UpdateAsync(string id, Employee employee)
        {
            try
            {
                await _collection.ReplaceOneAsync(emp => emp.Id == id, employee);
            }catch(Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                await _collection.DeleteOneAsync(emp => emp.Id == id);
            }catch (Exception ex)
            {
                throw;
            }
        }
    }
}
