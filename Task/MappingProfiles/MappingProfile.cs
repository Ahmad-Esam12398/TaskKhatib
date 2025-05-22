using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects.AuthorDtos;
using Shared.DataTransferObjects.BookDtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Task.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(b => b.AuthorName, opt => opt.MapFrom(b => b.Author.Name))
                .ReverseMap();
            CreateMap<BookForManipulationDto, Book>();
            CreateMap<BookForManipulationDto, BookDto>();
            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorForManipulationDto, Author>();
            CreateMap<AuthorForManipulationDto, AuthorDto>().ReverseMap();
        }
    }
}
