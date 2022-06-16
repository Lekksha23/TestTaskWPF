using System;
using System.Data.SqlClient;
using System.Windows;
using TestTask.Business;
using TestTask.UI.Commands;
using TestTask.UI.ViewModels;

namespace TestTask.UI
{
    public class ConnectToServerCommand : BaseCommand
    {
        private string _server;
        private string _database;
        private string _userName;
        private string _password;
        private OilViewModel _oilViewModel;
        public SqlConnection ConnString { get; private set; }

        public ConnectToServerCommand(OilViewModel oilViewModel, MainViewModel mainViewModel)
        {
            _server = mainViewModel.Server;
            _database = mainViewModel.Database;
            _userName = mainViewModel.UserName;
            _password = mainViewModel.Password;
            _oilViewModel = oilViewModel;
        }

        public override void Execute(object parameter)
        {
            var connString = $"Server={_server};Database={_database};User={_userName};Password={_password};";
            ConnString = new SqlConnection(connString);

            try
            {
                var sqlHelper = new SqlHelper(ConnString);
                if (sqlHelper.IsConnectionSucceeded)
                {
                    MessageBox.Show("Connection succeeded", "Congratulations!", MessageBoxButton.OK);
                    var oilService = new OilService(ConnString);
                    var oilList = oilService.GetOilInfo();
                    _oilViewModel.OilDataGrid.Clear();

                    foreach (var item in oilList)
                    {
                        _oilViewModel.OilDataGrid.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
