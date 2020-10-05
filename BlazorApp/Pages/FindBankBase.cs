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
    public class FindBankBase : ComponentBase
    {
        public BranchDetails BranchDetails { get; set; } = new BranchDetails();
        public Branch ResultBranch { get; set; }

        protected string BankID = "1";
        protected string StateID = "1";
        protected string DistrictId = "1";

        protected List<Bank> Banks;
        protected List<State> States;
        protected List<District> Districts;

        [Inject]
        public IBranchComponentService BranchComponent { get; set; }

        [Inject]
        public IBranchService BranchService { get; set; }

        protected bool IsFindClicked = false;

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
            Banks = await BranchComponent.GetBanks();
            States = await BranchComponent.GetStates();
            Districts = await BranchComponent.GetDistricts();
        }

        protected async Task OnFindClicked()
        {
            ResultBranch = null;
            BranchDetails.Bank = int.Parse(BankID);
            BranchDetails.State = int.Parse(StateID);
            BranchDetails.District = int.Parse(DistrictId);
            BranchDetails.IFSCCode = null;
            ResultBranch = await BranchService.FindBranch(BranchDetails);
        }

        protected async Task OnDetailsClicked()
        {
            ResultBranch = null;
            ResultBranch = await BranchService.FindBranch(BranchDetails);
        }
    }
}
