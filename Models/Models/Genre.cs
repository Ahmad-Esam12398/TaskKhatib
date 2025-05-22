namespace Entities.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
