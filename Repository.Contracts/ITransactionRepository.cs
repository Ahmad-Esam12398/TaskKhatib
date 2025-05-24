using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface ITransactionRepository
    {
        Task CreateTransaction(Transaction transaction);
        Task<IEnumerable<Transaction>> GetTransactionsForBookAsync(Guid bookId, bool trackChanges);
        Task<Transaction> GetOpenTransactionForBookAsync(Guid bookId, bool trackChanges);
        Task<IEnumerable<Transaction>> GetAllTransactionsAsync(bool trackChanges);    
    }
}
