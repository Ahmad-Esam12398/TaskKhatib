namespace Repository.Contracts
{
    public interface IRepositoryManager
    {
        IBookRepository Book { get; }
        IAuthorRepository Author { get; }
        IGenreRepository Genre { get; }
        ITransactionRepository Transaction { get; }
        Task SaveAsync();
    }
}
