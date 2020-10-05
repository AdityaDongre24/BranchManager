using ClassLibrary;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp.Service
{
    public class BranchService : IBranchService
    {
        public readonly HttpClient HttpClient;

        public BranchService(HttpClient httpClient)
        {
            this.HttpClient = httpClient;
        }

        public async Task AddBranch(Branch branch)
        {
            await HttpClient.PutJsonAsync("api/Branch", branch);
        }

        public async Task DeleteBranch(int Id)
        {
            await HttpClient.DeleteAsync($"api/Branch/{Id}");
        }

        public async Task<List<Branch>> GetBranches(string pageNo)
        {
            return await HttpClient.GetJsonAsync<List<Branch>>($"api/Branch?PageNo={pageNo}");
        }

        public async Task<Branch> FindBranch(BranchDetails branch)
        {
            return await HttpClient.PostJsonAsync<Branch>("api/Branch", branch);
        }

        public async Task<Branch> GetBranch(int Id)
        {
            return await HttpClient.GetJsonAsync<Branch>($"api/Branch/{Id}");
        }

        public async Task<Branch> UpdateBranch(int Id, Branch branch)
        {
            return await HttpClient.PostJsonAsync<Branch>($"api/Branch/{Id}", branch);
        }
    }
}
