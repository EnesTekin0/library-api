namespace LibraryApi.Models.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        public ICollection<int> LendIds { get; set; } // Müşterinin ödünç aldığı kitapların ID'leri
    }
}   