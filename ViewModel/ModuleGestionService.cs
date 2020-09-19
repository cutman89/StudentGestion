using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SQLite;
using StudentGestion.Model;
using StudentGestion.Services;
using System;
using System.Windows;

namespace StudentGestion.ViewModel
{
    public class ModuleGestionService:ViewModelBase
    {
        #region declaration
        /*Declaration*/
        private bool _exist;

        private IFrameNavigationService _navigationService;
        private string _numModule;
        public string NumModule
        {
            get
            { return _numModule; }
            set
            {
                _numModule = value;
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
        private string _coeficiant;
        public string Coefficiant
        {
            get
            {
                return _coeficiant;
            }
            set
            {
                _coeficiant = value;
                RaisePropertyChanged();
            }
        }
        #endregion 
        
        #region AddCommand
        /*Add Module*/
        private RelayCommand _addModuleCommand;
        public RelayCommand AddModuleCommand
        {
            get
            {
                return _addModuleCommand ?? (_addModuleCommand = new RelayCommand(() =>
                  {
                      _exist = false;
                      Module module = new Module();
                      if(NumModule!=null && Name!=null)
                      {
                          module.Num_Mod = int.Parse(NumModule);
                          module.Nom_Mod = Name;
                          module.Coeffissiant = int.Parse(Coefficiant);
                      }
                      using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                      {
                          connection.CreateTable<Module>();
                          var output = connection.Query<Module>("select * from module where Module.Num_Mod= " + NumModule);
                          foreach (var value in output)
                          {
                              if (NumModule == value.Num_Mod.ToString())
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
                             
                              connection.Insert(module);
                              connection.Close();
                              MessageBox.Show("Module Added");
                          }
                          else
                          {
                              MessageBox.Show("Module serial number exist");
                          }
                      }
                  }));
            }
        }
        #endregion
        
        #region EraseModuleCommand
        /*Erase Module*/
        private RelayCommand _eraseModule;
        public RelayCommand EraseModule
        {
            get
            {
                return _eraseModule ?? (_eraseModule = new RelayCommand(() =>
                {
                    _exist = false;
                    SQLiteConnection connection = new SQLiteConnection(App.databasePath);
                    var output = connection.Query<Module>("select * from module");
                    string sql = "DELETE  FROM module where Module.Num_Mod= " + NumModule;
                    var comm = connection.CreateCommand(sql);
                    try
                    {
                        foreach (var value in output)
                        {

                            if (NumModule == value.Num_Mod.ToString())
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
                        if (_exist == false)
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
        
        #region Leave programme
        /*Quitter l'application*/
        private RelayCommand _closeCommand;
        public RelayCommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand(() => { 
                
                 
                
                }));
            }
        }
        #endregion
        #region Constructor
        public ModuleGestionService(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion
    }
}
