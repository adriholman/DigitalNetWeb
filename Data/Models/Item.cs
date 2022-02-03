namespace DigitalNetWeb.Data.Models{
    public class Item :DBObject
    {
        public string? category { get; set; }
        public string? quantity { get; set; }
        public string? description { get; set; }
    }
}