using System;
using System.Threading.Tasks;
using Blazor.FormSample.Web.Models;
using MudBlazor;

namespace Blazor.FormSample.Web.Components.MudForm
{
    public partial class MudInputAirport
    {
        private Func<Airport, string> _convertAirportToString = ci => ci?.Name ?? "";
        private MudSelect<string> _elementReference;

        protected override async Task LoadAirports(string country)
        {
            _elementReference?.CloseMenu();
            if (Country != country)
            {
                Country = country;
                Value = null;
            }
            await base.LoadAirports(country);
        }
    }
}