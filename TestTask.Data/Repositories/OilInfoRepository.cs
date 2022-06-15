using Dapper;
using System.Data;

namespace TestTask.Data
{
    public class OilInfoRepository : BaseRepository
    {
		private const string _selectOilInfoProcedure = "SELECT pr.RunName, pr.Itemtag, pr.NPD, pp.RunLength, pp.LineWeight, pp.RunDiam, " +
			"pf.PressureRating, pf.FluidCode, pf.Temp FROM PipingRun pr " +
			"JOIN RunToFluid rf on pr.OID = rf.OIDFrom " +
			"JOIN PipingFluid pf on rf.OIDTo = pf.OID" +
			"JOIN RunToPhysical rp on rp.OIDFrom = pr.OID" +
			"JOIN PipingPhysical pp on pp.OID = rp.OIDTo";

		public List<OilInfo> GetOilInfo()
        {
			using IDbConnection connection = ProvideConnection();

			return connection
				.Query<OilInfo>
					(_selectOilInfoProcedure)
				.ToList();
        }
	}
}
