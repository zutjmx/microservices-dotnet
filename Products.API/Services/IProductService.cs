using Products.API.Models;

namespace Products.API.Services
{
    public interface IProductService
    {
        Task<int> DeleteAsync(int id);
        Task<List<Product>> FindAllAsync();
        Task<Product> FindOneAsync(int id);
        Task<int> InsertAsync(Product product);
        Task<int> UpdateAsync(Product product);
    }
}
