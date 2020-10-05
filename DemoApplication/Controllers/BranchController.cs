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
    public class BranchController : Controller
    {
        private readonly IBranchRepository branchRepository;

        public BranchController(IBranchRepository branchRepository)
        {
            this.branchRepository = branchRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Branch>>> Get(string pageNo)
        {
            return await branchRepository.GetBranches(pageNo);
        }

        [HttpPut]
        public async Task<ActionResult<Branch>> AddBranch(Branch branch)
        {
            if(branch != null)
            {
                return await branchRepository.AddBranch(branch);
            }

            return BadRequest();
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult<Branch>> DeleteBranch(int Id)
        {
            return await branchRepository.DeleteBranch(Id);
        }

        [HttpPost]
        public async Task<Branch> GetBranch(BranchDetails branch)
        {
            return await branchRepository.GetBranch(branch);
        }

        [HttpPost("{Id:int}")]
        public async Task<ActionResult<Branch>> UpdateBranch(int Id, Branch branch)
        {
            if(Id == branch.Id)
            {
                return await branchRepository.UpdateBranch(branch);
            }
            return BadRequest();
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Branch>> Get(int Id)
        {
            return await branchRepository.GetBranch(Id);
        }
    }
}
