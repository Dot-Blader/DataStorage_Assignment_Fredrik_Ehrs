using Business.Services;
using Data.Contexts;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presentation;

var services = new ServiceCollection()
    .AddDbContext<DataContext>(x => x.UseSqlServer())
    .AddScoped<CustomerRepository>()
    .AddScoped<CustomerService>()
    .AddScoped<UserRepository>()
    .AddScoped<UserService>()
    .AddScoped<ProductRepository>()
    .AddScoped<ProductService>()
    .AddScoped<StatusTypeRepository>()
    .AddScoped<StatusTypeService>()
    .AddScoped<ProjectRepository>()
    .AddScoped<ProjectService>()
    .AddScoped<MenuDialogs>()
    .BuildServiceProvider();

var menuDialogs = services.GetRequiredService<MenuDialogs>();
await menuDialogs.Menu();