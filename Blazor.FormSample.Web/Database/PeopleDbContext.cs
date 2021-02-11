using Blazor.FormSample.Web.Models;
using Blazor.IndexedDB.WebAssembly;
using Microsoft.JSInterop;

namespace Blazor.FormSample.Web.Database
{
    public class PeopleDbContext : IndexedDb
    {
        public PeopleDbContext(IJSRuntime jSRuntime, string name, int version) : base(jSRuntime, name, version) { }
        public IndexedSet<Person> People { get; set; }
    }
}
