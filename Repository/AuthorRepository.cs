using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;

namespace Repository
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryContext _context) : base(_context)
        {}
        public void CreateAuthor(Author author)
        {
            Create(author);
        }

        public void DeleteAuthor(Author author, bool trackChanges)
        {
            Delete(author);
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(a => a.Name).ToListAsync();
        }

        public async Task<Author> GetAuthorAsync(Guid id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id.Equals(id), trackChanges)
                .Include(a => a.Books)
                .SingleOrDefaultAsync();
        }
    }
}
