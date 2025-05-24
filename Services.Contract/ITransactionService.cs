using Shared.DataTransferObjects.TransactionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetTransactionsForBookAsync(Guid bookId, bool trackChanges);
        Task<TransactionDto> GetOpenTransactionForBookAsync(Guid bookId, bool trackChanges);
        Task<IEnumerable<TransactionDto>> GetAllTransactionsAsync(bool trackChanges);
        Task CreateTransactionAsync(TransactionForManipulationDto transaction);
    }
}
