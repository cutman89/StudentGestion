using GalaSoft.MvvmLight;
using StudentGestion.Model;
using StudentGestion.Services;
using StudentGestion.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace StudentGestion.ViewModel
{
    public class AverageService:ViewModelBase
    {
        #region Declaration
        public ObservableCollection<SheetMark> sheets { get; set; }
        private IFrameNavigationService _navigationService;
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                RaisePropertyChanged("FirstName");
            }

        }
        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                RaisePropertyChanged("LastName");
            }

        }
        private double  _average;
        public double  Average
        {
            get
            {
                return  _average;
            }
            set
            {
                _average = value;
                RaisePropertyChanged("Average");
            }
        }
        #endregion
        #region Constructor
        public AverageService(IFrameNavigationService navigationService)
        {
            sheets = new ObservableCollection<SheetMark>();
            _navigationService = navigationService;
        }
        #endregion
        #region Method
        public void Show(object viewModel)
        {
            AverageView averageView = new AverageView();
            averageView.DataContext = viewModel;
            averageView.Show();
        }
        #endregion

    }
}
