namespace LibraryApi.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; } 
        public int ISBN { get; set; }
        public string Title { get; set; } 
        public string PhotoUrl { get; set; }
        public string Summary { get; set; }
        public int PageCount { get; set; }
        public string PublisherName { get; set; } 
        public bool IsDeleted { get; set; } = false; 
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public Author Author { get; set; } 
        public Category Category { get; set; } 
    }
}
