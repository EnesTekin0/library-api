namespace LibraryApi.Models.DTOs
{
    public class LendDetailDto
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public DateTime LendDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}