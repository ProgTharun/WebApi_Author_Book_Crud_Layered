using AutoMapper;
using WebApi_Author_Book_Example.DTO;
using WebApi_Author_Book_Example.Migrations;
using WebApi_Author_Book_Example.Model;
using WebApi_Author_Book_Example.Repository;

namespace WebApi_Author_Book_Example.Service
{
    public class BookService : IBookService
    {
        private readonly IGenericRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IGenericRepository<Book> bookRepository,IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public int Add(BookDto bookdto)
        {
            var book = _mapper.Map<Book>(bookdto);
            var addedBook = _bookRepository.Add(book);
            return 1;
        }

        public  bool DeteleStudent(int id)
        {
            var existingbook = _bookRepository.GetByid(id);
            if (existingbook != null)
            {
                _bookRepository.Delete(existingbook);
                return true;
            }
            return false;
        }

        public List<BookDto> Get()
        {
          var book= _bookRepository.GetAll().ToList();
            List<BookDto>bookDtos=_mapper.Map<List<BookDto>>(book);
            return bookDtos;
        }

        public Book GetId(int id)
        {
            var exsid = _bookRepository.GetAll();
            var book = exsid.Where(book=> book.Id == id).FirstOrDefault();
            return book;
        }

        public Book UpdaeteStudent(BookDto bookdto)
        {
            var book = _mapper.Map<Book>(bookdto);
            var updatedBook = _bookRepository.Update(book);

            if (updatedBook != null)
            {
                return updatedBook;
            }

            return book;
        }
        public List<BookDto> GetBooksByAuthorId(int authorId)
        {
            var books = _bookRepository.GetAll().Where(b => b.Id == authorId).ToList();

            if (books.Count == 0)
            {
                return new List<BookDto>();
            }

            var booksDto = _mapper.Map<List<BookDto>>(books);
            return booksDto;
        }
        



    }

}

