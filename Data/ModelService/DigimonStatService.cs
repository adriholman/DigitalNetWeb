using System.Data;
using DigitalNetWeb.Data.Models;

namespace DigitalNetWeb.Data.ModelService
{
    public class DigimonStatService
    {
        private List<DigimonStat> ddb = new List<DigimonStat>();
        private DBConnection? dataSQL;
        public DigimonStatService(){}
        public DigimonStat getDigiStat(int digimon)
        {
            if (dataSQL == null)
            {
                dataSQL = new DBConnection();
            }
            DigimonStat ds = new DigimonStat();
            string query = "SELECT * from digimon_stats where digimon_id=" + digimon;
            dataSQL.pullSQL(query);
            DataTable myData = dataSQL.dataTable ?? new DataTable();
            if (myData.Rows.Count == 1)
            {
                DataRow row = myData.Rows[0];
                ds.Code = (int)row.Field<long>("id");
                if (row.IsNull("hp")) { ds.Hp = ""; } else { ds.Hp = ((int)row.Field<long>("hp")).ToString(); };
                if (row.IsNull("ds")) { ds.Ds = ""; } else { ds.Ds = ((int)row.Field<long>("ds")).ToString(); };
                if (row.IsNull("at")) { ds.At = ""; } else { ds.At = ((int)row.Field<long>("at")).ToString(); };
                if (row.IsNull("asp")) { ds.AS = ""; } else { ds.AS = ((double)row.Field<double>("asp")).ToString(); };
                if (row.IsNull("ct")) { ds.Ct = ""; } else { ds.Ct = ((double)row.Field<double>("ct")).ToString(); };
                if (row.IsNull("ht")) { ds.Ht = ""; } else { ds.Ht = ((int)row.Field<long>("ht")).ToString(); };
                if (row.IsNull("de")) { ds.De = ""; } else { ds.De = ((int)row.Field<long>("de")).ToString(); };
                if (row.IsNull("bl")) { ds.Bl = ""; } else { ds.Bl = ((double)row.Field<double>("bl")).ToString(); };
                if (row.IsNull("ev")) { ds.Ev = ""; } else { ds.Ev = ((double)row.Field<double>("ev")).ToString(); };
            }
            else
            {
                return null;
            }
            return ds;
        }
    }
}