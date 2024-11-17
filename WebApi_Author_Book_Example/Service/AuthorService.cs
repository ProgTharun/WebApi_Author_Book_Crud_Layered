using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApi_Author_Book_Example.AutoMappers;
using WebApi_Author_Book_Example.DTO;
using WebApi_Author_Book_Example.Exceptions;
using WebApi_Author_Book_Example.Migrations;
using WebApi_Author_Book_Example.Model;
using WebApi_Author_Book_Example.Repository;

namespace WebApi_Author_Book_Example.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IGenericRepository<Author> _authorRepository;
      
        private readonly IMapper _mapper;

        public AuthorService(IGenericRepository<Author> authorRepository,IMapper mapper)
        {
            _authorRepository = authorRepository;   
            _mapper = mapper;
           
        }
        public string Add(AuthorDto authorDto)
        {
          var authors=_mapper.Map<Author>(authorDto);
                _authorRepository.Add(authors);
            return "Added Succesfully";

        }

        public bool DeteleStudent(int id)
        {
            var existingAuthor = _authorRepository.GetByid(id);
            if (existingAuthor != null)
            {
                _authorRepository.Delete(existingAuthor);
                return true;
            }
            return false;
        }

        public List<AuthorDto> Get()
        {
           var author= _authorRepository.GetAll().Include(a=>a.Books).Include(b=>b.AuthorDetails).ToList();
            List<AuthorDto> authorDtos=_mapper.Map<List<AuthorDto>>(author);
            return authorDtos;
        }

        public AuthorDto GetId(int id)
        {
            var author = _authorRepository.GetAll().FirstOrDefault(book => book.Id == id);
            if (author == null)
            {
                throw new AuthorNotFoundException("Invalid Id");
                
            }
            var authorDto = _mapper.Map<AuthorDto>(author);

            return authorDto;
        }

        public bool UpdaeteStudent(AuthorDto authordto)
        {
            var existingAuthor = _authorRepository.GetAll().AsNoTracking().FirstOrDefault(c=>c.Id==authordto.Id);

            if (existingAuthor != null)
            {
                var updaeted=_mapper.Map<AuthorDto>(authordto);
                _authorRepository.Update(existingAuthor);

                return true;
            }
            return false;

        }

        public AuthorDto GetAuthorByName(string authorName)
        {
            var author = _authorRepository
                .GetAll()
                .FirstOrDefault(a => a.Name.Contains(authorName));
            if (author != null)
            {
                var authorDto = _mapper.Map<AuthorDto>(author);
                return authorDto;

            }
            return null;


        }
        public AuthorDto GetAuthorByBookId(int bookId)
        {
           var author=_authorRepository .GetAll().Include(a=>a.Books).FirstOrDefault(b=>b.Id==bookId);

            var authorDto = _mapper.Map<AuthorDto>(author);
            return authorDto;
        }
    }
}
