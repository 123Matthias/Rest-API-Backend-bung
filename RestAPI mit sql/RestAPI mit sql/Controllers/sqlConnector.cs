using RestAPI_mit_sql.Models;
using System.Data;
using System.Data.SqlClient;


namespace RestAPI_mit_sql.Controllers
{
    public class SqlConnector
    {

       
            
        public List<TableMusikDB> ReadData(object dataRecord)
        {
            
            string connectionString = "Data Source=BIMBO\\SQLEXPRESS;Initial Catalog=MusikDB;Integrated Security=SSPI";
            string queryString = "SELECT PersonID, Nachname FROM dbo.Person;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    List<TableMusikDB> t = new List<TableMusikDB>();
                    t.Add(new TableMusikDB() { Nachname = (string)dataRecord[1], PersonID = (int)dataRecord[0] });
                    return;
                }

                // Call Close when done reading.
                reader.Close();
            }
        }

        internal void ReadSingleRow()
        {
            throw new NotImplementedException();
        }

        internal void Read()
        {
            throw new NotImplementedException();
        }

        private static async Task ReadSingleRow(IDataRecord dataRecord)
        {
            Console.WriteLine(String.Format("{0}, {1}", dataRecord[0], dataRecord[1]));


        }

        
    }
}