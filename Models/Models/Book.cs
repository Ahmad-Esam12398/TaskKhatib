using Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        [ForeignKey(nameof(Genre))]
        public Guid GenreId { get; set; }
        public DateOnly PublishDate { get; set; }
        public uint CopiesAvailable { get; set; }
        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }
    }
}
