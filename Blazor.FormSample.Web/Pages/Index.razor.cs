using Microsoft.AspNetCore.Components;

namespace Blazor.FormSample.Web.Pages
{
    public partial class Index
    {
        [Inject] private NavigationManager NavigationManager { get; set; }

        private void AddNewBooking()
        {
            NavigationManager.NavigateTo("/booking/new");
        }
    }
}