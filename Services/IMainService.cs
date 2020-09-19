using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StudentGestion.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace StudentGestion.Services
{
    public interface IMainService
    {
        RelayCommand NavigateToCommand { get;}
       
       
    }
}
