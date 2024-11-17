using WebApi_Author_Book_Example.DTO;
using WebApi_Author_Book_Example.Model;

namespace WebApi_Author_Book_Example.Service
{
    public interface IAuthorDetailsService
    {
        public List<AuthorDetailsDto> Get();

        public int GetId(int id);

        public string Add(AuthorDetailsDto authorDetailsDto);
        public bool UpdaeteStudent(AuthorDetailsDto authorDetailsDto);
        public bool DeteleStudent(int id);
        public AuthorDetailsDto GetAuthorDetailsByAuthorId(int authorId);
      
    }
}
