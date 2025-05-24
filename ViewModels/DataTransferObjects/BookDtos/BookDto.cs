namespace Shared.DataTransferObjects.BookDtos
{
    public record BookDto(Guid Id, string ISBN, string Title, string GenreTitle, DateOnly PublishDate, uint CopiesAvailable, uint CopiesBorrowed, string AuthorName);
}
