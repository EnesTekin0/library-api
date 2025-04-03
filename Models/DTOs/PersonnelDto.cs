namespace LibraryApi.Models.DTOs
{
    public class PersonnelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } 
        public string Role { get; set; } // Personel pozisyonu
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}