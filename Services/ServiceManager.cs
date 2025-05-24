using AutoMapper;
using Repository.Contracts;
using Services.Contract;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthorService> _authorService;
        private readonly Lazy<IBookService> _bookService;
        private readonly Lazy<IGenreService> _genreService;
        private readonly Lazy<ITransactionService> _transactionService;
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _authorService = new Lazy<IAuthorService>(() => new AuthorService(mapper, repositoryManager));
            _bookService = new Lazy<IBookService>(() => new BookService(repositoryManager, mapper));
            _genreService = new Lazy<IGenreService>(() => new GenreService(repositoryManager, mapper));
            _transactionService = new Lazy<ITransactionService>(() => new TransactionService(repositoryManager, mapper));
        }
        public IAuthorService AuthorService => _authorService.Value;
        public IBookService BookService => _bookService.Value;
        public IGenreService GenreService => _genreService.Value;
        public ITransactionService TransactionService => _transactionService.Value;
    }
}
