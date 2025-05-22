using AutoMapper;
using Repository.Contracts;
using Services.Contract;
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
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _authorService = new Lazy<IAuthorService>(() => new AuthorService(mapper, repositoryManager));
            _bookService = new Lazy<IBookService>(() => new BookService(repositoryManager, mapper));
        }
        public IAuthorService AuthorService => _authorService.Value;

        public IBookService BookService => _bookService.Value;
    }
}
