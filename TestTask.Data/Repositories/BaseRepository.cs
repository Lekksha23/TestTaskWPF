using System.Data;
using System.Data.SqlClient;

namespace TestTask.Data
{
    public class BaseRepository
    {
        private const string _сonnString = "Server=sql5105.site4now.net;User ID=db_a88368_lekksha001_admin;Password=******;Database=CoCowork.DB;";

        protected IDbConnection ProvideConnection() => new SqlConnection(_сonnString);
    }
}
