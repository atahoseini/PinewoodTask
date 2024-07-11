
using Microsoft.EntityFrameworkCore;
using PinewoodTask.Application;
using PinewoodTask.Core;
using PinewoodTask.Core.Entities;
using PinewoodTask.Infrastructure;
using PinewoodTask.Infrastructure.Model;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.
builder.Services.AddOptions();
builder.Services.Configure<Configs>(builder.Configuration.GetSection("Configs"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddRepositories();
builder.Services.AddUnitOfWork();

var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutomapperConfig());
});

var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddDbContext<CustomerDbContext>(options =>
{
       options.UseInMemoryDatabase("PinewoodTaskInMemoryDb");
    // options.UseSqlserver(builder.Configuration.GetConnectionString("PinewoodTaskConnection"));
    //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});



builder.Services.AddMemoryCache();
builder.Services.AddMiniProfiler(options => options.RouteBasePath = "/profiler").AddEntityFramework();

builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddHttpContextAccessor();


builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAPI",
      builder =>
      {
          builder.WithOrigins("*");
          builder.WithHeaders("*");
          builder.WithMethods("*");
      });
});

builder.Services.AddMemoryCache();

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

app.UseDeveloperExceptionPage();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiniProfiler();

app.UseRouting();
app.UseCors("MyAPI");
app.UseHttpsRedirection();

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
