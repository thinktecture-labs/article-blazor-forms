using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.FormSample.Web.Database;
using Blazor.FormSample.Web.Models;
using Blazor.IndexedDB.WebAssembly;

namespace Blazor.FormSample.Web.Services
{
    public class PersonService
    {
        private static List<Person> _persons = new();
        private readonly IIndexedDbFactory _dbFactory;

        public PersonService(IIndexedDbFactory dbFactory)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
        }

        public async Task AddPersonAsync(Person person)
        {
            using (var db = await _dbFactory.Create<PeopleDbContext>())
            {
                db.People.Add(person);
                await db.SaveChanges();
            }

            _persons.Add(person);
        }

        public async Task UpdatePersonAsync(Person person)
        {
            using var db = await _dbFactory.Create<PeopleDbContext>();
            var currentPerson = db.People.FirstOrDefault(p => p.Id == person.Id);
            if (currentPerson != null)
            {
                currentPerson.Job = person.Job;
                currentPerson.BirthDate = person.BirthDate;
                currentPerson.PictureUrl = person.PictureUrl;
                await db.SaveChanges();
                _persons = db.People.ToList();
            }
        }

        public void DeletePerson(Person person)
        {
            _persons.Remove(person);
        }

        public async Task<List<Person>> PersonsAsync()
        {
            if (!_persons.Any())
            {
                using (var db = await _dbFactory.Create<PeopleDbContext>())
                {
                    _persons = db.People.ToList();
                }
            }

            return _persons;
        }
    }
}