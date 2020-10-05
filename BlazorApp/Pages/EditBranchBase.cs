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
    public class EditBranchBase : ComponentBase
    {

        [Parameter]
        public string Id { get; set; }

        public Branch Branch { get; set; }

        public List<Bank> Banks { get; set; }

        public List<State> States { get; set; }

        public List<District> Districts { get; set; }

        public string BankId { get; set; } = "1";
        public string StateId { get; set; } = "1";
        public string DistrictId { get; set; } = "1";

        [Inject]
        public IBranchComponentService BranchComponentService { get; set; }

        [Inject]
        public IBranchService BranchService { get; set; }

        [Inject]
        public LoginStatus LoginStatus { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            if (!LoginStatus.IsLoggedIn)
            {
                navigationManager.NavigateTo("/");
            }

            Banks = await BranchComponentService.GetBanks();
            States = await BranchComponentService.GetStates();
            Districts = await BranchComponentService.GetDistricts();

            Branch = await BranchService.GetBranch(int.Parse(Id));
            BankId = Branch.Bank.ToString();
            StateId = Branch.State.ToString();
            DistrictId = Branch.District.ToString();
        }

        protected async Task OnValidSubmit()
        {
            Branch.Bank = int.Parse(BankId);
            Branch.State = int.Parse(StateId);
            Branch.District = int.Parse(DistrictId);
            Branch resultBranch = await BranchService.UpdateBranch(Branch.Id, Branch);

            navigationManager.NavigateTo("/Home/1");
        }
    }
}
