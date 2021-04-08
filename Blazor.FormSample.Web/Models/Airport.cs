using System;
using System.ComponentModel.DataAnnotations;

namespace Blazor.FormSample.Web.Models
{
    public class Airport
    {
        [Key] public Guid Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public Guid CountryId { get; set; }
    }
}