using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.FormSample.Web.Services;
using Blazor.IndexedDB.WebAssembly;
using FluentValidation;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;

namespace Blazor.FormSample.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(
                sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
            builder.Services.AddScoped<FormsService>();
            builder.Services.AddScoped<PersonService>();
            builder.Services.AddScoped<IIndexedDbFactory, IndexedDbFactory>();
            builder.Services.AddValidatorsFromAssemblyContaining<Program>();
            builder.Services.AddMudBlazorDialog();
            builder.Services.AddMudBlazorSnackbar();
            builder.Services.AddMudBlazorResizeListener();

            await builder.Build().RunAsync();
        }
    }
}