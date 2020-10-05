using ClassLibrary;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp.Service
{
    public class BranchComponentService : IBranchComponentService
    {
        private readonly HttpClient httpClient;

        public BranchComponentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Bank>> GetBanks()
        {
            return await httpClient.GetJsonAsync<List<Bank>>("api/Bank");
        }

        public async Task<List<District>> GetDistricts()
        {
            return await httpClient.GetJsonAsync<List<District>>("api/District");
        }

        public async Task<List<State>> GetStates()
        {
            return await httpClient.GetJsonAsync<List<State>>("api/State");
        }
    }
}
