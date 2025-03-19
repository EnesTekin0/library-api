namespace LibraryApi.Models.Entities
{
    public class StockLog
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public int PersonnelId { get; set; } // İşlemi yapan personelin ID'si
        public string Action { get; set; } 
        public int ChangeAmount { get; set; }
        public DateTime Date { get; set; }

        public Stock Stock { get; set; } 
        public Personnel Personnel { get; set; }
    }
}
