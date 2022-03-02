using RestAPI_mit_sql.Interfaces;
using RestAPI_mit_sql.Models;
using System.Data;
using System.Data.SqlClient;


namespace RestAPI_mit_sql.Controllers
{
    public class SqlConnector
    {

        public List<TableMusikDB> ReadData()
        {
            
            string connectionString = "Data Source=BIMBO\\SQLEXPRESS;Initial Catalog=MusikDB;Integrated Security=SSPI";
            string queryString = "SELECT PersonID, Nachname FROM dbo.Person;";

            List<TableMusikDB> MusikList = new List<TableMusikDB>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                
                // Call Read before accessing data.
                while (reader.Read())
                {
                   
                    MusikList.Add(new TableMusikDB() { Nachname = reader.GetFieldValue<string>(1), PersonID = reader.GetFieldValue<int>(0) });
                    
                }

                // Call Close when done reading.
                reader.Close();
            }

            return MusikList;
        }

        internal void ReadSingleRow()
        {
            throw new NotImplementedException();
        }

        internal void Read()
        {
            throw new NotImplementedException();
        }

        
    }
}