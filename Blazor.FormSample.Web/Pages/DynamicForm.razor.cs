using System;
using System.Linq;
using System.Threading.Tasks;
using Blazor.FormSample.Web.Models;
using Blazor.FormSample.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Blazor.FormSample.Web.Pages
{
    public partial class DynamicForm
    {
        [Inject] private PersonService _personService { get; set; }
        [Inject] private FormsService _formsService { get; set; }
        [Inject] private NavigationManager _navigationManager { get; set; }
        private Person _person;

        protected override void OnInitialized()
        {
            _person = new Person();
        }

        private RenderFragment CreateForm()
        {
            return _formsService.CreateComponent(_person);
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
                await _personService.AddPerson(_person);
                _person = new Person();
                _navigationManager.NavigateTo("/");
            }
        }
    }
}