namespace Shared.DataTransferObjects.BookDtos
{
    public record BookDto(Guid Id, string ISBN, string Title, string Genre, DateOnly PublishDate, uint CopiesAvailable, string AuthorName);
}
