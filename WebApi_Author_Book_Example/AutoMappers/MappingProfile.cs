using AutoMapper;
using WebApi_Author_Book_Example.DTO;
using WebApi_Author_Book_Example.Model;

namespace WebApi_Author_Book_Example.AutoMappers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDto>().
                ForMember(dest => dest.TotalBookCount, val => val.MapFrom(src => src.Books.Count));
            CreateMap<AuthorDto, Author>();

            CreateMap<Book, BookDto>()
                 .ForMember(dest => dest.DateOfRelease, opt => opt.MapFrom(src => src.DateOfRelease.ToUniversalTime()));
            CreateMap<BookDto, Book>();

            CreateMap<AuthorDetails, AuthorDetailsDto>()
     .ForMember(dest => dest.CityCount, opt => opt.MapFrom(src => src.City.Length));
            CreateMap<AuthorDetailsDto, AuthorDetails>();






        }
    }
}
