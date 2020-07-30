using System.Data;
using System.Data.SqlClient;

namespace PortfolioBackendCSharp.DAL
{
    public class Connection
    {
        private readonly SqlConnection connection = new SqlConnection(@"data source =HEN-DESKTOP\SQLEXPRESS; Integrated Security=true; Initial Catalog=SitePortfolio;");

        public void Dispose()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        public Connection()  //CONSTRUCTOR
        {
            connection.Open();
        }

        public string CheckString(SqlDataReader reader, int columnIndex)
        {
            if (!reader.IsDBNull(columnIndex))
                return reader.GetString(columnIndex);
            return string.Empty;
        }

        public void ExecuteWithoutReturn(string strQuery)
        {
            var cmdComand = new SqlCommand
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = connection
            };

            cmdComand.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteWithReturn(string strQuery)
        {
            var cmdComandSelect = new SqlCommand(strQuery, connection);
            return cmdComandSelect.ExecuteReader();
        }
    }
}
