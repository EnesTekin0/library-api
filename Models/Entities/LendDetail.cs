namespace LibraryApi.Models.Entities
{
    public class LendDetail
    {
        public int Id { get; set; }
        public int LendId { get; set; }
        public int BookId { get; set; }
        public DateTime ReturnDate { get; set; } 
        public bool IsLost { get; set; } // Kitap kayboldu mu?
        public bool IsDeleted { get; set; } = false; 
        

        public Lend Lend { get; set; } 
        public Book Book { get; set; } 
    }
}
