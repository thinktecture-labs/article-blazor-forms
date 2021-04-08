using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blazor.FormSample.Web.Models;
using Blazor.FormSample.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Blazor.FormSample.Web.Components
{
    public class InputAirportBase : InputBase<Airport>
    {
        [Parameter] public string CountryLabel { get; set; }
        [Parameter] public string AirportLabel { get; set; }
        [Parameter] public Expression<Func<Airport>> ValidationFor { get; set; }
        [Inject] private BookingService BookingService { get; set; }

        protected string Country;
        protected List<Country> Countries;
        protected List<Airport> Airports;
        protected bool LoadingAirports;

        protected override async Task OnInitializedAsync()
        {
            Countries = await BookingService.CountriesAsync();
            if (Value != null)
            {
                Country = Countries.FirstOrDefault(c => c.Id == Value.CountryId)?.Name;
                await LoadAirports(Country);
            }
            else if (!String.IsNullOrWhiteSpace(Country))
            {
                var currentCountry = Countries.FirstOrDefault(c => c.Name == Country);
                if (currentCountry != null && currentCountry?.Id != Guid.Empty)
                {
                    await LoadAirports(Country);
                    Value = Airports.FirstOrDefault(a => a.CountryId == currentCountry.Id);
                }
            }

            EditContext.OnFieldChanged += async (field, args) =>
            {
                if (args.FieldIdentifier.FieldName == nameof(Country))
                {
                    await LoadAirports(Country);
                }
            };
            await base.OnInitializedAsync();
        }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            if (parameters.TryGetValue<string>(nameof(Country), out var country))
            {
                Console.WriteLine("SetParameterAsync Called for Country.");
                await LoadAirports(country);
            }

            await base.SetParametersAsync(parameters);
        }

        protected override bool TryParseValueFromString(string value, out Airport result,
            out string validationErrorMessage)
        {
            result = Value;
            validationErrorMessage = null;
            return true;
        }

        protected virtual async Task LoadAirports(string country)
        {
            if (!String.IsNullOrWhiteSpace(country))
            {
                LoadingAirports = true;
                Airports = await BookingService.AirportsByCountryNameAsync(country);
                LoadingAirports = false;
            }

            StateHasChanged();
        }
    }
}