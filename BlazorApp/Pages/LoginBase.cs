using BlazorApp.Service;
using BlazorApp.Shared;
using ClassLibrary;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorApp.Pages
{
    public class LoginBase : ComponentBase
    {
        public User User { get; set; } = new User();
        public bool IsUserValidate = false;
        public bool InvalidUser { get; set; } = false;

        protected bool IsLoggedIn { get; set; } = false;

        [Inject]
        public IUserService UserService { get; set; }

        [Inject]
        public LoginStatus LoginStatus { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        protected async void HandleValidSubmit()
        {
            IsUserValidate = await UserService.ValidateUser(User);
            if (IsUserValidate)
            {
                IsLoggedIn = true;
                LoginStatus.IsLoggedIn = true;
            }
            else
                InvalidUser = true;
                
            StateHasChanged();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (LoginStatus.IsLoggedIn)
            {
                NavigationManager.NavigateTo("/home/1", true);
            }
        }

    }
}
