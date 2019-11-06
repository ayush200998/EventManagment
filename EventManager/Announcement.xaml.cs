using EventManager.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace EventManager
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AnnouncementWindow : Window
    {
        bool studentOrTeacher = false; //false for student, true for teacher
        public AnnouncementWindow(bool SoT)
        {
            InitializeComponent();
            studentOrTeacher = SoT;
            if (studentOrTeacher)
            {
                switchButton.IsEnabled = true;
                switchButton.Visibility = Visibility.Visible;
            }
            else
            {
                switchButton.IsEnabled = false;
                switchButton.Visibility = Visibility.Hidden;
            }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void prevButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void switchButton_Click(object sender, RoutedEventArgs e)
        {
            EntryOne e1 = new EntryOne();
            e1.Show();
            this.Close();
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow lw = new LoginWindow();
            lw.Show();
            this.Close();
        }

        private void NotificationDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqlCommand cmd = SQLServerConnection.initializeSqlCommand("select event_desc from Announcement");
            SqlDataReader reader=cmd.ExecuteReader();
            while(reader.Read())
            {
                notificationDetails.tex(reader.GetTextReader(2));
            }
            cmd.Parameters.Clear();
            SQLServerConnection.closeConnection();
        }
    }
}
