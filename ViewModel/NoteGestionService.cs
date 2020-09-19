using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SQLite;
using StudentGestion.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Security.RightsManagement;
using System.Text;
using System.Windows;

namespace StudentGestion.ViewModel
{
    public class NoteGestionService:ViewModelBase
    {
        #region Declaration
        private bool _exist;
        public ObservableCollection<SheetMark> sheets { get; set; }
       
        public IList<Student> students { get; set; }
        public IList<Module> modules { get; set; }
        Module module = new Module();
        Student student = new Student();

        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get
            {
                return _selectedStudent;
            }
            set
            {
                _selectedStudent = value;
                RaisePropertyChanged("SelectedStudent");
            }
        }
        private Module _selectedModule;
        public Module SelectedModule
        {
            get
            {
                return _selectedModule;
            }
            set
            {
                _selectedModule= value;
                RaisePropertyChanged("SelectedModule");
            }
        }
        private string _num_Etu;
        public string Num_Etu
        {
            get
            {
                return _num_Etu;
            }
            set
            {
                _num_Etu = value;
                RaisePropertyChanged("Num_Etu");
            }
        }
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
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
                RaisePropertyChanged("Prenom");
            }
        }

        private string _fullName;
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                _fullName = value;
                RaisePropertyChanged("FullName");
            }
        }
        private string _moduleName;
        public string ModuleName
        {
            get
            {
                return _moduleName;
            }
            set
            {
                _moduleName = value;
                RaisePropertyChanged("ModuleName");
            }
        }
        private string _note;
        public string Note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = value;
                RaisePropertyChanged("Note");
            }
        }


        #endregion
        #region Constructor
        public NoteGestionService()
        {
            SQLiteConnection connection = new SQLiteConnection(App.databasePath);
            sheets = new ObservableCollection<SheetMark>();
            students = new List<Student>();
            modules = new List<Module>();
            var outputStudent = connection.Query<Student>("select * from student");
            var outputModule = connection.Query<Module>("select* from module");
            foreach(var value in outputStudent)
            {
                students.Add(new Student
                {
                    Num_Etu = value.Num_Etu,
                    Nom_Etu = value.Nom_Etu,
                    Prenom_Etu=value.Prenom_Etu

                });
            }
            foreach(var value in outputModule)
            {
                modules.Add(new Module
                {
                    Num_Mod=value.Num_Mod,
                    Nom_Mod = value.Nom_Mod
                }) ;
            }
            

            
        }
        #endregion
        #region recrodNote
        private RelayCommand _recordNote;
        public RelayCommand RecordNote
        {
            get
            {
                return _recordNote ?? (_recordNote = new RelayCommand(() =>
                {
                    _exist = false;
                    SQLiteConnection connection = new SQLiteConnection(App.databasePath);
                    Notes note = new Notes();
                    if (SelectedStudent!=null && FullName != string.Empty && Note != string.Empty)
                    {
                        note.Num_Etu = SelectedStudent.Num_Etu;
                        note.Num_Mod = SelectedModule.Num_Mod;
                        note.Note = double.Parse(Note);
                        connection.CreateTable<Notes>();

                        var outputNote = connection.Query<Notes>("select * from notes where Notes.Num_Etu= " + SelectedStudent.Num_Etu + " and Notes.Num_Mod= " + SelectedModule.Num_Mod);


                        foreach (var value in outputNote)
                        {
                            if (value.Num_Etu == SelectedStudent.Num_Etu && value.Num_Mod == SelectedModule.Num_Mod)
                            {
                                _exist = true;
                                MessageBox.Show("Note exist");
                                break;
                            }
                            else
                            {
                                continue;
                            }

                        }

                        if (_exist == false)
                        {
                            connection.Insert(note);
                            connection.Close();
                            MessageBox.Show("Note ADDED");
                          
                        }
                    }
                    else
                    {
                        MessageBox.Show("Champ vide");
                    }
               



                }));

            }
        }
        #endregion
        #region Apercu
        private RelayCommand _appercu;
        public RelayCommand Appercu
        {
            get
            {
                return _appercu ?? (_appercu = new RelayCommand(() =>
                  {
                      SQLiteConnection connection = new SQLiteConnection(App.databasePath);
                      SheetMark sheet = new SheetMark();
                      var output1 = connection.Query<Student>("Select * from student");
                      var output2 = connection.Query<Module>("Select * from module");
                      var output3 = connection.Query<Notes>("select * from notes");
                      foreach(var valueStudent in output1)
                      {
                          foreach(var valueModule in output2)
                          {
                             
                              foreach (var valueNote in  output3)
                              {
                                 
                                  if (valueStudent.Num_Etu==valueNote.Num_Etu && valueModule.Num_Mod==valueNote.Num_Mod)
                                  {
                                      
                                      sheets.Add(
                                          new SheetMark
                                          {
                                            Num_Etu = valueStudent.Num_Etu.ToString(),
                                            FirstName = valueStudent.Nom_Etu,
                                            LastName = valueStudent.Prenom_Etu,
                                            ModuleName = valueModule.Nom_Mod,
                                           Note = valueNote.Note.ToString()
                              });
                                     
                                  }
                              }
                          }
                        
                      }
                  }));
            }
        }
        #endregion

    }
}
