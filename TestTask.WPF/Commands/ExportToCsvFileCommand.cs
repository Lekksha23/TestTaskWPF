using Microsoft.Win32;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using TestTask.Business;
using TestTask.Business.Services;
using TestTask.UI.ViewModels;

namespace TestTask.UI.Commands
{
    public class ExportToCsvFileCommand : BaseCommand
    {
        private ObservableCollection<OilModel> _oilDataGrid;
        private CsvFileService _csvFileService;
        private const string _filter = ".csv|*.csv";

        public ExportToCsvFileCommand(OilViewModel oilViewModel, CsvFileService csvFileService)
        {
            _oilDataGrid = oilViewModel.OilDataGrid;
            _csvFileService = csvFileService;
        }

        public override void Execute(object parameter)
        {
            if (_oilDataGrid.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = _filter };

                if (saveFileDialog.ShowDialog() == true)
                {
                    var oilList = new List<OilModel>();
                    foreach (var item in _oilDataGrid)
                    {
                        oilList.Add(item);
                    }
                    _csvFileService.WriteToCsvFile(oilList, saveFileDialog.FileName);
                    MessageBox.Show("Exported successfully.");
                }
            }
        }

    }
}
