using System;
using Blazor.FormSample.Web.Models;
using FluentValidation;

namespace Blazor.FormSample.Web.Validators
{
    public class VacationBookingValidator : AbstractValidator<VacationBookingDto>
    {
        public VacationBookingValidator()
        {
            RuleFor(booking => booking.StartVacationDate)
                .GreaterThan(DateTime.Now)
                .WithMessage("Das Datum muss in der Zukunft liegen.");
            RuleFor(booking => booking.EndVacationDate)
                .Null()
                .When(booking => booking.OnlyOutboundFlight)
                .NotNull()
                .When(booking => !booking.OnlyOutboundFlight)
                .WithMessage("Bitte geben Sie ein Abreise Datum an.")
                .GreaterThan(booking => booking.StartVacationDate)
                .When(booking => !booking.OnlyOutboundFlight)
                .WithMessage("Das Abreise Datum muss nach dem Startdatum liegen.");
            RuleFor(booking => booking.TravelClass)
                .NotEqual(TravelClass.Economy)
                .When(booking => booking.Adults > 2)
                .WithMessage("Wenn mehr als zwei Personen mitfliegen, muss die Reiseklasse min. Business sein");
            RuleFor(booking => booking.FromAirport.Id)
                .NotEqual(booking => booking.ToAirport.Id)
                .WithMessage("Der Ablufhafen darf nicht der gleiche wie der Ankunfts Flughafen sein.");
            RuleFor(booking => booking.ToAirport.Id)
                .NotEqual(booking => booking.FromAirport.Id)
                .WithMessage("Der Ablufhafen darf nicht der gleiche wie der Ankunfts Flughafen sein.");
        }
    }
}