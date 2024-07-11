using Microsoft.Extensions.DependencyInjection;
using PinewoodTask.Infrastructure.Interfaces;
using PinewoodTask.Infrastructure.IRepositories;
using PinewoodTask.Infrastructure.Repository;
using PinewoodTask.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinewoodTask.Infrastructure
{
    public static class DIRegister
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerSQLRepository, CustomerSQLRepository>();
        }

        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
