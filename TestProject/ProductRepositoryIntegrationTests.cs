using Entities;
using Repositories;

namespace TestProject
{
    public class ProductRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly ApiShopContext _dbContext;
        private readonly ProductsRepository _productsRepository;

        public ProductRepositoryIntegrationTests(DatabaseFixture fixture)
        {
            _dbContext = fixture.Context;
            _productsRepository = new ProductsRepository(_dbContext);
        }

        [Fact]
        public async Task GetProducts_ShouldReturnAllProducts_WhenProductsExist()
        {
            _dbContext.OrderItems.RemoveRange(_dbContext.OrderItems);
            _dbContext.Products.RemoveRange(_dbContext.Products);
            _dbContext.Categories.RemoveRange(_dbContext.Categories);
            await _dbContext.SaveChangesAsync();
            var category = new Category { CategoryName = "Gaming" };
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            var prod1 = new Product
            {
                ProductName = "Mouse",
                Price = 50,
                Description = "Optical",
                CategoryId = category.CategoryId
            };
            var prod2 = new Product
            {
                ProductName = "Keyboard",
                Price = 100,
                Description = "Mechanical",
                CategoryId = category.CategoryId
            };
            await _dbContext.Products.AddRangeAsync(prod1, prod2);
            await _dbContext.SaveChangesAsync();
            _dbContext.ChangeTracker.Clear();
            var result = await _productsRepository.GetProducts();
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, p => p.ProductName == "Mouse");
            Assert.Contains(result, p => p.ProductName == "Keyboard");
        }

        [Fact]
        public async Task GetProducts_ShouldReturnEmptyList_WhenNoProductsExist()
        {
            _dbContext.OrderItems.RemoveRange(_dbContext.OrderItems);
            _dbContext.Products.RemoveRange(_dbContext.Products);
            await _dbContext.SaveChangesAsync();
            _dbContext.ChangeTracker.Clear();
            var result = await _productsRepository.GetProducts();
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}