using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Author_Book_Example.DTO;
using WebApi_Author_Book_Example.Model;
using WebApi_Author_Book_Example.Service;

namespace WebApi_Author_Book_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpGet]
        public ActionResult Get()
        {
          

            var authors = _authorService.Get();

                return Ok(authors);
            
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var authors  = _authorService.GetId(id);
            if (authors != null)
            {
                return Ok(authors);
            }
            return NotFound();

        }
        [HttpPost]
        public ActionResult Add(AuthorDto authordto)
        { 
            var result = _authorService.Add(authordto);

            return CreatedAtAction(nameof(Add), result);
        }

        [HttpPut()]
        public IActionResult UpdateStudent(AuthorDto authordto)
        {
            var updateSuccessful = _authorService.UpdaeteStudent(authordto);

            if (updateSuccessful)
            {
                return Ok(updateSuccessful);
            }

            return NotFound("Student  id not found For Updation.");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var deleteSuccessful = _authorService.GetId(id);
            if (deleteSuccessful!=null)
            {
                _authorService.DeteleStudent(id);
                return Ok(deleteSuccessful);
                
            }

            return NotFound("Student not found For Deletion");
        }
        [HttpGet("Name")]
        public ActionResult<AuthorDto> GetAuthorByName(string authorName)
        {
            var authorDto = _authorService.GetAuthorByName(authorName);
            if (authorDto != null)
            {
                return Ok(authorDto);

            }
            return NotFound("No Such Authors Exist");

        }
        [HttpGet("{bookId}")]
public ActionResult<AuthorDto> GetAuthorByBookId(int bookId)
{
    var authorDto = _authorService.GetAuthorByBookId(bookId);

    if (authorDto == null)
    {
        return NotFound("No Such Book Id Exists"); 
    }

    return Ok(authorDto);
}

    }
}

