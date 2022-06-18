
namespace TestTask.Data.Interfaces
{
    public interface ICsvFileRepository
    {
        void WriteToCsvFile(List<string> csvData, string filePath);
    }
}