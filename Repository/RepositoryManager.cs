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
        public RepositoryManager(RepositoryContext repository)
        {
            _repositoryContext = repository;
            _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(_repositoryContext));
            _authorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(_repositoryContext));
        }
        public IBookRepository Book => _bookRepository.Value;

        public IAuthorRepository Author => _authorRepository.Value;

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
