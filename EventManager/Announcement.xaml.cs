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
using EventManager.Classes;

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
            if (!AnnouncementData.wasPreviousButtonClicked)
            {
                updateAnnouncement();
            }
            if (AnnouncementData.wasPreviousButtonClicked)
            {
                updatePrevious();
            }
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
            updatePrevious();
            AnnouncementWindow aw = new AnnouncementWindow(true);
            aw.Show();
            this.Close();
            //updatePrevious();
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

        public void updateAnnouncement()
        {
            SqlCommand cmd = SQLServerConnection.initializeSqlCommand("select event_desc from Announcement");
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                notificationDetails.Text = (reader["event_desc"].ToString());   
            }
            cmd.Parameters.Clear(); reader.Close();

            cmd= SQLServerConnection.initializeSqlCommand("select date_created from Announcement");
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dateLabel.Content = (reader["date_created"].ToString());
            }
            cmd.Parameters.Clear(); reader.Close();

            cmd = SQLServerConnection.initializeSqlCommand("select event_heading from Announcement");
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                notificationLabel.Content = (reader["event_heading"].ToString());
            }
            cmd.Parameters.Clear(); reader.Close();
            SQLServerConnection.closeConnection();
        }
        public void updatePrevious()
        {
            AnnouncementData.wasPreviousButtonClicked = true;
            
            
            //SqlCommand cmd = SQLServerConnection.initializeSqlCommand("Select event_desc From Announcement where event_id=4 ");

            SqlCommand cmd = SQLServerConnection.initializeSqlCommand("Select event_desc From Announcement where event_id=@id");
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@id";
            param.Value = AnnouncementData.arrlength;
            cmd.Parameters.Add(param);
            SqlDataReader reader = cmd.ExecuteReader();
            

            while (reader.Read())
            {
                    notificationDetails.Text = (reader["event_desc"].ToString());
            }
            cmd.Parameters.Clear(); reader.Close();


            cmd = SQLServerConnection.initializeSqlCommand("select date_created from Announcement where event_id=4");
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dateLabel.Content = (reader["date_created"].ToString());
            }
            cmd.Parameters.Clear(); reader.Close();

            cmd = SQLServerConnection.initializeSqlCommand("select event_heading from Announcement where event_id=4");
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                notificationLabel.Content = (reader["event_heading"].ToString());
            }
            cmd.Parameters.Clear(); reader.Close();
            SQLServerConnection.closeConnection();


        }
        public static int getCount()
        {
          SqlCommand  cmd = SQLServerConnection.initializeSqlCommand("select event_desc from Announcement ");
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                AnnouncementData.count++;
            }
            reader.Close();
            Console.WriteLine(AnnouncementData.count);
            return AnnouncementData.count;
        }

    }

}

