using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//Used to act upon the SQLServerConnection
using System.Data;
using System.Data.SqlClient;
using EventManager.Classes;

namespace EventManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool isTeacher = false;
        bool isStudent = false;

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            loginButton.Background = (Brush)(new BrushConverter().ConvertFrom("#FF82B3C9"));
            exceptionLabel.Content = "";

            if (!(isTeacher || isStudent))
            {
                exceptionLabel.Content = "**Student/Teacher Button NOT Selected**";
            }
            else
            {   //SQL Command template.
                //SqlCommand cmd = SQLServerConnection.initializeSqlCommand("");
                //body
                //SQLServerConnection.closeConnection();

                SqlCommand cmd = SQLServerConnection.initializeSqlCommand("select count(*) from LoginTable where usn=@usn and pwd=@pwd and usertype=@usertype");
                char usertype = ' ';
                bool studentOrTeacher = false;

                if (isTeacher)
                {
                    usertype = 't';
                    studentOrTeacher = true;
                }
                if (isStudent)
                {
                    usertype = 's';
                    studentOrTeacher = false;
                }

                cmd.Parameters.AddWithValue("@usn", userIdValue.Text);
                cmd.Parameters.AddWithValue("@pwd", passwordValue.Password);
                cmd.Parameters.AddWithValue("@usertype", usertype);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    AnnouncementWindow announcement = new AnnouncementWindow(studentOrTeacher);
                    announcement.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect.");
                }

                    
                SQLServerConnection.closeConnection();
            }
            /*if(isTeacher&&isStudent)
                exceptionLabel.Content = "**Student/Teacher Button NOT Selected**";*/
        }

        private void teacherButton_Click(object sender, RoutedEventArgs e)
        {
            isTeacher = !isTeacher;
            isStudent = false;

            if (isTeacher)
            {
                teacherButton.Background = (Brush)(new BrushConverter().ConvertFrom("#FF82B3C9"));
                studentButton.Background = (Brush)(new BrushConverter().ConvertFrom("#FFA4A4A4"));
            }
            else
            {
                teacherButton.Background = (Brush)(new BrushConverter().ConvertFrom("#FFA4A4A4"));
                studentButton.Background = (Brush)(new BrushConverter().ConvertFrom("#FFA4A4A4"));
            }
        }

        private void studentButton_Click(object sender, RoutedEventArgs e)
        {
            isTeacher = false;
            isStudent = !isStudent;

            if (isStudent)
            {
                teacherButton.Background = (Brush)(new BrushConverter().ConvertFrom("#FFA4A4A4"));
                studentButton.Background = (Brush)(new BrushConverter().ConvertFrom("#FF82B3C9"));
            }
            else
            {
                teacherButton.Background = (Brush)(new BrushConverter().ConvertFrom("#FFA4A4A4"));
                studentButton.Background = (Brush)(new BrushConverter().ConvertFrom("#FFA4A4A4"));
            }
        }
    }
}
