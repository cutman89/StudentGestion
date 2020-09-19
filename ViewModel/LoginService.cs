using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StudentGestion.Services;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace StudentGestion.ViewModel
{
    public class LoginService:ViewModelBase
    {
        #region Declaration

        private IFrameNavigationService _navigationService;
        private string _login;
        public string Login
        {
            get
            {
                return _login;
                
            }
            set
            {
                _login = value;
                RaisePropertyChanged("Login");
            }

        }
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged("Password");
            }
        }
        #endregion

        #region Command
        private RelayCommand _loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new RelayCommand(() => {
                    if (Login == "Admin" && Password == "Admin")
                    {
                        _navigationService.NavigateTo("Home");
                    }
                    else
                    {
                        MessageBox.Show("Invalide password");
                    }

                }));
            }
        }

     


        #endregion
        #region Constructor 
        public LoginService(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion 
    }
}
