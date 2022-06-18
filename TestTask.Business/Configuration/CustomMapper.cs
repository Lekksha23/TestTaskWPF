using AutoMapper;
using TestTask.Data;

namespace TestTask.Business
{
    public static class CustomMapper
    {
        private static Mapper _instance;

        public static Mapper GetInstance()
        {
            if (_instance == null)
                InitCustomMapper();
            return _instance;
        }

        public static Mapper Custom { get; set; }

        private static void InitCustomMapper()
        {
            _instance = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OilModel, Oil>();
                cfg.CreateMap<Oil, OilModel>();
            }));
        }
    }
}
