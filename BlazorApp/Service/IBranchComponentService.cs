using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Service
{
    public interface IBranchComponentService
    {
        public Task<List<Bank>> GetBanks();

        public Task<List<State>> GetStates();

        public Task<List<District>> GetDistricts();

    }
}
