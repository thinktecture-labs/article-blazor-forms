using System;
using System.Linq;
using Blazor.FormSample.Web.Database;
using Blazor.FormSample.Web.Models;
using Blazor.IndexedDB.WebAssembly;
using FluentValidation;

namespace Blazor.FormSample.Web.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator(IIndexedDbFactory _dbFactory)
        {
            RuleFor(person => person.Name).CustomAsync(async (name, context, token) =>
            {
                Console.WriteLine("Validate Name");
                using var db = await _dbFactory.Create<PeopleDbContext>();
                var person = db.People.FirstOrDefault(p => p.Name == name);
                if (person != null)
                {
                    context.AddFailure("Person already exists");
                }
            });
        }
    }
}