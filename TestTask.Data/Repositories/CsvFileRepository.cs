using TestTask.Data.Interfaces;

namespace TestTask.Data.Repositories
{
    public class CsvFileRepository : ICsvFileRepository
    {
        public void WriteToCsvFile(List<string> csvData, string filePath)
        {
            File.WriteAllLines(filePath, csvData);
        }
    }
}
