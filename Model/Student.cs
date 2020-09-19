using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentGestion.Model
{
    public class Student
    {
        [PrimaryKey,AutoIncrement]
        public  int Id { get; set; }
        public int Num_Etu { get; set; }
        public string Nom_Etu { get; set; }
        public string Prenom_Etu { get; set; }
        public string DateN_Etu { get; set; }
    }
}
