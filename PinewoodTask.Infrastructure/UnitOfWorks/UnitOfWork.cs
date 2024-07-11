using PinewoodTask.Core;
using PinewoodTask.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinewoodTask.Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CustomerDbContext customerDbContext;

        public UnitOfWork(CustomerDbContext customerDbContext)
        {
            this.customerDbContext = customerDbContext;
        }

        public void Dispose()
        {
            customerDbContext.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.customerDbContext.SaveChangesAsync();
        }
    }
}
