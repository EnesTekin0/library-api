namespace LibraryApi.Models.DTOs
{
    public class StockLogDto
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public int PersonnelId { get; set; }
        public int ChangeAmount { get; set; }   
        public DateTime Date { get; set; }
        public string Action { get; set; } // Örneğin: "Ekleme" veya "Çıkarma"
    }
}