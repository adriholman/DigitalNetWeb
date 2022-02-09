using System.Data;
using DigitalNetWeb.Data.Models;

namespace DigitalNetWeb.Data.ModelService
{
    public class SealService
    {
        private DBConnection? dataSQL;
        public SealService() { }

        public List<Seal> searchForDigimonSeal(string text)
        {
            if (dataSQL == null)
            {
                dataSQL = new DBConnection();
            }
            List<Seal> search = new List<Seal>();
            string query = "SELECT * FROM seal_view where (dub_name like '%" + text + "%' or korean_name like '%" + text + "%' or other_names like '%" + text + "%') and stat not null ORDER BY dub_name";
            dataSQL.pullSQL(query);
            DataTable myData = dataSQL.dataTable ?? new DataTable();
            foreach (DataRow row in myData.Rows)
            {
                Seal ds = new Seal();
                ds.Code = (int)row.Field<long>("id");
                ds.KorName = (String?)row.Field<Object>("korean_name");
                ds.EngName = (String?)row.Field<Object>("dub_name");
                ds.IconLink = "https://i.imgur.com/VLsrqak.png";
                ds.sealBonus = (String?)row.Field<Object>("seal_bonus");
                ds.stage = (String?)row.Field<Object>("stage");
                ds.stat = (String?)row.Field<Object>("stat");
                ds.b1 = (String?)row.Field<Object>("b1");
                ds.b50 = (String?)row.Field<Object>("b50");
                ds.b200 = (String?)row.Field<Object>("b200");
                ds.b500 = (String?)row.Field<Object>("b500");
                ds.b1000 = (String?)row.Field<Object>("b1000");
                ds.b3000 = (String?)row.Field<Object>("b3000");
                search.Add(ds);
            }
            return search;
        }
    }
}