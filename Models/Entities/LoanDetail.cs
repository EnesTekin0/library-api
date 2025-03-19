namespace LibraryApi.Models.Entities
{
    public class LoanDetail
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public int BookId { get; set; }
        public DateTime ReturnDate { get; set; } 
        public bool IsLost { get; set; } 
        public bool IsDeleted { get; set; } 

        public Loan Loan { get; set; } 
        public Book Book { get; set; } 
    }
}
