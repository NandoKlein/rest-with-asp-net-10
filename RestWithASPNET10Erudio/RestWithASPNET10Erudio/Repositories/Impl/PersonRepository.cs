using RestWithASPNET10Erudio.Model;
using RestWithASPNET10Erudio.Model.Context;

namespace RestWithASPNET10Erudio.Repositories.Impl
{
    public class PersonRepository : IPersonRepository
    {
        private MSSQLContext _context;

        public PersonRepository(MSSQLContext context)
        {
            _context = context;
        }
        public List<Person> FindAll() => _context.Persons.ToList();

        public Person FindById(long id) => _context.Persons.Find(id);

        public Person Create(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
            return person;
        }
        public Person Update(Person person)
        {
            var existingPerson = _context.Persons.Find(person.Id);
            if (existingPerson == null) return null;

            _context.Entry(existingPerson).CurrentValues.SetValues(person);
            _context.SaveChanges();
            return person;
        }

        public void Delete(long id)
        {
            var existingPerson = _context.Persons.Find(id);
            if (existingPerson == null) return;
            _context.Remove(existingPerson);
            _context.SaveChanges();

        }
    }
}
