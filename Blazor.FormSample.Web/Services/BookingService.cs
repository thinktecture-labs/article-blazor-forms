using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Blazor.FormSample.Web.Database;
using Blazor.FormSample.Web.Models;
using Blazor.IndexedDB.WebAssembly;

namespace Blazor.FormSample.Web.Services
{
    public class BookingService
    {
        private readonly IIndexedDbFactory _dbFactory;
        private readonly HttpClient _httpClient;

        public BookingService(IIndexedDbFactory dbFactory, HttpClient httpClient)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task InitializeDbASync()
        {
            using var db = await _dbFactory.Create<SampleDbContext>();
            if (db.Countries.Count > 0 && db.Airports.Count > 0)
            {
                return;
            }

            var countries = await _httpClient.GetFromJsonAsync<Country[]>("sample-data/airports.json");
            if (countries != null)
            {
                foreach (var country in countries)
                {
                    var countryId = Guid.NewGuid();
                    db.Countries.Add(new Country
                    {
                        Id = countryId,
                        Name = country.Name,
                    });
                    foreach (var airport in country.Airports)
                    {
                        db.Airports.Add(new Airport
                        {
                            Id = Guid.NewGuid(),
                            City = airport.City,
                            Name = airport.Name,
                            State = airport.State,
                            ShortName = airport.ShortName,
                            CountryId = countryId
                        });
                    }
                }

                await db.SaveChanges();
            }
        }

        public async Task<List<Country>> CountriesAsync()
        {
            using var db = await _dbFactory.Create<SampleDbContext>();
            return db.Countries.ToList();
        }

        public async Task<List<Airport>> AirportsByCountryNameAsync(string name)
        {
            using var db = await _dbFactory.Create<SampleDbContext>();
            var country = db.Countries.FirstOrDefault(c => c.Name == name);
            Console.WriteLine($"Found country for {name}: {country?.Id}.");
            await Task.Delay(2000);
            return country != null
                ? db.Airports.Where(a => a.CountryId == country.Id).ToList()
                : new List<Airport>();
        }

        public async Task AddBookingAsync(VacationBookingDto booking)
        {
            using var db = await _dbFactory.Create<SampleDbContext>();
            Console.WriteLine(JsonSerializer.Serialize(booking));
            db.Bookings.Add(booking);
            await db.SaveChanges();
        }

        public async Task DeleteBookingAsync(VacationBookingDto booking)
        {
            using var db = await _dbFactory.Create<SampleDbContext>();
            db.Bookings.Remove(booking);
            await db.SaveChanges();
        }

        public async Task<List<VacationBookingDto>> BookingsAsync()
        {
            using var db = await _dbFactory.Create<SampleDbContext>();
            return db.Bookings.ToList();
        }

        public async Task<VacationBookingDto> GetBookingAsync(Guid id)
        {
            using var db = await _dbFactory.Create<SampleDbContext>();
            return db.Bookings.FirstOrDefault(b => b.Id == id);
        }

        /*public async Task<bool> PersonAlreadyExists(string name)
        {
            using var db = await _dbFactory.Create<SampleDbContext>();
            return db.Bookings.Any(b => b.Person.FirstName == name);
        }*/
    }
}
