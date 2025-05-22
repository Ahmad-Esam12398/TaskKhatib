using Shared.DataTransferObjects.BookDtos;

namespace Services.Contract
{
    public interface IBookService
    {
        Task<BookDto> CreateBookAsync(BookForManipulationDto book);
        Task DeleteBookAsync(Guid bookId, bool trackChanges);
        Task<IEnumerable<BookDto>> GetAllBooksAsync(bool trackChanges);
        Task<BookDto> GetBookAsync(Guid bookId, bool trackChanges);
        Task UpdateBookAsync(Guid bookId, BookForManipulationDto book, bool trackChanges);

    }
}
