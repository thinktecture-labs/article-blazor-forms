using System;
using System.ComponentModel.DataAnnotations;
using Blazor.FormSample.Web.Shared.ResourceFiles;

namespace Blazor.FormSample.Web.Models
{
    public class VacationBookingDto
    {
        [Key] public Guid Id { get; set; }

        [Required(ErrorMessageResourceName = "FirstNameRequired", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(100, ErrorMessageResourceName = "FirstNameLength", ErrorMessageResourceType = typeof(Resource))]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceName = "LastNameRequired", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(100, ErrorMessageResourceName = "LastNameLength", ErrorMessageResourceType = typeof(Resource))]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceName = "BirthDateRequired", ErrorMessageResourceType = typeof(Resource))]
        public DateTime? BirthDate { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }

        [Required(ErrorMessageResourceName = "AirportError", ErrorMessageResourceType = typeof(Resource))]
        public Airport FromAirport { get; set; } = new();

        public bool OnlyOutboundFlight { get; set; }
        public Airport ToAirport { get; set; } = new();

        [Required(ErrorMessageResourceName = "StartDateError", ErrorMessageResourceType = typeof(Resource))]
        public DateTime? StartVacationDate { get; set; }

        public DateTime? EndVacationDate { get; set; }
        public TravelClass? TravelClass { get; set; } = Models.TravelClass.Economy;
        public int Adults { get; set; } = 1;
        public int KidsAboveThreeYears { get; set; }
        public int KidsBelowThreeYears { get; set; }

        public VacationBookingDto()
        {
            Id = Guid.NewGuid();
        }
    }

    // ToDo: Translate enums values in the UI
    public enum TravelClass
    {
        Economy,
        PremiumEconomy,
        Business,
        First
    }
}