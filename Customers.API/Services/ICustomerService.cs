using Customers.API.Models;

namespace Customers.API.Services
{
    public interface ICustomerService
    {
        Task<int> DeleteAsync(int id);
        Task<List<Customer>> FindAllAsync();
        Task<Customer> FindOneAsync(int id);
        Task<int> InsertAsync(Customer customer);
        Task<int> UpdateAsync(Customer customer);
    }
}
