using System;
using System.Threading.Tasks;
using Blazor.FormSample.Web.Models;
using Blazor.FormSample.Web.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Blazor.FormSample.Web.Pages
{
    public partial class Booking
    {
        private bool UseMudBlazor { get; set; }
        private VacationBookingDto _vacationBooking = new();

        [Parameter] public string Id { get; set; }
        [Inject] public BookingService BookingService { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine($"Id Parameter set {Id}");
            if (!string.IsNullOrWhiteSpace(Id))
            {
                if (Guid.TryParse(Id, out var bookingId))
                {
                    var currentBooking = await BookingService.GetBookingAsync(bookingId);
                    if (currentBooking != null)
                    {
                        _vacationBooking = currentBooking;
                    }
                    else
                    {
                        Snackbar.Add($"Es wurde keine Buchung für die Id {bookingId} gefunden.", Severity.Warning);
                    }
                }
            }

            await base.OnInitializedAsync();
        }
    }
}