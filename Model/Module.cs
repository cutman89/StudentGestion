using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentGestion.Model
{
    public class Module
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public int  Num_Mod { get; set; }
        public string Nom_Mod { get; set; }
        public int Coeffissiant { get; set; }
    }
}
