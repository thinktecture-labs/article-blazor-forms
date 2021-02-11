using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.FormSample.Web.Components.Dialogs;
using Blazor.FormSample.Web.Models;
using Blazor.FormSample.Web.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Blazor.FormSample.Web.Pages
{
    public partial class Index
    {
        [Inject] private PersonService _personService { get; set; }
        [Inject] private NavigationManager _navigationManager { get; set; }

        [Inject] private IDialogService _dialogService { get; set; }

        private List<Person> _people;

        protected override async Task OnInitializedAsync()
        {
            _people = await _personService.Persons();
            StateHasChanged();
            await base.OnInitializedAsync();
        }

        private async Task OpenDialog(bool dynamic)
        {
            var result = dynamic
                ? await _dialogService.Show<AddPersonDynamicFormDialog>("Dynamic Form").Result
                : await _dialogService.Show<AddPersonStaticDialog>("Dynamic Form").Result;
        }

        private void OpenDynamicForm()
        {
            _navigationManager.NavigateTo("/dynamic-form");
        }

        private void OpenStaticForm()
        {
            _navigationManager.NavigateTo("/form");
        }
    }
}