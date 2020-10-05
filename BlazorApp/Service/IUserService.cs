using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Service
{
    public interface IUserService
    {
        public Task<bool> ValidateUser(User user);
    }
}
