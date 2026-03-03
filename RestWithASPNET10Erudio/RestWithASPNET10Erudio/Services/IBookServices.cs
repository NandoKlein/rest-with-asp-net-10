using RestWithASPNET10Erudio.Data.DTO;
using RestWithASPNET10Erudio.Model;

namespace RestWithASPNET10Erudio.Services
{
    public interface IBookServices
    {
        BookDTO Create(BookDTO person);
        BookDTO FindById(long id);
        List<BookDTO> FindAll();
        BookDTO Update(BookDTO person);
        void Delete(long id);
    }
}
