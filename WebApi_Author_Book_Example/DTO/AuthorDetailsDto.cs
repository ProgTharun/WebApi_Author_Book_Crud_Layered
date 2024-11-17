using WebApi_Author_Book_Example.Model;

namespace WebApi_Author_Book_Example.DTO
{
    public class AuthorDetailsDto
    {
        public int Id { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
         
        public int CityCount { get; set; }

      
    }
}
