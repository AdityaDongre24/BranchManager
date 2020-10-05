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
    public class BankController : Controller
    {
        private readonly IBankRepository bankRepository;

        public BankController(IBankRepository bankRepository)
        {
            this.bankRepository = bankRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Bank>>> Get()
        {
            return await bankRepository.GetBank();
        }

    }
}
