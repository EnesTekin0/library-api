namespace LibraryApi.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; } 
        public bool IsDeleted { get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public Category ParentCategory { get; set; } 
        public List<Category> SubCategories { get; set; } 
        public List<Book> Books { get; set; } 
    }
}
