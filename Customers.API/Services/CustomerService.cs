using Customers.API.Data;
using Customers.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Customers.API.Services
{
    public sealed class CustomerService : ICustomerService
    {
        private readonly MariaDbContext _dbContext;

        public CustomerService(MariaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                _dbContext.Customers.Remove(
                    new Customer
                    {
                        Id = id
                    }
                );

                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }

        public Task<List<Customer>> FindAllAsync() => _dbContext.Customers.ToListAsync();

        public Task<Customer> FindOneAsync(int id) => _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);

        public Task<int> InsertAsync(Customer customer)
        {
            _dbContext.Add(customer);
            return _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Customer customer)
        {
            try
            {
                _dbContext.Update(customer);
                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }
    }
}
