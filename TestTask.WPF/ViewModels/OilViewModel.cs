﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using TestTask.Business;
using TestTask.UI.Commands;

namespace TestTask.UI.ViewModels
{
    public class OilViewModel : BaseViewModel
    {
        public string RunName { get; set; }
        public string? ItemTag { get; set; }
        public int NPD { get; set; }
        public double? RunLength { get; set; }
        public double? LineWeight { get; set; }
        public double? RunDiam { get; set; }
        public double? PressureRating { get; set; }
        public string? FluidCode { get; set; }
        public double? Temp { get; set; }

        private IOilService _oilService;
        public ICommand GetOilInfo { get; set; }
        public ICommand GetConnectionStringCommand { get; set; }

        public ObservableCollection<OilModel> OilDataGrid { get; set; }

        public OilViewModel(MainViewModel mainViewModel)
        {
            GetConnectionStringCommand = new ConnectionStringBuildCommand(mainViewModel);
            _oilService = new OilService();
            OilDataGrid = new ObservableCollection<OilModel>();
            GetOilInfo = new GetOilInfoCommand(this, _oilService);
        }
    }
}