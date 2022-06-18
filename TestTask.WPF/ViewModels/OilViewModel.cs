using System.Collections.ObjectModel;
using System.Windows.Input;
using TestTask.Business;
using TestTask.Business.Services;
using TestTask.UI.Commands;

namespace TestTask.UI.ViewModels
{
    public class OilViewModel : BaseViewModel
    {
        private string _server;
        private string _database;
        private string _userName;
        private string _password;
        private bool _isConnectButtonEnabled;
        private CsvFileService _csvFileService;

        public string Server
        {
            get => _server;
            set
            {
                _server = value;
                OnPropertyChanged(nameof(Server));
                CheckIfFieldsAreFilled();
            }
        }

        public string Database
        {
            get => _database;
            set
            {
                _database = value;
                OnPropertyChanged(nameof(Database));
                CheckIfFieldsAreFilled();
            }
        }

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
                CheckIfFieldsAreFilled();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public bool IsConnectButtonEnabled
        {
            get => _isConnectButtonEnabled;
            set
            {
                if (value != _isConnectButtonEnabled)
                {
                    _isConnectButtonEnabled = value;
                    OnPropertyChanged(nameof(IsConnectButtonEnabled));
                    CheckIfFieldsAreFilled();
                }
            }
        }

        public ICommand ConnectToServerCommand { get; set; }
        public ICommand ExportToCsvFileCommand { get; set; }
        public ObservableCollection<OilModel> OilDataGrid { get; set; }

        public OilViewModel()
        {
            _csvFileService = new CsvFileService();

            OilDataGrid = new ObservableCollection<OilModel>();
            ConnectToServerCommand = new ConnectToServerCommand(this);
            ExportToCsvFileCommand = new ExportToCsvFileCommand(this, _csvFileService);
        }

        private void CheckIfFieldsAreFilled()
        {
            IsConnectButtonEnabled = !(string.IsNullOrWhiteSpace(Server)) && !(string.IsNullOrWhiteSpace(Database))
                && !(string.IsNullOrWhiteSpace(UserName));
        }

    }
}
