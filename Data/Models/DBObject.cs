namespace DigitalNetWeb.Data.Models
{
    public class DBObject
    {
        public int Code { get; set; }
        public String? KorName { get; set; }
        public String? EngName { get; set; }
        public String? IconLink { get; set; }
        public String? ModelLink { get; set; }
        public String? Description { get; set; }
        public String? ToTypeID(){
            return this.GetType().ToString().Split(".").Last<String>() + Code.ToString();
        }
    }
}