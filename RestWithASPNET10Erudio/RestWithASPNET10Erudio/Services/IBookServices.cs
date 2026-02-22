using RestWithASPNET10Erudio.Model;

namespace RestWithASPNET10Erudio.Services
{
    public interface IBookServices
    {
        Book Create(Book person);
        Book FindById(long id);
        List<Book> FindAll();
        Book Update(Book person);
        void Delete(long id);
    }
}
