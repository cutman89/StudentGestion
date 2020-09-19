using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using StudentGestion.Services;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Xml.XPath;

namespace StudentGestion.ViewModel
{
    public class HomeService : ViewModelBase,IMainService
    {

        private IFrameNavigationService _navigationService;
       
       
        private RelayCommand _navigateToCommand;
        public RelayCommand NavigateToCommand
        {
            get
            {
                return _navigateToCommand ?? (_navigateToCommand = new RelayCommand(() => { _navigationService.NavigateTo("StudentInformation"); }));
            }
            
        }
        private RelayCommand _navigateToModuleCommand;
        public RelayCommand NavigateToModuleCommand
        {
            get
            {
                return _navigateToModuleCommand ??(_navigateToModuleCommand=new RelayCommand(()=>{
                    _navigationService.NavigateTo("ModuleGestion");
                }));
            }
        }
        private RelayCommand _navigateToDisplay;
        public RelayCommand NavigateToDisplay
        {
            get
            {
                return _navigateToDisplay ?? (_navigateToDisplay = new RelayCommand(() =>
                    {
                        _navigationService.NavigateTo("AffichageNote");
                    }));
            }
        }
        public HomeService(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private RelayCommand _noteGestionCommand;
        public RelayCommand NoteGestionCommnad
        {
            get
            {
                return _noteGestionCommand ?? (_noteGestionCommand = new RelayCommand(() =>
                  {
                      _navigationService.NavigateTo("NoteGestion");
                  }));
            }
        }
    }
}
