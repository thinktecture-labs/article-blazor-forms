using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.FormSample.Web.Dialogs;
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
        [Inject] private ISnackbar _snackbar { get; set; }

        private List<Person> _people;

        protected override async Task OnInitializedAsync()
        {
            _people = await _personService.PersonsAsync();
            StateHasChanged();
            await base.OnInitializedAsync();
        }

        private async Task OpenDialog(bool dynamic, Person person = null)
        {
            var result = dynamic
                ? await _dialogService.Show<AddPersonDynamicFormDialog>("Dynamic Form", new DialogParameters
                {
                    ["Person"] = person
                }).Result
                : await _dialogService.Show<AddPersonStaticDialog>("Dynamic Form").Result;

            var name = String.IsNullOrWhiteSpace(person?.Name) ? "Person" : person.Name;
            if (result?.Data != null && (bool) result.Data)
            {
                var action = person == null ? "angelegt" : "aktuallisiert";
                _snackbar.Add($"{name} wurde erfolgreich {action}.", Severity.Success);
            }
            else
            {
                _snackbar.Add($"Speichern von {name} ist fehlgeschlagen.", Severity.Error);
            }
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