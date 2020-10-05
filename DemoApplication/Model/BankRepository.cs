using ClassLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Model
{
    public class BankRepository : IBankRepository
    {
        private readonly AppDbContext dbContext;

        public BankRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Bank>> GetBank()
        {
            return await dbContext.Bank.ToListAsync();
        }
    }
}
