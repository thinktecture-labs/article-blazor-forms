using System;
using Blazor.FormSample.Web.Models;
using Blazor.FormSample.Web.Shared.ResourceFiles;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Blazor.FormSample.Web.Validators
{
    public class VacationBookingValidator : AbstractValidator<VacationBookingDto>
    {
        public VacationBookingValidator(IStringLocalizer<Resource> localizer)
        {
            RuleFor(booking => booking.StartVacationDate)
                .GreaterThan(DateTime.Now)
                .WithMessage(localizer.GetString("StartDateError"));
            RuleFor(booking => booking.EndVacationDate)
                .Null()
                .When(booking => booking.OnlyOutboundFlight)
                .NotNull()
                .When(booking => !booking.OnlyOutboundFlight)
                .WithMessage(localizer.GetString("EndDateErrorOne"))
                .GreaterThan(booking => booking.StartVacationDate)
                .When(booking => !booking.OnlyOutboundFlight)
                .WithMessage(localizer.GetString("EndDateErrorTwo"));
            RuleFor(booking => booking.TravelClass)
                .NotEqual(TravelClass.Economy)
                .When(booking => booking.Adults > 2)
                .WithMessage(localizer.GetString("TravelClassError"));
            RuleFor(booking => booking.FromAirport.Id)
                .NotEqual(booking => booking.ToAirport.Id)
                .WithMessage(localizer.GetString("AirportError"));
            RuleFor(booking => booking.ToAirport.Id)
                .NotEqual(booking => booking.FromAirport.Id)
                .WithMessage(localizer.GetString("AirportError"));
        }
    }
}