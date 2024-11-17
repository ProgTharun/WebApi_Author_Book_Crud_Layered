using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_Author_Book_Example.Model
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public List<Book> ? Books { get; set; }

         public AuthorDetails ? AuthorDetails { get; set; }
        [ForeignKey("AuthorDetails")]
        public int ? AuthorDetailsId { get; set; }


    }
}
