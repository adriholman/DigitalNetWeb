namespace DigitalNetWeb.Data.Models
{
    public class Item : DBObject
    {
        public Item(){}
        public string? category { get; set; }
        public string? quantity { get; set; }
    }
}