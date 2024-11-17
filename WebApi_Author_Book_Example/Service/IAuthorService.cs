using WebApi_Author_Book_Example.DTO;
using WebApi_Author_Book_Example.Model;

namespace WebApi_Author_Book_Example.Service
{
    public interface IAuthorService
    {
        public List<AuthorDto> Get();

        public AuthorDto GetId(int id);
        public string Add(AuthorDto authorDto);
        public bool UpdaeteStudent(AuthorDto authordto);
        public bool DeteleStudent(int id);
        public AuthorDto GetAuthorByName(string authorName);
        public AuthorDto GetAuthorByBookId(int bookId);
    }
}
