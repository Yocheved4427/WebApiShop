using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUserServices, UserServices>();  

builder.Services.AddScoped<IPasswordServices, PasswordServices>();

builder.Services.AddDbContext<UsersContext>(option=>option.UseSqlServer ("Data Source=Yocheved;Initial Catalog=Users;Integrated Security=True;Pooling=False;TrustServerCertificate=True"));
// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
