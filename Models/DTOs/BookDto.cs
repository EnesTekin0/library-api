namespace LibraryApi.Models.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public int ISBN { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
        public string PhotoUrl { get; set; }
        public string Summary { get; set; }
        public int PageCount { get; set; }
        public string PublisherName { get; set; } 
        public bool IsDeleted { get; set; } = false; 
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
        public class BookSummaryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PhotoUrl { get; set; }
        public string Summary { get; set; } 
        public string PublisherName { get; set; } 
        public int PageCount { get; set; } 
    }
}