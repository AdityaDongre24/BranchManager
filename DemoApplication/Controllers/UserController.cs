using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;
using DemoApplication.Model;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> ValidateUser(User user)
        {
            if(user == null)
            {
                return BadRequest();
            }
            bool isUserValidate = await userRepository.ValidateUser(user);
            return isUserValidate;
        }
    }
}
