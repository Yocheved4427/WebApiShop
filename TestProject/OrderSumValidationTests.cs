using DTOs;
using Entities;
using Moq;
using Moq.EntityFrameworkCore;
using Repositories;
using Services;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace TestProject
{
    public class OrderSumValidationTests
    {
        private readonly Mock<IOrdersRepository> _mockOrdersRepository;
        private readonly Mock<IProductsRepository> _mockProductsRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<OrdersServices>> _mockLogger;
        private readonly OrdersServices _ordersServices;

        public OrderSumValidationTests()
        {
            _mockOrdersRepository = new Mock<IOrdersRepository>();
            _mockProductsRepository = new Mock<IProductsRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<OrdersServices>>();
            _ordersServices = new OrdersServices(
                _mockOrdersRepository.Object,
                _mockProductsRepository.Object,
                _mockMapper.Object,
                _mockLogger.Object);
        }

        [Fact]
        public async Task ValidateOrderSum_ShouldReturnTrue_WhenOrderSumMatchesCalculatedSum()
        {
            // Arrange - Happy Path
            var products = new List<Product>
            {
                new Product { ProductId = 1, ProductName = "Laptop", Price = 1000m },
                new Product { ProductId = 2, ProductName = "Mouse", Price = 50m }
            };

            _mockProductsRepository.Setup(r => r.GetProducts())
                .ReturnsAsync(products);

            var orderItems = new List<OrderItemDTO>
            {
                new OrderItemDTO(OrderId: 1, ProductId: 1, Quantity: 2),  // 2 * 1000 = 2000
                new OrderItemDTO(OrderId: 1, ProductId: 2, Quantity: 3)   // 3 * 50 = 150
            };

            var order = new OrderDTO(
                OrderId: 1,
                OrderDate: DateOnly.FromDateTime(DateTime.Now),
                OrderSum: 2150,  // 2000 + 150 = 2150 (correct sum)
                UserId: 1,
                OrderItems: orderItems
            );

            // Act
            var result = await _ordersServices.ValidateOrderSum(order);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task ValidateOrderSum_ShouldReturnFalse_WhenOrderSumDoesNotMatchCalculatedSum()
        {
            // Arrange - Unhappy Path
            var products = new List<Product>
            {
                new Product { ProductId = 1, ProductName = "Laptop", Price = 1000m },
                new Product { ProductId = 2, ProductName = "Mouse", Price = 50m }
            };

            _mockProductsRepository.Setup(r => r.GetProducts())
                .ReturnsAsync(products);

            var orderItems = new List<OrderItemDTO>
            {
                new OrderItemDTO(OrderId: 1, ProductId: 1, Quantity: 2),  // 2 * 1000 = 2000
                new OrderItemDTO(OrderId: 1, ProductId: 2, Quantity: 3)   // 3 * 50 = 150
            };

            var order = new OrderDTO(
                OrderId: 1,
                OrderDate: DateOnly.FromDateTime(DateTime.Now),
                OrderSum: 999,  // Incorrect sum (should be 2150)
                UserId: 1,
                OrderItems: orderItems
            );

            // Act
            var result = await _ordersServices.ValidateOrderSum(order);

            // Assert
            Assert.False(result);
        }
    }
}
