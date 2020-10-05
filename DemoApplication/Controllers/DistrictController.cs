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
    public class DistrictController : Controller
    {
        private readonly IDistrictRepository DistrictRepository;

        public DistrictController(IDistrictRepository DistrictRepository)
        {
            this.DistrictRepository = DistrictRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<District>>> Get()
        {
            return await DistrictRepository.GetDistrict();
        }

    }
}
