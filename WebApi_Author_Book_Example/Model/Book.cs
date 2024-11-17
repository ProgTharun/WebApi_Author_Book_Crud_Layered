using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_Author_Book_Example.Model
{
    public class Book
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }

        public DateTime DateOfRelease { get; set; }

        

    }
}
