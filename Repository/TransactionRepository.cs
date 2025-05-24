using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;

namespace Repository
{
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        public TransactionRepository(RepositoryContext context) : base(context)
        {}

        public async Task CreateTransaction(Transaction transaction)
        {
            Create(transaction);
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync(bool trackChanges)
        {
            return  await FindAll(trackChanges)
                .Include(t => t.Book).ToListAsync();
        }

        public async Task<Transaction> GetOpenTransactionForBookAsync(Guid bookId, bool trackChanges)
        {
            return await FindByCondition(t => t.BookId == bookId && t.ReturnedAt == null, trackChanges)
                .Include(t => t.Book)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsForBookAsync(Guid bookId, bool trackChanges)
        {
            return await FindByCondition(t => t.BookId == bookId, trackChanges)
                .Include(t => t.Book).ToListAsync();
        }
    }
}
