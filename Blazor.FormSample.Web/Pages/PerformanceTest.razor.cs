using System;
using System.Collections.Generic;
using Blazor.FormSample.Web.Models;

namespace Blazor.FormSample.Web.Pages
{
    public partial class PerformanceTest
    {
        private string Content { get; set; } = new('x', 10000);

        private bool _enablePerformance;
        private Country Country;

        protected override void OnInitialized()
        {
            Country = new Country();
            for (int i = 1; i <= 250; i++)
            {
                Country.Airports.Add(new Airport
                {
                    Id = Guid.NewGuid(),
                    Name = $"Airport {i}"
                });
            }

            base.OnInitialized();
        }   
    }
}