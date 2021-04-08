using System;
using System.Collections.Generic;

namespace Blazor.FormSample.Web.Models
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<Airport> Airports { get; set; }
    }
}