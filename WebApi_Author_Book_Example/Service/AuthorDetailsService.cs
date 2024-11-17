using AutoMapper;
using WebApi_Author_Book_Example.DTO;
using WebApi_Author_Book_Example.Migrations;
using WebApi_Author_Book_Example.Model;
using WebApi_Author_Book_Example.Repository;

namespace WebApi_Author_Book_Example.Service
{
    public class AuthorDetailsServicecs : IAuthorDetailsService
    {
        private readonly IGenericRepository<AuthorDetails> _authorDetailsrepository;
        private readonly IMapper _mapper;
        public AuthorDetailsServicecs(IGenericRepository<AuthorDetails> authorDetailsRepository,IMapper mapper)
        {
            _authorDetailsrepository= authorDetailsRepository;
            _mapper= mapper;
        }
        public string Add(AuthorDetailsDto authorDetailsDto)
        {
            
            var authorDetails = _mapper.Map<AuthorDetails>(authorDetailsDto);

            
          _authorDetailsrepository.Add(authorDetails);

            
            return "Details Added Successfully";
        }


        public bool DeteleStudent(int id)
        {
            var existingAuthor = _authorDetailsrepository.GetByid(id);
            if (existingAuthor != null)
            {
                _authorDetailsrepository.Delete(existingAuthor);
                return true;
            }
            return false;
        }

        public List<AuthorDetailsDto> Get()
        {
            
            var authors = _authorDetailsrepository.GetAll().ToList();

           
            List<AuthorDetailsDto> dtos = _mapper.Map<List<AuthorDetailsDto>>(authors);

            return dtos;
        }


        public int GetId(int id)
        {
            var Details= _authorDetailsrepository.GetAll();
            var authors=Details.Where(detail=>detail.Id==id).FirstOrDefault();
            return 1;
        }

        public bool UpdaeteStudent(AuthorDetailsDto authorDetailsDto)
        {
            var authorDetails = _mapper.Map<AuthorDetails>(authorDetailsDto);


            var existingAuthor = _authorDetailsrepository.GetAll();

            if (existingAuthor != null)
            {

                _authorDetailsrepository.Update(authorDetails);
                return true;
            }
            return false;
        }
        public AuthorDetailsDto GetAuthorDetailsByAuthorId(int authorId)
        {
            var authorDetails = _authorDetailsrepository.GetAll()
                                                    .FirstOrDefault(ad => ad.Id == authorId);

            if (authorDetails != null)
            {
                var authorDetailsDto = _mapper.Map<AuthorDetailsDto>(authorDetails);
                return authorDetailsDto;

            }
            return null;
        }

    }



}

