using Entities;
using Repositories;

namespace Services
{
    public class ProductsServices : IProductsServices
    {
        private readonly IProductsRepository _repository;
        public ProductsServices(IProductsRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _repository.GetProducts();
        }
        

        


    }
}
