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
#pragma warning disable CS0105 // The using directive for 'EventManager.Classes' appeared previously in this namespace
using EventManager.Classes;
#pragma warning restore CS0105 // The using directive for 'EventManager.Classes' appeared previously in this namespace

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
                   
            //AnnouncementData.arrlengthnext = getCountNext();

            InitializeComponent();

            if (!AnnouncementData.wasPreviousButtonClicked && !AnnouncementData.wasNextButtonClicked)
            {
                AnnouncementData.count = 0;
                AnnouncementData.arrLength = getCount();
                //AnnouncementData.arrLengthNext = getCount();
               // AnnouncementData.wasPreviousButtonClicked = true;
               // AnnouncementData.wasNextButtonClicked = false;
                updateAnnouncement();
            }
            /*if(!AnnouncementData.wasNextButtonClicked)
            {
                //AnnouncementData.arrLength = getCount();
                AnnouncementData.wasNextButtonClicked = true;
                //updateAnnouncement();
            }*/

            if (AnnouncementData.wasPreviousButtonClicked)
            {
                updatePrevious();
            }

            if (AnnouncementData.wasNextButtonClicked)
            {
                
                updateNext();
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
            
            AnnouncementData.wasNextButtonClicked = true;
            AnnouncementData.wasPreviousButtonClicked = false;
            AnnouncementWindow aw = new AnnouncementWindow(true);
            aw.Show();
            this.Close();
        }

        private void prevButton_Click(object sender, RoutedEventArgs e)
        {
            AnnouncementData.wasPreviousButtonClicked = true;
            AnnouncementData.wasNextButtonClicked = false;
            AnnouncementWindow aw = new AnnouncementWindow(true);
            aw.Show();
            this.Close();
            
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
        
        //Announcement
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

        //Update Previous
        public void updatePrevious()
        {
            AnnouncementData.wasPreviousButtonClicked = true;
            if (AnnouncementData.arrLength > 1)
            {
                --AnnouncementData.arrLength;
            }
            SqlDataReader reader;
            SqlCommand cmd = SQLServerConnection.initializeSqlCommand("Select event_desc From Announcement where event_id=@id");

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@id";
            param.Value = AnnouncementData.arrLength;
            cmd.Parameters.Add(param);            

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                notificationDetails.Text = (reader["event_desc"].ToString());
            }
            cmd.Parameters.Clear(); reader.Close();


            cmd = SQLServerConnection.initializeSqlCommand("select date_created from Announcement where event_id=@id");
            param = new SqlParameter();
            param.ParameterName = "@id";
            param.Value = AnnouncementData.arrLength;
            cmd.Parameters.Add(param);

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dateLabel.Content = (reader["date_created"].ToString());
            }
            cmd.Parameters.Clear(); reader.Close();

            cmd = SQLServerConnection.initializeSqlCommand("select event_heading from Announcement where event_id=@id");
            param = new SqlParameter();
            param.ParameterName = "@id";
            param.Value = AnnouncementData.arrLength;
            cmd.Parameters.Add(param);

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                notificationLabel.Content = (reader["event_heading"].ToString());
            }
            cmd.Parameters.Clear(); reader.Close();
            SQLServerConnection.closeConnection();

            

        }

        // Count for Previous page index
        public static int getCount()
        {
            SqlCommand cmd = SQLServerConnection.initializeSqlCommand("select count(*) from Announcement ");
            AnnouncementData.count = (int)cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return AnnouncementData.count;
        }

        //Update Next
        public void updateNext()
        {
            
            AnnouncementData.wasNextButtonClicked = true;
            if (AnnouncementData.arrLength < AnnouncementData.count)
            {
                ++AnnouncementData.arrLength;
            }
            SqlCommand cmd = SQLServerConnection.initializeSqlCommand("Select event_desc From Announcement where event_id=@id");
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@id";
            param.Value = AnnouncementData.arrLength;
            cmd.Parameters.Add(param);
            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                notificationDetails.Text = (reader["event_desc"].ToString());
            }
            cmd.Parameters.Clear(); reader.Close();


            cmd = SQLServerConnection.initializeSqlCommand("select date_created from Announcement where event_id=@id");
            param = new SqlParameter();
            param.ParameterName = "@id";
            param.Value = AnnouncementData.arrLength;
            cmd.Parameters.Add(param);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dateLabel.Content = (reader["date_created"].ToString());
            }
            cmd.Parameters.Clear(); reader.Close();

            cmd = SQLServerConnection.initializeSqlCommand("select event_heading from Announcement where event_id=@id");
            param = new SqlParameter();
            param.ParameterName = "@id";
            param.Value = AnnouncementData.arrLength;
            cmd.Parameters.Add(param);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                notificationLabel.Content = (reader["event_heading"].ToString());
            }
            cmd.Parameters.Clear(); reader.Close();
            SQLServerConnection.closeConnection();

            


        }

        //Count for next page index
       /* public static int getCountNext()
        {
            SqlCommand cmd = SQLServerConnection.initializeSqlCommand("select count(*) from Announcement ");
            AnnouncementData.count = (int)cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return AnnouncementData.count;
        }*/

    }
}

