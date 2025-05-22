namespace Entities.Exceptions
{
    public class AuthorNotFoundException : NotFoundException
    {
        public AuthorNotFoundException(Guid authorId)
            : base($"Author with id: {authorId} doesn't exist in the database.")
        {
        }
    }
}
