using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.AuthorDtos
{
    public record AuthorForManipulationDto // (Guid Id, string Name, string Bio, DateOnly DateOfBirth);
    {
        [Required(ErrorMessage = "Author Id is Required")]
        public Guid Id { get; init; }
        [Required(ErrorMessage = "Author Name is Required")]
        public string Name { get; init; }
        public string Bio { get; init; }
        [Required(ErrorMessage = "Author DateOfBirth is Required")]
        public DateOnly DateOfBirth { get; init; }
    }

}
