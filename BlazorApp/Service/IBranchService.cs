using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Service
{
    public interface IBranchService
    {
        public Task<List<Branch>> GetBranches(string pageNo);

        public Task AddBranch(Branch branch);

        public Task DeleteBranch(int Id);

        public Task<Branch> FindBranch(BranchDetails branch);

        public Task<Branch> GetBranch(int Id);

        public Task<Branch> UpdateBranch(int Id, Branch branch);
    }
}
