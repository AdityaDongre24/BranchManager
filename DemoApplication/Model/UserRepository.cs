using ClassLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Model
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task AddUser(User user)
        {

        }

        public async Task<bool> ValidateUser(User user)
        {
            User activeUser = await appDbContext.Users.FirstOrDefaultAsync(u => u.UserName == user.UserName && u.Password == user.Password);
            if (activeUser == null || user.Password != activeUser.Password)
                return false;
            return true;
        }
    }
}
