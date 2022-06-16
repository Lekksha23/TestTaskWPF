﻿using System.Data.SqlClient;
using TestTask.Data;

namespace TestTask.Business
{
    public class OilService : IOilService
    {
        private readonly IOilRepository _oilRepository;

        public OilService(SqlConnection conn)
        {
            _oilRepository = new OilRepository(conn);
        }

        public List<OilModel> GetOilInfo()
        {
            var oilList = _oilRepository.GetOilInfo();
            return CustomMapper.GetInstance().Map<List<OilModel>>(oilList);
        }
    }
}
