namespace LibraryApi.Models.DTOs
{
    public class LendDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PersonnelName { get; set; }
        public DateTime LendDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public ICollection<string> BookTitles { get; set; } // Ödünç alınan kitaplar
    }
}