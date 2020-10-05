using ClassLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Model
{
    public class StateRepository : IStateRepository
    {
        private readonly AppDbContext dbContext;

        public StateRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<List<State>> GetBank()
        {
            throw new NotImplementedException();
        }

        public async Task<List<State>> GetState()
        {
            return await dbContext.States.ToListAsync();
        }
    }
}
