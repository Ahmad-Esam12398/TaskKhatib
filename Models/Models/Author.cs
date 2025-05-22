namespace Entities.Models
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public IEnumerable<Book> Books { get; set; } = new List<Book>();
    }
}
