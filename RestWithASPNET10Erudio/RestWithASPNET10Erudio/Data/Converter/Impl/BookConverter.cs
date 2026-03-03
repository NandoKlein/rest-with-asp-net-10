using RestWithASPNET10Erudio.Data.Converter.Contract;
using RestWithASPNET10Erudio.Data.DTO;
using RestWithASPNET10Erudio.Model;

namespace RestWithASPNET10Erudio.Data.Converter.Impl
{
    public class BookConverter : IParser<BookDTO, Book>, IParser<Book, BookDTO>
    {
        public Book Parse(BookDTO origin)
        {
            if (origin == null)  return null;
            return new Book
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price
            };
        }

        public List<Book> ParseList(List<BookDTO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public BookDTO Parse(Book origin)
        {
            if (origin == null) return null;
            return new BookDTO
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price
            };
        }

        public List<BookDTO> ParseList(List<Book> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

    }
}
