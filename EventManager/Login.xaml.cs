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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SQLServerConnection.openConnection();
            
            SQLServerConnection.sql = "select * from *";
            SQLServerConnection.cmd.CommandType = CommandType.Text;
            SQLServerConnection.cmd.CommandText = SQLServerConnection.sql;

            SQLServerConnection.da = new SqlDataAdapter(SQLServerConnection.cmd);
            SQLServerConnection.dt = new DataTable();
            SQLServerConnection.da.Fill(SQLServerConnection.dt);

            SQLServerConnection.closeConnection();
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
            {

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
