using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.BookDtos
{
    public record BookForManipulationDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Book ISBN Required")]
        public string ISBN { get; init; }
        [Required(ErrorMessage = "Book Title Required")]
        public string Title { get; init; }
        [Required(ErrorMessage = "Book Genre Required")]
        public string Genre { get; init; }
        [Required(ErrorMessage = "Book PublishDate Required")]
        public DateOnly PublishDate { get; init; }
        [Required(ErrorMessage = "Book CopiesAvailable Required")]
        public uint CopiesAvailable { get; init; }
        [Required(ErrorMessage = "Book AuthorId Required")]
        public Guid AuthorId { get; init; }
    }
}
