using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StudentGestion.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentGestion.ViewModel
{
    public class MainService:ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        private RelayCommand _loadedCommand;
        public RelayCommand LoadedCommand
        {
            get
            {
                return _loadedCommand
                    ?? (_loadedCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("LoginPage");
                    }));
            }
        }

        public MainService(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
