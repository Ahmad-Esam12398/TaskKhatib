using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Repository.Contracts;
using Services.Contract;
using Shared.DataTransferObjects.AuthorDtos;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public AuthorService(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<AuthorDto> CreateAuthorAsync(AuthorForManipulationDto author)
        {
            var authorEntity = _mapper.Map<Author>(author);
            _repositoryManager.Author.CreateAuthor(authorEntity);
            await _repositoryManager.SaveAsync();

            var authorToReturn = _mapper.Map<AuthorDto>(author);
            return authorToReturn;
        }

        public async Task DeleteAuthorAsync(Guid authorId, bool trackChanges)
        {
            var author = await GetAuthorAndCheckIfExistsAsync(authorId, trackChanges);
            _repositoryManager.Author.DeleteAuthor(author, trackChanges);
            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync(bool trackChanges)
        {
            var authors = await _repositoryManager.Author.GetAllAuthorsAsync(trackChanges);
            return _mapper.Map<IEnumerable<AuthorDto>>(authors);
        }

        public async Task<AuthorDto> GetAuthorAsync(Guid authorId, bool trackChanges)
        {
            var author = await _repositoryManager.Author.GetAuthorAsync(authorId, trackChanges);
            return _mapper.Map<AuthorDto>(author);
        }

        public async System.Threading.Tasks.Task UpdateAuthorAsync(Guid bookId, AuthorForManipulationDto author, bool trackChanges)
        {
            var bookEntity = await GetAuthorAndCheckIfExistsAsync(bookId, trackChanges);
            _mapper.Map(author, bookEntity);
            await _repositoryManager.SaveAsync();
        }
        private async Task<Author> GetAuthorAndCheckIfExistsAsync(Guid authorId, bool trackChanges)
        {
            var bookEntity = await _repositoryManager.Author.GetAuthorAsync(authorId, trackChanges);
            if(bookEntity is null)
                throw new AuthorNotFoundException(authorId);
            return bookEntity;
        }
    }
}
