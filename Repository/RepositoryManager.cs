using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IBookRepository> _bookRepository;
        private readonly Lazy<IAuthorRepository> _authorRepository;
        private readonly Lazy<IGenreRepository> _genreRepository;
        private readonly Lazy<ITransactionRepository> _transactionRepository;
        public RepositoryManager(RepositoryContext repository)
        {
            _repositoryContext = repository;
            _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(_repositoryContext));
            _authorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(_repositoryContext));
            _genreRepository = new Lazy<IGenreRepository>(() => new GenreRepository(_repositoryContext));
            _transactionRepository = new Lazy<ITransactionRepository>(() => new TransactionRepository(_repositoryContext));
        }
        public IBookRepository Book => _bookRepository.Value;

        public IAuthorRepository Author => _authorRepository.Value;
        public IGenreRepository Genre => _genreRepository.Value;
        public ITransactionRepository Transaction => _transactionRepository.Value;

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
