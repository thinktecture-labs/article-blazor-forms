using Blazor.FormSample.Web.Models;
using FluentValidation;

namespace Blazor.FormSample.Web.Validators
{
    public class VacationBookingValidator : AbstractValidator<VacationBookingDto>
    {
        public VacationBookingValidator()
        {
        }
    }
}
