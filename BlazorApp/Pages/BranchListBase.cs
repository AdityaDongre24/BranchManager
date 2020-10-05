using BlazorApp.Service;
using ClassLibrary;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Pages
{
    public class BranchListBase : ComponentBase
    {
        [Parameter]
        public Branch Branch { get; set; }

        [Parameter]
        public EventCallback OnDeleteEntry { get; set; }

        [Inject]
        IBranchService branchService { get; set; }

        protected async Task OnDeleteClicked()
        {
            await branchService.DeleteBranch(Branch.Id);
            await OnDeleteEntry.InvokeAsync(null);
        }

    }
}
