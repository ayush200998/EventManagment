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
using System.Windows.Shapes;

using System.Data;
using System.Data.SqlClient;
using EventManager.Classes;


namespace EventManager
{

    /// <summary>
    /// Interaction logic for CrearteEnteriestwo.xaml
    /// </summary>
    public partial class EntryTwo : Window
    {


        public EntryTwo()
        {
            InitializeComponent();
        }

        private void prevButton_Click(object sender, RoutedEventArgs e)
        {
            EntryOne e1 = new EntryOne();
            e1.Show();
            this.Close();
        }

        private void switchButton_Click(object sender, RoutedEventArgs e)
        {
            AnnouncementWindow aw = new AnnouncementWindow(true);
            aw.Show();
            this.Close();

        }

        private void changeButtonColor(Button b, int index)
        {
            AnnouncementData.departmentsAllowed[index] = !(AnnouncementData.departmentsAllowed[index]);
            if (AnnouncementData.departmentsAllowed[index])
            {
                b.Background = (Brush)(new BrushConverter().ConvertFrom("#FF006A4E"));
            }
            else
            {
                b.Background = (Brush)(new BrushConverter().ConvertFrom("#FF8B0101"));
            }
        }

        private void cseButton_Click(object sender, RoutedEventArgs e)
        {
            changeButtonColor(cseButton, 0);
        }

        private void iseButton_Click(object sender, RoutedEventArgs e)
        {
            changeButtonColor(iseButton, 1);
        }

        private void meButton_Click(object sender, RoutedEventArgs e)
        {
            changeButtonColor(meButton, 2);
        }

        private void eceButton_Click(object sender, RoutedEventArgs e)
        {
            changeButtonColor(eceButton, 3);
        }

        private void eeeButton_Click(object sender, RoutedEventArgs e)
        {
            changeButtonColor(eeeButton, 4);
        }

        private void civButton_Click(object sender, RoutedEventArgs e)
        {
            changeButtonColor(civButton, 5);
        }

        public void getValues()
        {
            EntryOne e1 = new EntryOne();
            string heading = e1.returnHeading();
            string description = e1.returnDescription();

        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            AnnouncementData.calculateErrors();

            if (organiserCombobox.SelectedIndex <= -1)
            {
                MessageBox.Show("Please select the department which is passing this information.");
            }
            else if (AnnouncementData.noDepartmentSelected)
            {
                MessageBox.Show("Please select at least one department which this announcement/notification has to be shown to.");
            }
            else
            {
                SqlCommand cmd = SQLServerConnection.initializeSqlCommand("insert into Announcement (event_heading, event_desc, org_branch, elig_branch, date_created) values (@heading, @desc, @org, @elig, @date)");
                cmd.Parameters.AddWithValue("@heading", AnnouncementData.announcementTitle);
                cmd.Parameters.AddWithValue("@desc", AnnouncementData.announcementDetails);
                cmd.Parameters.AddWithValue("@org", organiserCombobox.SelectedIndex);
                cmd.Parameters.AddWithValue("@elig", AnnouncementData.eligibleBranches());

                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

                cmd.Parameters.AddWithValue("@date", sqlFormattedDate);

                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                SQLServerConnection.closeConnection();

                AnnouncementWindow aw = new AnnouncementWindow(true);
                aw.Show();
                this.Close();

            }

        }
    }
}
