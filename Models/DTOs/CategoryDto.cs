namespace LibraryApi.Models.DTOs
{
public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsDeleted { get; set; } = false;
    public ICollection<int> BookId { get; set; }
}
}