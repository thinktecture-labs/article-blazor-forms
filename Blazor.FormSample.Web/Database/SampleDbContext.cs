using Blazor.FormSample.Web.Models;
using Blazor.IndexedDB.WebAssembly;
using Microsoft.JSInterop;

namespace Blazor.FormSample.Web.Database
{
    public class SampleDbContext : IndexedDb
    {
        public SampleDbContext(IJSRuntime jSRuntime, string name, int version) 
            : base(jSRuntime, name, version)
        {
        }

        public IndexedSet<VacationBookingDto> Bookings { get; set; }
        public IndexedSet<Country> Countries { get; set; }
        public IndexedSet<Airport> Airports { get; set; }
    }
}