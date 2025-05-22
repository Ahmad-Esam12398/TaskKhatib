namespace Shared.DataTransferObjects.AuthorDtos
{
    public record AuthorDto(Guid Id, string Name, string Bio, DateOnly DateOfBirth);

}
