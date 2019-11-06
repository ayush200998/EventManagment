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

namespace EventManager
{
    public partial class EntryOne : Window
    {
        
       


        public EntryOne()
        {
            InitializeComponent();
        }

        private void switchButton_Click(object sender, RoutedEventArgs e)
        {
            AnnouncementWindow a1 = new AnnouncementWindow(true);
            a1.Show();
            this.Close();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            EntryTwo obj = new EntryTwo();
            obj.Show();
            this.Close();
        }

        public string returnHeading()
        {
            string heading = headingValue.Text;
            return heading;
        }
         
        public string returnDescription()
        {
            string description = descriptionValue.Text;
            return description;
        }
    }
}
