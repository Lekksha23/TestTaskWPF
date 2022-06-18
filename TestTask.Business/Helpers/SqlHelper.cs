using System.Data.SqlClient;

namespace TestTask.Business
{
    public class SqlHelper
    {
        private SqlConnection _conn;

        public bool IsConnectionSucceeded
        {
            get
            {
                if (_conn.State is System.Data.ConnectionState.Closed) 
                    _conn.Open();

                return true;
            }
        }

        public SqlHelper(SqlConnection connectionString)
        {
            _conn = connectionString;
        }
    }
}
