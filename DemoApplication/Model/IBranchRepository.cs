using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Model
{
    public interface IBranchRepository
    {
        public Task<List<Branch>> GetBranches(string pageNo);

        public Task<Branch> GetBranch(BranchDetails branch);

        public Task<Branch> AddBranch(Branch branch);

        public Task<Branch> DeleteBranch(int Id);

        public Task<Branch> UpdateBranch(Branch branch);

        public Task<Branch> GetBranch(int Id);
    }
}
