using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApi_Author_Book_Example.Model;

namespace WebApi_Author_Book_Example.DTO
{
    public class AuthorDto
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

      public int TotalBookCount { get; set; }

       
    }
}
