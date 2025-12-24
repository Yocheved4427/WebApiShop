using Entities;
using DTOs;
namespace Services
{
    public interface IProductsServices
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
    }
}