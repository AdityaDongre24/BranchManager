using ClassLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Model
{
    public class BranchRepository : IBranchRepository
    {
        private readonly AppDbContext dbContext;

        public BranchRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Branch> AddBranch(Branch branch)
        {
            if(branch != null)
            {
                await dbContext.Branchs.AddAsync(branch);
                await dbContext.SaveChangesAsync();
                return branch;
            }

            return null;
        }

        public async Task<Branch> DeleteBranch(int id)
        {
            Branch existingBranch = await dbContext.Branchs.FirstOrDefaultAsync(e => e.Id == id);
            if(existingBranch != null)
            {
                dbContext.Branchs.Remove(existingBranch);
                await dbContext.SaveChangesAsync();
                return existingBranch;
            }

            return null;
        }

        public async Task<Branch> GetBranch(BranchDetails branch)
        {
            if(string.IsNullOrEmpty(branch.IFSCCode))
            {
                Branch resultbranch = await dbContext.Branchs.FirstOrDefaultAsync(e => (e.Bank == branch.Bank && e.District == branch.District && e.State == branch.State));
                if (resultbranch == null)
                {
                    return new Branch();
                }
                else
                    return resultbranch;
            }
            Branch result = await dbContext.Branchs.FirstOrDefaultAsync(e => e.IFSCCode == branch.IFSCCode);
            if (result == null)
                return new Branch();
            else
                return result;
        }

        public async Task<Branch> GetBranch(int Id)
        {
            return await dbContext.Branchs.FirstOrDefaultAsync(q => q.Id == Id);
        }

        public async Task<List<Branch>> GetBranches(string pageNo)
        {
            int PageRange = (int.Parse(pageNo) * 2) - 2;
            List<Branch> result = await dbContext.Branchs.ToListAsync();
            int minPage = PageRange < result.Count ? PageRange : result.Count - 1;
            int maxPage = PageRange + 1 < result.Count ?  2 : 1;
            return result.GetRange(minPage, maxPage);
        }

        public async Task<Branch> UpdateBranch(Branch branch)
        {
            if(branch != null)
            {
                Branch existingBranch = await dbContext.Branchs.FirstOrDefaultAsync(q=> q.Id == branch.Id);
                existingBranch.BranchName = branch.BranchName;
                existingBranch.Bank = branch.Bank;
                existingBranch.State = branch.State;
                existingBranch.District = branch.District;
                existingBranch.IFSCCode = branch.IFSCCode;
                await dbContext.SaveChangesAsync();

                return existingBranch;
            }
            return null;
        }
    }
}
