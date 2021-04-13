using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.FormSample.Web.Models;
using Blazor.FormSample.Web.Services;
using Microsoft.AspNetCore.Components;

namespace Blazor.FormSample.Web.Components
{
    public partial class Bookings
    {
        [Inject] private BookingService BookingService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        
        private List<VacationBookingDto> _bookings;

        protected override async Task OnInitializedAsync()
        {
            _bookings = await BookingService.BookingsAsync();
            await base.OnInitializedAsync();
        }

        private async Task DeleteBookingAsync(VacationBookingDto booking)
        {
            await BookingService.DeleteBookingAsync(booking);
            _bookings.Remove(booking);
        }

        private void OpenBooking(Guid id)
        {
            NavigationManager.NavigateTo($"/booking/{id}");
        }
    }
}