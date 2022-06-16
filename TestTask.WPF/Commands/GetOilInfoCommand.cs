using TestTask.Business;
using TestTask.UI.ViewModels;

namespace TestTask.UI.Commands
{
    public class GetOilInfoCommand : BaseCommand
    {
        private readonly OilViewModel _vm;
        private readonly IOilService _oilservice;

        public GetOilInfoCommand(OilViewModel vm, IOilService oilService)
        {
            _vm = vm;
            _oilservice = oilService;
        }

        public override void Execute(object parameter)
        {
            var oilList = _oilservice.GetOilInfo();

            foreach (var item in oilList)
            {
                _vm.OilDataGrid.Add(item);
            }
        }
    }
}
