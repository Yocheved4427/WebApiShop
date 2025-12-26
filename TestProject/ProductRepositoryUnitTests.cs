using Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Repositories;

namespace TestProject
{
    public class ProductRepositoryUnitTests
    {
        [Fact]
        public async Task GetProducts_ShouldReturnListOfProducts_WhenContextHasData()
        {
            var options = new DbContextOptions<ApiShopContext>();
            var mockContext = new Mock<ApiShopContext>(options);
            var productsList = new List<Product>
            {
                new Product { ProductId = 1, ProductName = "Laptop", Price = 2000, CategoryId = 1 },
                new Product { ProductId = 2, ProductName = "Screen", Price = 500, CategoryId = 1 }
            };
            mockContext.Setup(x => x.Products).ReturnsDbSet(productsList);
            var repository = new ProductsRepository(mockContext.Object);
            var result = await repository.GetProducts();
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal("Laptop", result.First().ProductName);
        }

        [Fact]
        public async Task GetProducts_ShouldReturnEmptyList_WhenContextIsEmpty()
        {
            var options = new DbContextOptions<ApiShopContext>();
            var mockContext = new Mock<ApiShopContext>(options);
            mockContext.Setup(x => x.Products).ReturnsDbSet(new List<Product>());
            var repository = new ProductsRepository(mockContext.Object);
            var result = await repository.GetProducts();
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}