using Microsoft.EntityFrameworkCore;
using PinewoodTask.Application.Interfaces;
using PinewoodTask.Application.Services;
using PinewoodTask.Application;
using PinewoodTask.Core.Entities;
using PinewoodTask.Core;
using PinewoodTask.Infrastructure.Interfaces;
using PinewoodTask.Infrastructure.IRepositories;
using PinewoodTask.Infrastructure.Repository;
using PinewoodTask.Infrastructure.UnitOfWorks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CustomerDbContext>(options =>
{
    options.UseInMemoryDatabase("PinewoodTaskInMemoryDb");
    // Use this line for SQL Server
    // options.UseSqlServer(builder.Configuration.GetConnectionString("PinewoodTaskConnection"));
});

builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutomapperConfig());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CustomerDbContext>();
    context.Database.EnsureCreated();
    SeedData(context);
}

void SeedData(CustomerDbContext context)
{
    var customers = CustomerData.GetCustomers();
    context.Customers.AddRange(customers);
    context.SaveChanges();
}


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=Index}/{id?}");

app.Run();
