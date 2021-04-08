using System.Collections.Generic;
using Blazor.FormSample.Web.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Blazor.FormSample.Web.Dialogs
{
    public partial class MudFormDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; }

        private readonly List<Airport> Airports = new();

        protected override void OnInitialized()
        {
            for (int i = 0; i < 500; i++)
            {
                Airports.Add(new Airport
                {
                    Name = $"Airport {i}"
                });
            }

            base.OnInitialized();
        }

        void Submit() => MudDialog.Close(DialogResult.Ok(true));
        void Cancel() => MudDialog.Cancel();
    }
}