using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects.AuthorDtos;
using Shared.DataTransferObjects.BookDtos;
using Shared.DataTransferObjects.Genre;
using Shared.DataTransferObjects.TransactionDtos;

namespace Task.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(b => b.AuthorName, opt => opt.MapFrom(b => b.Author.Name))
                .ForMember(b => b.GenreTitle, opt => opt.MapFrom(b => b.Genre.Title));
            CreateMap<BookForManipulationDto, Book>();
            CreateMap<BookForManipulationDto, BookDto>();
            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorForManipulationDto, Author>();
            CreateMap<AuthorForManipulationDto, AuthorDto>().ReverseMap();
            CreateMap<Genre, GenreDto>();
            CreateMap<Transaction, TransactionDto>()
                .ForMember(b => b.bookTitle, opt => opt.MapFrom(t => t.Book.Title))
                .ForMember(b => b.borrowDate, opt => opt.MapFrom(t => t.BorrowedAt))
                .ForMember(b => b.returnDate, opt => opt.MapFrom(t => t.ReturnedAt));
            CreateMap<Transaction, TransactionForManipulationDto>();
        }
    }
}
