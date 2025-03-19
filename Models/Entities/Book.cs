namespace LibraryApi.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; } // Kitap seri no
        public int AuthorId { get; set; }
        public int CategoryId { get; set; } 
        public string PublisherName { get; set; } 
        public int PageCount { get; set; } 
        public bool IsDeleted { get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public Author Author { get; set; } 
        public Category Category { get; set; } 
    }
}
