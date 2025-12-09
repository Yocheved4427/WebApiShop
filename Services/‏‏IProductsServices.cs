using Entities;

namespace Services
{
    public interface IProductsServices
    {
        Task<IEnumerable<Product>> GetProducts();
    }
}