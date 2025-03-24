namespace LibraryApi.Models.DTOs
{
    public class StockLogDto
    {
        public int Id { get; set; }
        public string PersonnelName { get; set; }
        public string BookTitle { get; set; }
        public DateTime LogDate { get; set; }
        public string Action { get; set; } // Örneğin: "Ekleme" veya "Çıkarma"
    }
}