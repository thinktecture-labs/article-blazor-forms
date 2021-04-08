using System;
using System.ComponentModel.DataAnnotations;

namespace Blazor.FormSample.Web.Models
{
    public class VacationBookingDto
    {
        [Key] public Guid Id { get; set; }

        public Person Person { get; set; } = new();

        [Required(ErrorMessage = "Bitte geben Sie einen Start Flughafen an.")]
        public Airport FromAirport { get; set; } = new();

        public bool OnlyOutboundFlight { get; set; }

        [Required(ErrorMessage = "Bitte geben Sie einen Ziel Flughafen an.")]
        public Airport ToAirport { get; set; } = new();

        [Required(ErrorMessage = "Bitte geben Sie ein Startdatum an.")]
        public DateTime? StartVacationDate { get; set; }

        public DateTime? EndVacationDate { get; set; }

        public TravelClass? TravelClass { get; set; } = Models.TravelClass.Economy;
        public FoodVariation? Food { get; set; } = null;

        public int Adults { get; set; } = 1;
        public int KidsAboveThreeYears { get; set; }
        public int KidsBelowThreeYears { get; set; }
        public bool WithFood { get; set; }

        public VacationBookingDto()
        {
            Id = Guid.NewGuid();
        }
    }

    public class Person
    {
        [Required]
        [Display(Description = "Vorname")]
        [StringLength(100, ErrorMessage = "Der Name sollte nicht mehr als 100 zeichen haben.")]

        public string FirstName { get; set; }
        
        [Required]
        [Display(Description = "Nachname")]
        [StringLength(100, ErrorMessage = "Der Nachname sollte nicht mehr als 100 zeichen haben.")]
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
    }

    // ToDo: Translate enums values in the UI
    public enum TravelClass
    {
        Economy,
        PremiumEconomy,
        Business,
        First
    }

    public enum FoodVariation
    {
        Meat,
        Fish,
        Vegitarian,
        Vegan
    }
}