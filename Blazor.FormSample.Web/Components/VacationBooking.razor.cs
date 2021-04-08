using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.FormSample.Web.Models;
using Blazor.FormSample.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Blazor.FormSample.Web.Components
{
    public partial class VacationBooking
    {
        [Inject] private HttpClient Http { get; set; }
        [Inject] private BookingService BookingService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Parameter] public VacationBookingDto Model { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await BookingService.InitializeDbASync();
        }

        private async Task Submit(EditContext context)
        {
            Console.WriteLine($"Form is valid: {context.Validate()}");
            Console.WriteLine($"Form is modified: {context.IsModified()}");
            Console.WriteLine($"Form is ValidationMessages: {String.Join(",", context.GetValidationMessages())}");

            Console.WriteLine($"FromAirport {Model.FromAirport.Name}");
            Console.WriteLine($"ToAirport {Model.ToAirport.Name}");
            if (!context.GetValidationMessages().Any())
            {
                await BookingService.AddBookingAsync(Model);
                NavigationManager.NavigateTo(NavigationManager.BaseUri);
            }
        }
    }
}