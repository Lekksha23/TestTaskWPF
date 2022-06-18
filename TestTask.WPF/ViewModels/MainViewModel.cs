namespace TestTask.UI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public OilViewModel OilViewModel { get; set; }

        public MainViewModel()
        {
            OilViewModel = new OilViewModel();
        }
    }
}
