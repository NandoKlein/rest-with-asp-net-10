using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10Erudio.Model;
using RestWithASPNET10Erudio.Services;

namespace RestWithASPNET10Erudio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class BookController : ControllerBase
    {
        private readonly IBookServices _bookSevices;
        private readonly ILogger<BookController> _logger;


        public BookController(IBookServices bookSevices, ILogger<BookController> logger)
        {
            _bookSevices = bookSevices;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Fetching all books.");
            return Ok(_bookSevices.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Fetching book with Id {id}.", id);
            var book = _bookSevices.FindById(id);
            if (book == null)
            {
                _logger.LogWarning("Book with Id {id} not found", id);
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            _logger.LogInformation("Creating new book: {title}.", book.Title);
            var createdBook = _bookSevices.Create(book);
            if (createdBook == null)
            {
                _logger.LogError("Failed to create book with title {title}", book.Title);
                return NotFound();
            }
            return Ok(createdBook);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            _logger.LogInformation("Updating book with Id {id}.", book.Id);
            var createdBook = _bookSevices.Update(book);
            if (createdBook == null)
            {
                _logger.LogError("Failed to update book with Id {id} not found", book.Id);
                return NotFound();
            }
            _logger.LogDebug("Book updated successfully: {title} ", createdBook.Title);
            return Ok(createdBook);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deleting book with Id {id}.", id);
            _bookSevices.Delete(id);
            _logger.LogDebug("Book with Id {id} deleted successfully ", id);
            return NoContent();
        }
    }
}
