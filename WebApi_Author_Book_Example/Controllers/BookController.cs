using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Author_Book_Example.DTO;
using WebApi_Author_Book_Example.Model;
using WebApi_Author_Book_Example.Service;

namespace WebApi_Author_Book_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var authors = _bookService.Get();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var books = _bookService.GetId(id);
            if (books != null)
            {
                return Ok(books);
            }
            return NotFound();

        }
        [HttpPost]
        public ActionResult Add(BookDto bookdto)
        {
            var result = _bookService.Add(bookdto);

            return CreatedAtAction(nameof(Add), result);
        }

        [HttpPut()]
        public IActionResult UpdateBook(BookDto bookDto)
        {
         
            var updatedBook = _bookService.UpdaeteStudent(bookDto);

            
            if (updatedBook != null)
            {
                return Ok(updatedBook); 
            }

            return NotFound("Book not found or could not be updated.");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var del = _bookService.GetId(id);
            if(del!=null)
            {
                _bookService.DeteleStudent(id);
                return Ok(del);

            }
            return NotFound();
        }
        [HttpGet("{authorId}")]
        public ActionResult<List<BookDto>> GetBooksByAuthorId(int authorId)
        {
            var booksDto = _bookService.GetBooksByAuthorId(authorId);

            if (booksDto == null || booksDto.Count == 0)
            {
                return NotFound();
            }

            return Ok(booksDto);
        }

    }
}

