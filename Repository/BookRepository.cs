using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System.Runtime.CompilerServices;

namespace Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext _context) : base(_context)
        {}
        public void CreateBook(Book book)
        {
            Create(book);
        }

        public void DeleteBook(Book book, bool trackChanges)
        {
            Delete(book);
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).Include(b => b.Author)
                .OrderBy(b => b.Title).ToListAsync();
        }

        public async Task<Book> GetBookAsync(Guid id, bool trackChanges)
        {
            return await FindByCondition(b => b.Id.Equals(id), trackChanges)
                .Include(b => b.Author)
                .SingleOrDefaultAsync();
        }
    }
}
