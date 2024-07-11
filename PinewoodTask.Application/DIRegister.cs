using Microsoft.Extensions.DependencyInjection;
using PinewoodTask.Application.Interfaces;
using PinewoodTask.Application.Services;
using PinewoodTask.Infrastructure.Interfaces;
using PinewoodTask.Infrastructure.IRepositories;
using PinewoodTask.Infrastructure.Repository;
using PinewoodTask.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinewoodTask.Application
{
    public static class DIRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerServices, CustomerServices>();
            services.AddScoped<ICustomerSQLServices, CustomerSQLServices>();
            return services;
        }

    }


}
