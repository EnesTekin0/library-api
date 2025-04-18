namespace LibraryApi.Models.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public string Nationality { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? BirthDate { get; set; } 
        public DateTime? DeathDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public ICollection<Book> Books { get; set; } 
    }
}
