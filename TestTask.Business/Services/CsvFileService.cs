using TestTask.Data.Interfaces;
using TestTask.Data.Repositories;

namespace TestTask.Business.Services
{
    public class CsvFileService
    {
        private readonly ICsvFileRepository _csvFileRepository;

        public CsvFileService()
        {
            _csvFileRepository = new CsvFileRepository();
        }

        public void WriteToCsvFile(List<OilModel> oilList, string filePath)
        {
            var headerLine = string.Join(",", oilList[0]
                            .GetType()
                            .GetProperties()
                            .Select(x => x.Name));

            var dataLines = from oil in oilList
                            let dataLine = string.Join(",", oil
                            .GetType()
                            .GetProperties()
                            .Select(x => x.GetValue(oil)))
                            select dataLine;

            var csvData = new List<string>();
            csvData.Add(headerLine);
            csvData.AddRange(dataLines);

            _csvFileRepository.WriteToCsvFile(csvData, filePath);
        }

    }
}
