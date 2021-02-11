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
            _dbFactory = dbFactory ?? throw new System.ArgumentNullException(nameof(dbFactory));
        }

        public async Task AddPerson(Person person)
        {
            using (var db = await _dbFactory.Create<PeopleDbContext>())
            {
                db.People.Add(person);
                await db.SaveChanges();
            }

            _persons.Add(person);
        }

        public void DeletePerson(Person person)
        {
            _persons.Remove(person);
        }

        public async Task<List<Person>> Persons()
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