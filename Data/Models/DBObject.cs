namespace DigitalNetWeb.Data.Models
{
    public class DBObject
    {
        public int Code { get; set; }
        public String? KorName { get; set; }
        public String? EngName { get; set; }
        public String? IconName { get; set; }
        public String? IconLink { get; set; } = "https://i.imgur.com/TBPb1LI.png";
        public String? ModelLink { get; set; } = "https://i.imgur.com/UXnsB8E.png";
        public String? Description { get; set; }
        public String? ToTypeID(){
            return this.GetType().ToString().Split(".").Last<String>() + Code.ToString();
        }
    }
}