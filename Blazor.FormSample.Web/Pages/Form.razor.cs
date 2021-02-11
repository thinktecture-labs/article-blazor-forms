using System;
using System.Threading.Tasks;
using Blazor.FormSample.Web.Models;
using Blazor.FormSample.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Blazor.FormSample.Web.Pages
{
    public partial class Form
    {
        [Inject] private PersonService _personService { get; set; }
        [Inject] private NavigationManager _navigationManager { get; set; }

        private Person _person = new Person();

        private async Task OnValidSubmit(EditContext context)
        {
            Console.WriteLine($"{_person.Name} {_person.Email} {_person.BirthDate}");
            await _personService.AddPerson(_person);
            _person = new Person();
            _navigationManager.NavigateTo("/");
            StateHasChanged();
        }
    }
}