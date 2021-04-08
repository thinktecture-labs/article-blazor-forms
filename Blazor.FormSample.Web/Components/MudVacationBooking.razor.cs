using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazor.FormSample.Web.Models;
using Blazor.FormSample.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace Blazor.FormSample.Web.Components
{
    public partial class MudVacationBooking
    {
        [Inject] private BookingService BookingService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Parameter] public VacationBookingDto Model { get; set; }
        
        private MudTabs _tabs;

        private void SwitchTab(int index)
        {
            _tabs.ActivatePanel(index);
        }

        private async Task Submit(EditContext context)
        {
            Console.WriteLine($"Form is valid: {context.Validate()}");
            Console.WriteLine($"Form is modified: {context.IsModified()}");
            Console.WriteLine($"Form is ValidationMessages: {String.Join(",", context.GetValidationMessages())}");
            if (!context.GetValidationMessages().Any())
            {
                await BookingService.AddBookingAsync(Model);
                NavigationManager.NavigateTo(NavigationManager.BaseUri);
            }
        }
    }
}