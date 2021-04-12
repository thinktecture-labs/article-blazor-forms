using System;
using System.Linq;
using System.Threading.Tasks;
using Blazor.FormSample.Web.Models;
using Blazor.FormSample.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Blazor.FormSample.Web.Components.MudForm
{
    public partial class MudVacationBooking
    {
        [Inject] private BookingService BookingService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Parameter] public VacationBookingDto Model { get; set; }

        private EditForm _editForm;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (_editForm?.EditContext != null)
            {
                _editForm.EditContext.OnFieldChanged += (sender, args) =>
                {
                    if (args.FieldIdentifier.FieldName == nameof(VacationBookingDto.OnlyOutboundFlight))
                    {
                        Model.EndVacationDate = null;
                    }
                };
            }
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