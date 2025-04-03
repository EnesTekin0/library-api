namespace LibraryApi.Models.DTOs
{
    public class StockDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}