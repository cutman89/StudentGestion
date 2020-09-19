using SQLite;
using StudentGestion.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentGestion.View
{
    /// <summary>
    /// Logique d'interaction pour StudentModify.xaml
    /// </summary>
    public partial class StudentModify : Window
    {
       
        public StudentModify()
        {
            InitializeComponent();
        }

        private void modify_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection connection = new SQLiteConnection(App.databasePath);


            try
            {
                var output = connection.Query<Student>($"update student Set Nom_Etu='{nom.Text}', Prenom_Etu='{prenom.Text}',DateN_Etu='{dateNaiss.Text}'  where Student.Num_Etu= " + numInscri.Text);
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

        }
    }
}
