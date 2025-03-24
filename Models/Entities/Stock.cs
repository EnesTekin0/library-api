namespace LibraryApi.Models.Entities
{
    public class Stock
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; } // kitap miktarı
        public DateTime LastUpdated { get; set; }
        public bool IsDeleted { get; set; }

        public Book Book { get; set; } 
    }
}
