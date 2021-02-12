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
            builder.Services.AddScoped<IFormsService, MudFormsService>();
            // builder.Services.AddScoped<IFormsService, FormsService>();
            builder.Services.AddScoped<PersonService>();
            builder.Services.AddScoped<IIndexedDbFactory, IndexedDbFactory>();
            builder.Services.AddValidatorsFromAssemblyContaining<Program>();
            builder.Services.AddMudBlazorDialog();
            builder.Services.AddMudBlazorResizeListener();
            builder.Services.AddMudBlazorSnackbar(config =>
            {
                config.PositionClass = Defaults.Classes.Position.TopCenter;
                config.PreventDuplicates = false;
                config.NewestOnTop = false;
                config.ShowCloseIcon = false;
                config.VisibleStateDuration = 1000;
                config.HideTransitionDuration = 500;
                config.ShowTransitionDuration = 500;
            });

            await builder.Build().RunAsync();
        }
    }
}