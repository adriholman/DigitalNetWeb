namespace DigitalNetWeb.Data.Models
{
    public class DRequired : DBObject
    {
        public DRequired(){}
        public String? Required { set; get; }

        public Digimon RequiredD { set; get; }
    }
}