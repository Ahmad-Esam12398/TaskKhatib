namespace Shared.DataTransferObjects.TransactionDtos
{
    public record TransactionDto
    {
        public Guid Id { get; init; }
        public string bookTitle { get; init; }
        public DateTime? borrowDate { get; init; }
        public DateTime? returnDate { get; init; }
    }
}
