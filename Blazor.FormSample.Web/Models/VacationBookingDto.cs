using System;
using System.ComponentModel.DataAnnotations;
using Blazor.FormSample.Web.Shared.ResourceFiles;

namespace Blazor.FormSample.Web.Models
{
    public class VacationBookingDto
    {
        [Key] public Guid Id { get; set; }
        
        // Persondata
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        
        public string PhoneNumber { get; set; }
        public Airport FromAirport { get; set; } = new();
        public bool OnlyOutboundFlight { get; set; }
        public Airport ToAirport { get; set; } = new();
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

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        
        public string PhoneNumber { get; set; }
    }

    public enum TravelClass
    {
        Economy,
        PremiumEconomy,
        Business,
        First
    }
}
