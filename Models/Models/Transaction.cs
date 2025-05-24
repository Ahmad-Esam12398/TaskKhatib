namespace Entities.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public DateTime BorrowedAt { get; set; }
        public DateTime? ReturnedAt { get; set; }
        public Book Book { get; set;}
    }
}
