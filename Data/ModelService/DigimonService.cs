using System.Data;
using DigitalNetWeb.Data.Models;

namespace DigitalNetWeb.Data.ModelService
{
    public class DigimonService
    {
        private List<Digimon> ddb = new List<Digimon>();
        private DBConnection? dataSQL;
        public DigimonService() { }
        public List<Digimon> SearchDigimon(string text)
        {
            if (dataSQL == null)
            {
                dataSQL = new DBConnection();
            }
            ddb.Clear();
            string query = "SELECT * FROM digimon_view where (dub_name like '%" + text + "%' or korean_name like '%" + text + "%' or other_names like '%" + text + "%' or " +
                           "attacker_type like '%" + text + "%' or digimon_attribute like '%" + text + "%' or element like '%" + text + "%' or " + 
                           "stage like '%" + text + "%' or digimon_rank like '%" + text + "%')";
            dataSQL.pullSQL(query);
            DataTable myData = dataSQL.dataTable ?? new DataTable();
            foreach (DataRow row in myData.Rows)
            {
                Digimon d = new Digimon();
                d.Code = (int)row.Field<long>("id");
                if (row.IsNull("korean_name")) { d.KorName = ""; } else { d.KorName = (String?)row.Field<string>("korean_name"); }
                if (row.IsNull("dub_name")) { d.EngName = ""; } else { d.EngName = (String?)row.Field<Object>("dub_name"); }
                if (row.IsNull("icon_name")) { d.IconLink = "/images/DigimonIcons/Unknown.png"; } else { d.IconLink = "/images/DigimonIcons/" + (String?)row.Field<Object>("icon_name") + ".png";}
                if (row.IsNull("model_name")) { d.ModelLink = "/images/Missing.png"; } else { d.ModelLink = "/images/DigimonModels/" + (String?)row.Field<Object>("model_name") + ".png"; }
                if (row.IsNull("evolution_tree")) { d.DigimonLine = ""; } else { d.DigimonLine = (String?)row.Field<Object>("evolution_tree"); }
                if (row.IsNull("stage")) { d.Stage = ""; } else { d.Stage = "/images/Stages/" + (String?)row.Field<Object>("stage") + ".png"; }
                if (row.IsNull("rank_icon") || ((String?)row.Field<Object>("digimon_rank")).Equals("None")) { d.RankIcon = ""; } else { d.RankIcon = "/images/Ranks/" + (String?)row.Field<Object>("digimon_rank") + ".png"; }
                if (row.IsNull("attribute_icon")) { d.AttributeIcon = ""; } else { d.AttributeIcon = "/images/Attributes/" + (String?)row.Field<Object>("attribute_icon") + ".png"; }
                if (row.IsNull("element_icon")) { d.ElementIcon = ""; } else { d.ElementIcon = "/images/Elements/" + (String?)row.Field<Object>("element_icon") + ".png"; }
                if (row.IsNull("attacker_icon")) { d.AttackerIcon = ""; } else { d.AttackerIcon = "/images/Attackers/" + (String?)row.Field<Object>("attacker_icon") + ".png"; }
                if (row.IsNull("first_family")) { d.Family1 = ""; } else {d.Family1 = "/images/Families/" + (String?)row.Field<Object>("first_f_icon") + ".png";}
                if (row.IsNull("second_family")) { d.Family2 = ""; } else {d.Family2 = "/images/Families/" + (String?)row.Field<Object>("second_f_icon") + ".png";}
                if (row.IsNull("third_family")) { d.Family3 = ""; } else {d.Family3 = "/images/Families/" + (String?)row.Field<Object>("third_f_icon") + ".png";}
                if (row.IsNull("fourth_family")) { d.Family4 = ""; } else {d.Family4 = "/images/Families/" + (String?)row.Field<Object>("fourth_f_icon") + ".png";}
                d.LvRequired = (String?)row.Field<Object>("level");
                d.DigimonStat = new DigimonStatService().getDigiStat(d.Code);
                d.DigimonSkills = new DigimonSkillService().searchDigimonSkills(d.Code);
                ddb.Add(d);
            }
            //ddb.Sort((x, y) => (x.EngName ?? "").CompareTo(y.EngName));
            return ddb;
        }
    }
}