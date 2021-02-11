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
    public partial class AddPersonDynamicFormDialog
    {
        [Inject] private PersonService _personService { get; set; }
        [Inject] private IFormsService _formsService { get; set; }
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public Person Person { get; set; } = new();

        private EditForm PersonForm;
        private Person _person;
        private bool _update;

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (PersonForm?.EditContext != null)
            {
                Console.WriteLine("Form is created");
                PersonForm.EditContext.OnFieldChanged += (sender, args) =>
                {
                    Console.WriteLine($"Field Changed: {sender} {args}");
                    StateHasChanged();
                };
            }

            return base.OnAfterRenderAsync(firstRender);
        }

        protected override void OnInitialized()
        {
            _update = Person != null;
            _person = Person ?? new Person();
            base.OnInitialized();
        }

        private RenderFragment CreateForm()
        {
            return _formsService.CreateComponent(_person, PersonForm.EditContext);
        }

        private async Task Submit(EditContext context)
        {
            StateHasChanged();
            Console.WriteLine($"Form is valid: {context.Validate()}");
            Console.WriteLine($"Form is modified: {context.IsModified()}");
            Console.WriteLine($"Form is ValidationMessages: {String.Join(",", context.GetValidationMessages())}");
            if (!context.GetValidationMessages().Any())
            {
                if (_update)
                {
                    await _personService.UpdatePersonAsync(_person);
                }
                else
                {
                    await _personService.AddPersonAsync(_person);
                }

                MudDialog.Close(DialogResult.Ok(true));
            }
        }
    }
}