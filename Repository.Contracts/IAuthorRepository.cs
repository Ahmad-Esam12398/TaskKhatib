using Entities.Models;

namespace Repository.Contracts
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges);
        Task<Author> GetAuthorAsync(Guid id, bool trackChanges);
        void CreateAuthor(Author author);
        void DeleteAuthor(Author author, bool trackChanges);
    }
}
