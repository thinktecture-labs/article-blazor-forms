using System;
using System.Threading.Tasks;
using Blazor.FormSample.Web.Models;
using Microsoft.AspNetCore.Components;

namespace Blazor.FormSample.Web.Pages
{
    public partial class Booking
    {
        private bool UseMudBlazor { get; set; }
        private readonly VacationBookingDto _vacationBooking = new();
        
        [Parameter] public string Id { get; set; }

        protected override Task OnInitializedAsync()
        {
            Console.WriteLine($"Id Parameter set {Id}");
            return base.OnInitializedAsync();
        }
    }
}