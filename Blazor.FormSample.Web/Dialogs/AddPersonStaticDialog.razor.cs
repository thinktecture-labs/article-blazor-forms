using System;
using System.Linq;
using System.Threading.Tasks;
using Blazor.FormSample.Web.Models;
using Blazor.FormSample.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace Blazor.FormSample.Web.Dialogs
{
    public partial class AddPersonStaticDialog
    {
        [Inject] private PersonService _personService { get; set; }
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        private Person _person;

        protected override void OnInitialized()
        {
            _person = new Person();
        }

        private async Task Submit(EditContext context)
        {
            await Task.Delay(250);
            Console.WriteLine($"Form is valid: {context.Validate()}");
            Console.WriteLine($"Form is modified: {context.IsModified()}");
            Console.WriteLine($"Form is ValidationMessages: {String.Join(",", context.GetValidationMessages())}");
            if (!context.GetValidationMessages().Any())
            {
                Console.WriteLine($"{_person.Name} {_person.Email} {_person.BirthDate}");
                await _personService.AddPersonAsync(_person);
                _person = new Person();
                MudDialog.Close(DialogResult.Ok(true));
            }
        }
    }
}