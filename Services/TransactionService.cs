using AutoMapper;
using Entities.Models;
using Repository.Contracts;
using Services.Contracts;
using Shared.DataTransferObjects.TransactionDtos;

namespace Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public TransactionService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task CreateTransactionAsync(TransactionForManipulationDto transaction)
        {
            Transaction transactionEntity = _mapper.Map<Transaction>(transaction);
            _repositoryManager.Transaction.CreateTransaction(transactionEntity);
        }

        public async Task<IEnumerable<TransactionDto>> GetAllTransactionsAsync(bool trackChanges)
        {
            var transactions = await _repositoryManager.Transaction.GetAllTransactionsAsync(trackChanges);
            var transactionsDto = _mapper.Map<IEnumerable<TransactionDto>>(transactions);
            return transactionsDto;
        }
        public async Task<TransactionDto> GetOpenTransactionForBookAsync(Guid bookId, bool trackChanges)
        {
            var transaction = await _repositoryManager.Transaction.GetOpenTransactionForBookAsync(bookId, trackChanges);
            if (transaction is null)
                throw new KeyNotFoundException($"No open transaction found for book with ID {bookId}.");
            return _mapper.Map<TransactionDto>(transaction);
        }

        public async Task<IEnumerable<TransactionDto>> GetTransactionsForBookAsync(Guid bookId, bool trackChanges)
        {
            var transactions = await _repositoryManager.Transaction.GetTransactionsForBookAsync(bookId, trackChanges);
            if (transactions is null)
                throw new KeyNotFoundException($"No transactions found for book with ID {bookId}.");
            return _mapper.Map<IEnumerable<TransactionDto>>(transactions);
        }
    }
}
