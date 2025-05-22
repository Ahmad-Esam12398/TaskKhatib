using Entities.Models;
using Shared.DataTransferObjects.AuthorDtos;
using Shared.DataTransferObjects.BookDtos;

namespace Services.Contract
{
    public interface IAuthorService
    {
        Task<AuthorDto> CreateAuthorAsync(AuthorForManipulationDto author);
        Task DeleteAuthorAsync(Guid authorId, bool trackChanges);
        Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync(bool trackChanges);
        Task<AuthorDto> GetAuthorAsync(Guid bookId, bool trackChanges);
        Task UpdateAuthorAsync(Guid bookId, AuthorForManipulationDto book, bool trackChanges);
    }
}
