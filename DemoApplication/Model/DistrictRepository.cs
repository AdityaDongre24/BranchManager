using ClassLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Model
{
    public class DistrictRepository : IDistrictRepository
    {
        private readonly AppDbContext dbContext;

        public DistrictRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<List<Bank>> GetBank()
        {
            throw new NotImplementedException();
        }

        public async Task<List<District>> GetDistrict()
        {
            return await dbContext.Districts.ToListAsync();
        }
    }
}
