using System.Data;
using DigitalNetWeb.Data.Models;

namespace DigitalNetWeb.Data.ModelService
{
    public class ItemService
    {
        private List<Digimon> ddb = new List<Digimon>();
        private DBConnection? dataSQL;
        public ItemService() { }
        public Task<Digimon[]> GetDigimonDBAsync()
        {
            if (dataSQL == null)
            {
                dataSQL = new DBConnection();
            }
            ddb.Clear();
            string query = "SELECT * from digimon_view";
            dataSQL.pullSQL(query);
            DataTable myData = dataSQL.dataTable;
            foreach (DataRow row in myData.Rows)
            {
                Digimon d = new Digimon();
                d.Code = (int)row.Field<long>("id");
                if (row.IsNull("korean_name")) { d.KorName = ""; } else { d.KorName = (String?)row.Field<string>("korean_name"); }
                if (row.IsNull("dub_name")) { d.EngName = ""; } else { d.EngName = (String?)row.Field<Object>("dub_name"); }
                if (row.IsNull("icon_link")) { d.IconLink = "https://i.imgur.com/dEBKEO7.png"; } else { d.IconLink = (String?)row.Field<Object>("icon_link"); }
                if (row.IsNull("model_link")) { d.ModelLink = ""; } else { d.ModelLink = (String?)row.Field<Object>("model_link"); }
                if (row.IsNull("evolution_tree")) { d.DigimonLine = ""; } else { d.DigimonLine = (String?)row.Field<Object>("evolution_tree"); }
                if (row.IsNull("stage")) { d.Stage = ""; } else { d.Stage = (String?)row.Field<Object>("stage"); }
                if (row.IsNull("digimon_rank")) { d.Rank = ""; } else { d.Rank = (String?)row.Field<Object>("digimon_rank"); }
                if (row.IsNull("digimon_attribute")) { d.Attribute = ""; } else { d.Attribute = (String?)row.Field<Object>("digimon_attribute"); }
                if (row.IsNull("element")) { d.ElementalAttribute = ""; } else { d.ElementalAttribute = (String?)row.Field<Object>("element"); }
                if (row.IsNull("attacker_type")) { d.AttackerType = ""; } else { d.AttackerType = (String?)row.Field<Object>("attacker_type"); }
                d.Family1 = (String?)row.Field<Object>("first_family");
                d.Family2 = (String?)row.Field<Object>("second_family");
                d.Family3 = (String?)row.Field<Object>("third_family");
                d.Family4 = (String?)row.Field<Object>("fourth_family");
                d.LvRequired = (String?)row.Field<Object>("level");
                ddb.Add(d);
            }
            ddb.Sort((x, y) => x.EngName.CompareTo(y.EngName));
            return Task.FromResult(ddb.ToArray());
        }
    }
}