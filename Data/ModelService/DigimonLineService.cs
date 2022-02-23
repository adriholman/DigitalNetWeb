using System.Data;
using DigitalNetWeb.Data.Models;

namespace DigitalNetWeb.Data.ModelService
{
    public class DigimonLineService
    {
        private List<Digimon> ddb = new List<Digimon>();
        private DBConnection? dataSQL;
        public DigimonLineService() { }

        public DigimonLine getDigimonLine(string digimon, string digimonRequired)
        {
            if (dataSQL == null)
            {
                dataSQL = new DBConnection();
            }
            ddb.Clear();
            string query = "";
            //string query = Properties.Resources.evoTreeSearch.Replace("param1", digimonRequired).Replace("param2", digimon);
            dataSQL.pullSQL(query);
            DataTable myData = dataSQL.dataTable ?? new DataTable();
            if (myData.Rows.Count == 1)
            {
                DataRow row = myData.Rows[0];
                DigimonLine d = new DigimonLine();
                d.Code = (int)row.Field<long>("id");
                d.KorName = (String)row.Field<Object>("korean_name");
                d.EngName = (String)row.Field<Object>("dub_name");
                d.IconName = (String)row.Field<Object>("icon_name");
                d.SystemType = (String)row.Field<Object>("system");
                if (row.IsNull("type")) { d.EggType = ""; } else { d.EggType = (String)row.Field<Object>("type"); }
                if (row.IsNull("data_quantity")) { d.AmountOfData = ""; } else { d.AmountOfData = ((int)row.Field<long>("data_quantity")).ToString(); }
                if (row.IsNull("C1_F1")) { d.C1_F1 = ""; } else { d.C1_F1 = (String)row.Field<Object>("C1_F1"); }
                if (row.IsNull("C1_F2")) { d.C1_F2 = ""; } else { d.C1_F2 = (String)row.Field<Object>("C1_F2"); }
                if (row.IsNull("C1_F3")) { d.C1_F3 = ""; } else { d.C1_F3 = (String)row.Field<Object>("C1_F3"); }
                if (row.IsNull("C1_F4")) { d.C1_F4 = ""; } else { d.C1_F4 = (String)row.Field<Object>("C1_F4"); }
                if (row.IsNull("C1_F5")) { d.C1_F5 = ""; } else { d.C1_F5 = (String)row.Field<Object>("C1_F5"); }
                if (row.IsNull("C1_F6")) { d.C1_F6 = ""; } else { d.C1_F6 = (String)row.Field<Object>("C1_F6"); }
                if (row.IsNull("C2_F1")) { d.C2_F1 = ""; } else { d.C2_F1 = (String)row.Field<Object>("C2_F1"); }
                if (row.IsNull("C2_F2")) { d.C2_F2 = ""; } else { d.C2_F2 = (String)row.Field<Object>("C2_F2"); }
                if (row.IsNull("C2_F3")) { d.C2_F3 = ""; } else { d.C2_F3 = (String)row.Field<Object>("C2_F3"); }
                if (row.IsNull("C2_F4")) { d.C2_F4 = ""; } else { d.C2_F4 = (String)row.Field<Object>("C2_F4"); }
                if (row.IsNull("C2_F5")) { d.C2_F5 = ""; } else { d.C2_F5 = (String)row.Field<Object>("C2_F5"); }
                if (row.IsNull("C2_F6")) { d.C2_F6 = ""; } else { d.C2_F6 = (String)row.Field<Object>("C2_F6"); }
                if (row.IsNull("C3_F1")) { d.C3_F1 = ""; } else { d.C3_F1 = (String)row.Field<Object>("C3_F1"); }
                if (row.IsNull("C3_F2")) { d.C3_F2 = ""; } else { d.C3_F2 = (String)row.Field<Object>("C3_F2"); }
                if (row.IsNull("C3_F3")) { d.C3_F3 = ""; } else { d.C3_F3 = (String)row.Field<Object>("C3_F3"); }
                if (row.IsNull("C3_F4")) { d.C3_F4 = ""; } else { d.C3_F4 = (String)row.Field<Object>("C3_F4"); }
                if (row.IsNull("C3_F5")) { d.C3_F5 = ""; } else { d.C3_F5 = (String)row.Field<Object>("C3_F5"); }
                if (row.IsNull("C3_F6")) { d.C3_F6 = ""; } else { d.C3_F6 = (String)row.Field<Object>("C3_F6"); }
                if (row.IsNull("C4_F1")) { d.C4_F1 = ""; } else { d.C4_F1 = (String)row.Field<Object>("C4_F1"); }
                if (row.IsNull("C4_F2")) { d.C4_F2 = ""; } else { d.C4_F2 = (String)row.Field<Object>("C4_F2"); }
                if (row.IsNull("C4_F3")) { d.C4_F3 = ""; } else { d.C4_F3 = (String)row.Field<Object>("C4_F3"); }
                if (row.IsNull("C4_F4")) { d.C4_F4 = ""; } else { d.C4_F4 = (String)row.Field<Object>("C4_F4"); }
                if (row.IsNull("C4_F5")) { d.C4_F5 = ""; } else { d.C4_F5 = (String)row.Field<Object>("C4_F5"); }
                if (row.IsNull("C4_F6")) { d.C4_F6 = ""; } else { d.C4_F6 = (String)row.Field<Object>("C4_F6"); }
                return d;
            }
            else
            {
                return null;
            }
        }
    }
}