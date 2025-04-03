namespace LibraryApi.Models.DTOs
{
    public class LendDetailDto
    {
        public int Id { get; set; }
        public int LendId { get; set; }
        public int BookId { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsLost { get; set; } // Kitap kayboldu mu?
        public bool IsDeleted { get; set; } = false;   
    }
}