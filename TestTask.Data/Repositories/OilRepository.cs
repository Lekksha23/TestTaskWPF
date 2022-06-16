using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace TestTask.Data
{
    public class OilRepository : IOilRepository
    {
        private SqlConnection _connection;
        private const string _selectOilInfoProcedure = "SELECT pr.RunName, pr.Itemtag, pr.NPD, pp.RunLength, pp.LineWeight, pp.RunDiam, " +
            "pf.PressureRating, pf.FluidCode, pf.Temp FROM PipingRun pr " +
            "JOIN RunToFluid rf on pr.OID = rf.OIDFrom " +
            "JOIN PipingFluid pf on rf.OIDTo = pf.OID " +
            "JOIN RunToPhysical rp on rp.OIDFrom = pr.OID " +
            "JOIN PipingPhysical pp on pp.OID = rp.OIDTo";

        public OilRepository(SqlConnection sqlConnection)
        {
            _connection = sqlConnection;
        }

        public List<Oil> GetOilInfo()
        {
            using IDbConnection connection = _connection;

            return connection.Query<Oil>(_selectOilInfoProcedure)
                .ToList();
        }
    }
}
