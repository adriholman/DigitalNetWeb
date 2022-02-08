using System.Data;
using DigitalNetWeb.Data.Models;

namespace DigitalNetWeb.Data.ModelService
{
    public class ItemService
    {
        private List<Item> ddb = new List<Item>();
        private DBConnection? dataSQL;
        public ItemService() { }

        public List<Item> SearchForItems(string text)
        {
            if (dataSQL == null)
            {
                dataSQL = new DBConnection();
            }
            ddb.Clear();
            List<Item> s = new List<Item>();
            string query = "select * from items_view where (name like '%" + text + "%' or korean_name like '%" + text + "%' or description like '%" + text + "%')";
            dataSQL.pullSQL(query);
            DataTable myData = dataSQL.dataTable ?? new DataTable();
            foreach (DataRow row in myData.Rows)
            {
                Item i = new Item();
                i.Code = (int)row.Field<long>("id");
                if (row.IsNull("korean_name")) { i.KorName = ""; } else { i.KorName = (string)row.Field<string>("korean_name"); }
                if (row.IsNull("name")) { i.EngName = ""; } else { i.EngName = (string)row.Field<Object>("name"); }
                if (row.IsNull("icon_link")) { i.IconLink = "https://i.imgur.com/dEBKEO7.png"; } else { i.IconLink = (String?)row.Field<Object>("icon_link"); }
                if (row.IsNull("category")) { i.category = ""; } else { i.category = (string)row.Field<Object>("category"); }
                if (row.IsNull("description")) { i.description = ""; } else { i.description = (string)row.Field<Object>("description"); }
                s.Add(i);
            }
            //s.Sort((x, y) => x.EngName.CompareTo(y.EngName));
            return s;
        }
    }
}