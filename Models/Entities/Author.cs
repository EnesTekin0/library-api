namespace LibraryApi.Models.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; } 
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public List<Book> Books { get; set; } 
    }
}
