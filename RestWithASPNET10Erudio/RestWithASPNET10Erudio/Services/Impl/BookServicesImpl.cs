using RestWithASPNET10Erudio.Model;
using RestWithASPNET10Erudio.Repositories;

namespace RestWithASPNET10Erudio.Services.Impl
{
    public class BookServicesImpl : IBookServices
    {
        private IBookRepository _repository;

        public  BookServicesImpl(IBookRepository repository)
        {
            _repository = repository;
        }

        public Book Create(Book book) => _repository.Create(book);

        public void Delete(long id) => _repository.Delete(id);

        public List<Book> FindAll() => _repository.FindAll();

        public Book FindById(long id) => _repository.FindById(id);

        public Book Update(Book book) => _repository.Update(book);
    }
}
