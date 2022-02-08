using System.Data;
using System.Data.SQLite;
namespace DigitalNetWeb.Data
{
    public class DBConnection
    {
        public DataTable? dataTable = new DataTable();
        string source = "/wwwroot/data.db;Version=3;";

        public DBConnection()
        {
        }
        public void pullSQL(string query)
        {
            try
            {
                dataTable.Reset();
                SQLiteConnection con = new SQLiteConnection("Data Source=" + source);
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dataTable);
                con.Close();
                da.Dispose();

                DataColumn[] keyColumns = new DataColumn[1];
                keyColumns[0] = dataTable.Columns["id"];
                dataTable.PrimaryKey = keyColumns;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}