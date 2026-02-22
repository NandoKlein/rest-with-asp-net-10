using RestWithASPNET10Erudio.Model;
using RestWithASPNET10Erudio.Model.Context;
using RestWithASPNET10Erudio.Repositories;
using System;

namespace RestWithASPNET10Erudio.Services.Impl
{
    public class PersonServicesImpl : IPersonServices
    {

        private IPersonRepository _repository;

        public PersonServicesImpl(IPersonRepository repository)
        {
            _repository = repository;
        }
        public List<Person> FindAll() => _repository.FindAll();

        public Person FindById(long id) => _repository.FindById(id);

        public Person Create(Person person) => _repository.Create(person);

        public Person Update(Person person) => _repository.Update(person);

        public void Delete(long id) => _repository.Delete(id);
    }
}
