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
    public class StudentInformationService:ViewModelBase
    {
        #region Declaration
        private bool _exist;
       
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
        public string Name { 
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
        public string Prenom { 
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
        #endregion

        #region resetCommand
        private RelayCommand _nouveau;
        public RelayCommand Nouveau
        {
            get
            {
                return _nouveau ?? (_nouveau = new RelayCommand(() => {

                    NumInscription = string.Empty;
                    Name = string.Empty;
                    Prenom = string.Empty;

                
                }));
            }

        }
        #endregion

        #region SearchStudent
        private RelayCommand _searchStudent;
        public RelayCommand SearchStudent
        {
            get
            {
                return _searchStudent ?? (_searchStudent = new RelayCommand(() => {

                    SQLiteConnection connection = new SQLiteConnection(App.databasePath);

                    try
                    {
                        var output = connection.Query<Student>("select * from student where Student.Num_Etu= " + NumInscription);

                        foreach (var value in output)
                        {
                            Name = value.Nom_Etu;
                            Prenom = value.Prenom_Etu;
                            Date = DateTime.Parse(value.DateN_Etu);
                        }

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
        #endregion

        #region AddStudent
        private RelayCommand _addStudent;
        public RelayCommand AddStudent
        {
            get
            {
                return _addStudent ?? (_addStudent = new RelayCommand(() => {
                    _exist = false;
                    Student student = new Student();
                 
                    if (NumInscription !=null && Name !=null && Prenom !=null)
                    {
                        student.Num_Etu = int.Parse(NumInscription);
                        student.Nom_Etu = Name;
                        student.Prenom_Etu = Prenom;
                        student.DateN_Etu = Date.ToString("dd/MM/yyyy");
                        using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                        {
                            connection.CreateTable<Student>();
                            var output = connection.Query<Student>("select * from student where Student.Num_Etu= " + NumInscription);
                            foreach(var value in output)
                            {
                                if(NumInscription==value.Num_Etu.ToString())
                                {
                                    _exist = true;
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            if (_exist == false)
                            {
                                
                                connection.Insert(student);
                                connection.Close();
                                MessageBox.Show("Student Added");
                            }
                            else
                            {
                                MessageBox.Show("Student serial number exist");
                            }
                        }
                      
                    }
                    else
                    {
                        MessageBox.Show("Empty");
                    }
                    NumInscription = string.Empty;
                    Name = string.Empty;
                    Prenom = string.Empty;
                }));
            }
        }
        #endregion
        
        #region eraseStudent
        private RelayCommand _eraseStudent;
        public RelayCommand EraseStudent
        {
            get
            {
                return _eraseStudent ?? (_eraseStudent = new RelayCommand(() =>
                {
                   _exist = false;     
                   SQLiteConnection connection = new SQLiteConnection(App.databasePath);
                   var output = connection.Query<Student>("select * from student");
                   string sql = "DELETE  FROM student where Student.Num_Etu= "+NumInscription ;
                   var comm = connection.CreateCommand(sql);
                    try
                    {
                        foreach (var value in output)
                        {
                           
                                if (NumInscription == value.Num_Etu.ToString())
                                {
                                    comm.ExecuteNonQuery();
                                    MessageBox.Show("Deleted...");
                                    _exist = true;
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                                
                         }
                        if(_exist==false)
                        {
                            MessageBox.Show("input doesnt exist");
                        }
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show("Not Deleted " + x.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                       
                   }));
            
            }
        }
        #endregion

        #region modifyStudent
        private RelayCommand _modifyStudent;
        public RelayCommand ModifyStudent
        {
            get
            {
                return _modifyStudent ?? (_modifyStudent = new RelayCommand(() =>
                {
                    _exist = false;
                    StudentModifyService studentModify = new StudentModifyService(_navigationService);
                    SQLiteConnection connection = new SQLiteConnection(App.databasePath);

                    try
                    {
                        var output = connection.Query<Student>("select * from student where Student.Num_Etu= " +NumInscription);

                        foreach (var value in output)
                        {
                            if (NumInscription == value.Num_Etu.ToString())
                            {
                                studentModify.NumInscription = value.Num_Etu.ToString();
                                studentModify.Name = value.Nom_Etu;
                                studentModify.Prenom = value.Prenom_Etu;
                                studentModify.Date = DateTime.Parse(value.DateN_Etu);
                               _exist = true;
                            }
                        }
                        if (_exist == true)
                        {
                            studentModify.Show(studentModify);
                        }
                        else
                        {
                            MessageBox.Show("input doesn't exist");
                        }
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show("Doesnt exist " + x.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }

                   

                
                }));
            }
        }
        #endregion
        
        #region Constructor
        public StudentInformationService(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion

    }
}
