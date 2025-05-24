using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Repository.Contracts;
using Services.Contract;
using Shared.DataTransferObjects.BookDtos;

namespace Services
{
    public class BookService : IBookService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public BookService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<BookDto> CreateBookAsync(BookForManipulationDto book)
        {
            var bookEntity = _mapper.Map<Book>(book);
            _repositoryManager.Book.CreateBook(bookEntity);
            await _repositoryManager.SaveAsync();
            return _mapper.Map<BookDto>(bookEntity);
        }

        public async Task DeleteBookAsync(Guid bookId, bool trackChanges)
        {
            var book = await GetBookAndCheckIfExistsAsync(bookId, trackChanges);
            _repositoryManager.Book.DeleteBook(book, trackChanges);
            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync(bool trackChanges)
        {
            var books = await _repositoryManager.Book.GetAllBooksAsync(trackChanges);
            var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);
            return booksDto;
        }

        public async Task<BookDto> GetBookAsync(Guid bookId, bool trackChanges)
        {
            var book = await GetBookAndCheckIfExistsAsync(bookId, trackChanges);
            return _mapper.Map<BookDto>(book);
        }

        public async Task UpdateBookAsync(Guid bookId, BookForManipulationDto book, bool trackChanges)
        {
            var bookEntity = await GetBookAndCheckIfExistsAsync(bookId, trackChanges);
            _mapper.Map(book, bookEntity);
            await _repositoryManager.SaveAsync();
        }
        private async Task<Book> GetBookAndCheckIfExistsAsync(Guid bookId, bool trackChanges)
        {
            var bookEntity = await _repositoryManager.Book.GetBookAsync(bookId, trackChanges);
            if (bookEntity is null)
                throw new BookNotFoundException(bookId);
            return bookEntity;
        }
        public async Task BorrowBookAsync(Guid bookId, bool trackChanges)
        {
            var book = await GetBookAndCheckIfExistsAsync(bookId, trackChanges);
            if (book.CopiesAvailable == 0)
                throw new Exception($"No Books of Id {bookId} is Available");
            await _repositoryManager.Transaction.CreateTransaction(new Transaction
            {
                BookId = bookId,
                BorrowedAt = DateTime.UtcNow
            });
            book.CopiesAvailable--;
            book.CopiesBorrowed++;
            await _repositoryManager.SaveAsync();
        }
        public async Task ReturnBookAsync(Guid bookId, bool trackChanges)
        {
            var book = await GetBookAndCheckIfExistsAsync(bookId, trackChanges);
            if (book.CopiesBorrowed == 0)
                throw new Exception($"No Books of Id {bookId} is Borrowed");
            var transaction = await _repositoryManager.Transaction.GetOpenTransactionForBookAsync(bookId, trackChanges);
            transaction.ReturnedAt = DateTime.UtcNow;
            book.CopiesAvailable++;
            book.CopiesBorrowed--;
            await _repositoryManager.SaveAsync();
        }
    }
}
