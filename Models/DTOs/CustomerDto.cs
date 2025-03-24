namespace LibraryApi.Models.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public ICollection<int> LendIds { get; set; } // Müşterinin ödünç aldığı kitapların ID'leri
    }
}   