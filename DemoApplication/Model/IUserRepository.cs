using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Model
{
    public interface IUserRepository
    {
        public Task AddUser(User user);

        public Task<bool> ValidateUser(User user);
    }
}
