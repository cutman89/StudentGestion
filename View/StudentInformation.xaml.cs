using Microsoft.Data.Sqlite;
using SQLite;
using StudentGestion.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.Text;
using System.Threading.Channels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentGestion.View
{
    /// <summary>
    /// Logique d'interaction pour StudentInformation.xaml
    /// </summary>
    public partial class StudentInformation : Page
    {
        public StudentInformation()
        {
            InitializeComponent();
        }

      

        private void Add_Student(object sender, RoutedEventArgs e)
        {
            
          
        }
        private void Erase_Student(object sender,RoutedEventArgs e)
        {

            
        }
      
        
        private void Modify_Student(object sender, RoutedEventArgs e)
        {

            StudentModify studentModify = new StudentModify();
            SQLiteConnection connection = new SQLiteConnection(App.databasePath);

            try
            {
                var output = connection.Query<Student>("select * from student where Student.Num_Etu= " + numInscri.Text);

                foreach (var value in output)
                {
                    studentModify.numInscri.Text = value.Num_Etu.ToString();
                    studentModify.nom.Text = value.Nom_Etu;
                    studentModify.prenom.Text = value.Prenom_Etu;
                    studentModify.dateNaiss.Text = value.DateN_Etu.ToString();
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
           
            studentModify.Show();

        }

    }
}
