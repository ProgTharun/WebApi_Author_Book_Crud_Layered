using WebApi_Author_Book_Example.DTO;
using WebApi_Author_Book_Example.Model;

namespace WebApi_Author_Book_Example.Service
{
    public interface IBookService
    {
        public List<BookDto> Get();

        public Book GetId(int id);

        public int Add(BookDto bookdto);
        public Book UpdaeteStudent(BookDto bookdto);
        public bool DeteleStudent(int id);
        public List<BookDto> GetBooksByAuthorId(int authorId);
    }
}
