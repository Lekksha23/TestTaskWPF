using System;
using System.Data.SqlClient;
using System.Windows;
using TestTask.Business;
using TestTask.UI.Commands;
using TestTask.UI.ViewModels;

namespace TestTask.UI
{
    public class ConnectionStringBuildCommand : BaseCommand
    {
        private string _server;
        private string _database;
        private string _userName;
        private string _password;
        private string _connString;

        public ConnectionStringBuildCommand(MainViewModel mainViewModel)
        {
            _server = mainViewModel.Server;
            _database = mainViewModel.Database;
            _userName = mainViewModel.UserName;
            _password = mainViewModel.Password;
        }

        public override void Execute(object parameter)
        {
            _connString = $"DataSource={_server};InitialCatalog={_database};UserId={_userName};Password={_password};";
            var connection = new SqlConnection(_connString);

            try
            {
                var sqlHelper = new SqlHelper(connection);
                if (sqlHelper.IsConnectionSucceeded)
                {
                    MessageBox.Show("Connection succeeded", "Message", MessageBoxButton.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
