namespace LibraryApi.Models.DTOs
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<string> BookTitles { get; set; } // Yazarın kitaplarının adları
    }
}