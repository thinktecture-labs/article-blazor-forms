using System;
using Blazor.FormSample.Web.Models;
using MudBlazor;

namespace Blazor.FormSample.Web.Pages
{
    public partial class PerformanceTest
    {
        private bool _enablePerformance;
        private int _tabIndex = 0;
        private Country _country;

        protected override void OnInitialized()
        {
            _country = new Country();
            for (int i = 1; i <= 400; i++)
            {
                _country.Airports.Add(new Airport
                {
                    Id = Guid.NewGuid(),
                    Name = $"Airport {i}"
                });
            }

            base.OnInitialized();
        }
    }
}