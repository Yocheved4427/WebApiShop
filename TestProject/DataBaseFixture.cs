using Microsoft.EntityFrameworkCore;
using Repositories;
using System;

namespace TestProject
{
    public class DatabaseFixture : IDisposable
    {
        public ApiShopContext Context { get; private set; }

        
        private readonly DbContextOptions<ApiShopContext> _options;

        public DatabaseFixture()
        {
            string dbName = $"ApiShop_Test_{Guid.NewGuid()}";

            
            string connectionString = $"Data Source=Yocheved;Initial Catalog={dbName};Integrated Security=True;Pooling=False;TrustServerCertificate=True";

            var optionsBuilder = new DbContextOptionsBuilder<ApiShopContext>()
                .UseSqlServer(connectionString);

            _options = optionsBuilder.Options;
            Context = new ApiShopContext(_options);

           
            Context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}