using System.Data;
using System.Data.SqlClient;

namespace TestTask.Data
{
    public class BaseRepository
    {
        private string _сonnString;

        public BaseRepository(string connString)
        {
            _сonnString = connString;
        }

        protected IDbConnection ProvideConnection() => new SqlConnection(_сonnString);
    }
}
