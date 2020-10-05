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
    public class HomeBase : ComponentBase
    {
        protected List<Branch> branches { get; set; }

        [Inject]
        public IBranchService BranchService { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public LoginStatus LoginStatus { get; set; }

        [Parameter]
        public string Id { get; set; } = "1";

        public string PageID1 { get; set; }

        public string PageID2 { get; set; }

        public string PageID3 { get; set; }
        public string PageIDPrevious { get; set; }
        public string PageIDNext { get; set; }

        protected async override Task OnInitializedAsync()
        {
            if (!LoginStatus.IsLoggedIn)
            {
                navigationManager.NavigateTo("/");
            }

            if (int.Parse(Id) % 2 == 0)
            {
                PageID1 = (int.Parse(Id) - 1).ToString();
                PageID2 = Id;
                PageID3 = (int.Parse(Id) + 1).ToString();
            }
            else
            {
                PageID1 = Id;
                PageID2 = (int.Parse(Id) + 1).ToString();
                PageID3 = (int.Parse(Id) + 2).ToString();
            }

            PageIDPrevious = int.Parse(PageID1) != 1 ? (int.Parse(PageID1) - 1).ToString() : "1";
            PageIDNext = (int.Parse(PageID3) + 1).ToString();

            branches = await BranchService.GetBranches(Id);
        }

        protected void OnAddBranch()
        {
            navigationManager.NavigateTo("/AddBranch");
        }

        public async Task OnDeleteEntry()
        {
            branches = await BranchService.GetBranches(Id);
        }

        //pagination
        protected void SetPage(string NewPageId)
        {
            navigationManager.NavigateTo($"home/{NewPageId}", true);
        }

    }
}
