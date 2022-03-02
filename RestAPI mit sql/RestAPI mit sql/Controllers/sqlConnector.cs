using System.Data;
using System.Data.SqlClient;


namespace RestAPI_mit_sql.Controllers
{ 
public class SqlConnector
    {
        public void ReadCarData()
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
                    ReadSingleRow((IDataRecord)reader);
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

        private static void ReadSingleRow(IDataRecord dataRecord)
        {
            Console.WriteLine(String.Format("{0}, {1}", dataRecord[0], dataRecord[1]));
        }
    }
}