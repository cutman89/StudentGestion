using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SQLite;
using StudentGestion.Model;
using StudentGestion.Services;
using StudentGestion.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace StudentGestion.ViewModel
{
    public class StudentModifyService:ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        private string _numInscription;
        public string NumInscription
        {
            get
            { return _numInscription; }
            set
            {
                _numInscription = value;
                RaisePropertyChanged();
            }
        }
        private string _nom;
        public string Name
        {
            get
            {
                return _nom;
            }
            set
            {
                _nom = value;
                RaisePropertyChanged();
            }
        }
        private string _prenom;
        public string Prenom
        {
            get
            {
                return _prenom;
            }
            set
            {
                _prenom = value;
                RaisePropertyChanged();
            }
        }
        private DateTime _date;
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                RaisePropertyChanged("Date");
            }
        }
        private RelayCommand _modifyStudent;
        public RelayCommand ModifyCommand
        {
            get
            {
                return  _modifyStudent ?? (_modifyStudent = new RelayCommand(() =>
                  {
                      SQLiteConnection connection = new SQLiteConnection(App.databasePath);
                      try
                      {
                          var output = connection.Query<Student>($"update student Set Nom_Etu='{Name}', Prenom_Etu='{Prenom}',DateN_Etu='{Date}'  where Student.Num_Etu= " + NumInscription);
                          MessageBox.Show("Student information modifyed");
                      }
                      catch (Exception x)
                      {
                          MessageBox.Show("Doesnt exist" + x.Message);
                      }
                      finally
                      {
                          connection.Close();
                      }
                  }));
            }
        }
       public void Show(object viewModel)
        {
            StudentModify studentModify = new StudentModify();
            studentModify.DataContext = viewModel;
            studentModify.Show();
        }
        public StudentModifyService(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
