using BlazorApp.Service;
using BlazorApp.Shared;
using ClassLibrary;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Pages
{
    public class AddBranchBase : ComponentBase
    {

        public Branch Branch { get; set; } = new Branch();

        public List<Bank> Banks { get; set; }

        public List<State> States { get; set; }

        public List<District> Districts { get; set; }

        public string BankId { get; set; } = "1";
        public string StateId { get; set; } = "1";
        public string DistrictId { get; set; } = "1";

        [Inject]
        public IBranchComponentService BranchComponentService { get; set; }

        [Inject]
        public IBranchService branchService { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public LoginStatus LoginStatus { get; set; }

        protected async override Task OnInitializedAsync()
        {
            if (!LoginStatus.IsLoggedIn)
            {
                navigationManager.NavigateTo("/");
            }

            Banks = await BranchComponentService.GetBanks();
            States = await BranchComponentService.GetStates();
            Districts = await BranchComponentService.GetDistricts();
        }

        protected async void OnValidSubmit()
        {
            Branch.Bank = Int32.Parse(BankId);
            Branch.State =  Int32.Parse(StateId);
            Branch.District = Int32.Parse(DistrictId);

            await branchService.AddBranch(Branch);
            navigationManager.NavigateTo("/Home/1");
        }
    }
}
