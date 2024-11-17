using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Author_Book_Example.DTO;
using WebApi_Author_Book_Example.Model;
using WebApi_Author_Book_Example.Service;

namespace WebApi_Author_Book_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorDetailsController : ControllerBase
    {
        private readonly IAuthorDetailsService _authorService;
        public AuthorDetailsController(IAuthorDetailsService authorService)
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
            var authors = _authorService.GetId(id);
            if (authors != null)
            {
                return Ok(authors);
            }
            return NotFound();

        }
        [HttpPost]
        public ActionResult Add(AuthorDetailsDto authorDto)
        {
            var result = _authorService.Add(authorDto);

            return CreatedAtAction(nameof(Add), result);
        }

        [HttpPut()]
        public IActionResult UpdateStudent(AuthorDetailsDto authorDto)
        {
            var updateSuccessful = _authorService.UpdaeteStudent(authorDto);

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
        [HttpGet("{authorId}")]
        public ActionResult<AuthorDetailsDto> GetAuthorDetailsByAuthorId(int authorId)
        {
            var authorDetailsDto = _authorService.GetAuthorDetailsByAuthorId(authorId);
            if (authorDetailsDto == null)
            {
                return NotFound("No Author Details Found");
            }

            return Ok(authorDetailsDto);
        }

    }
}
