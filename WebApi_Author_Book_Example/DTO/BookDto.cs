using System.ComponentModel.DataAnnotations.Schema;
using WebApi_Author_Book_Example.Model;

namespace WebApi_Author_Book_Example.DTO
{
    public class BookDto
    {



        public int Id { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }

        public DateTime DateOfRelease { get; set; }
       
    }
}
