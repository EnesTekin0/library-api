namespace LibraryApi.Models.Entities
{
    public class Lend
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PersonnelId { get; set; }
        public DateTime LendDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; } // Kitap iade edildi mi?
        public bool IsDeleted { get; set; } = false; 
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }       
        
         public Customer Customer { get; set; } 
        public Personnel Personnel { get; set; }
        public ICollection<LendDetail> LendDetails { get; set; } 
    }
}
