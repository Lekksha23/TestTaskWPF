using System;
using System.Data.SqlClient;
using System.Windows;
using TestTask.Business;
using TestTask.Business.Services;
using TestTask.UI.ViewModels;

namespace TestTask.UI.Commands
{
    public class ConnectToServerCommand : BaseCommand
    {
        private OilViewModel _oilViewModel;
        private SqlConnection _connString;

        public ConnectToServerCommand(OilViewModel oilViewModel)
        {
            _oilViewModel = oilViewModel;
        }

        public override void Execute(object parameter)
        {
            var connString = $"Server={_oilViewModel.Server};Database={_oilViewModel.Database};User={_oilViewModel.UserName};Password={_oilViewModel.Password};";
            _connString = new SqlConnection(connString);

            try
            {
                var sqlHelper = new SqlHelper(_connString);
                if (sqlHelper.IsConnectionSucceeded)
                {
                    MessageBox.Show("Connection succeeded", "Congratulations!", MessageBoxButton.OK);
                    FillDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FillDataGrid()
        {
            var oilService = new OilService(_connString);
            var oilList = oilService.GetOilInfo();
            _oilViewModel.OilDataGrid.Clear();

            foreach (var item in oilList)
            {
                _oilViewModel.OilDataGrid.Add(item);
            }
        }
    }
}
