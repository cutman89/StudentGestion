using GalaSoft.MvvmLight;
using SQLite;
using StudentGestion.Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;

namespace StudentGestion.ViewModel
{
    public class AffichageNoteService:ViewModelBase
    {
        public IList<Student> students { get; set; }
        Student student = new Student();
        SQLiteConnection connection = new SQLiteConnection(App.databasePath);
        public AffichageNoteService()
        {
            students = new List<Student>();
            var outuput = connection.Query<Student>("Select * from student");
            foreach(var value in outuput)
            {
                students.Add(new Student {
                Num_Etu = value.Num_Etu,
                Nom_Etu = value.Nom_Etu,
                Prenom_Etu = value.Prenom_Etu,
                DateN_Etu = value.DateN_Etu
            });
              
                
            }
        }
    }
}
