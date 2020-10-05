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
    public class StateController : Controller
    {
        private readonly IStateRepository StateRepository;

        public StateController(IStateRepository StateRepository)
        {
            this.StateRepository = StateRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<State>>> Get()
        {
            return await StateRepository.GetState();
        }

    }
}
