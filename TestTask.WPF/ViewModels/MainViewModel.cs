namespace TestTask.UI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _server;
        private string _database;
        private string _userName;
        private string _password;

        public string Server
        {
            get => _server;
            set
            {
                _server = value;
                OnPropertyChanged(nameof(Server));
            }
        }

        public string Database
        {
            get => _database;
            set
            {
                _database = value;
                OnPropertyChanged(nameof(Database));
            }
        }

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
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

        public OilViewModel OilViewModel { get; set; }

        public MainViewModel()
        {
            OilViewModel = new OilViewModel(this);
        }
    }
}
