using Services.Contracts;

namespace Services.Contract
{
    public interface IServiceManager
    {
        IAuthorService AuthorService { get; }
        IBookService BookService { get; }
        IGenreService GenreService { get; }
        ITransactionService TransactionService { get; }
    }
}
