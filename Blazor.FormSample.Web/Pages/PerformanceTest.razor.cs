using System;
using System.Collections.Generic;
using Blazor.FormSample.Web.Models;

namespace Blazor.FormSample.Web.Pages
{
    public partial class PerformanceTest
    {
        private string Content { get; set; } = new('x', 10000);

        private bool _enablePerformance;
        private readonly List<Airport> Airports = new();


        protected override void OnInitialized()
        {
            for (int i = 1; i <= 250; i++)
            {
                Airports.Add(new Airport
                {
                    Id = Guid.NewGuid(),
                    Name = $"Airport {i}"
                });
            }

            base.OnInitialized();
        }   
    }
}