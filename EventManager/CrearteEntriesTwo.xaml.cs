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

        private void cseButton_Click(object sender, RoutedEventArgs e)
        {
            
            if(AnnouncementData.departmentsAllowed[0])
            {
                cseButton.Background = (Brush)(new BrushConverter().ConvertFrom("#FF82B3C9"));
            }
        }

        private void iseButton_Click(object sender, RoutedEventArgs e)
        {

            // if (AnnouncementData.departmentsAllowed[1])
            AnnouncementData.departmentsAllowed[1] = !AnnouncementData.departmentsAllowed[1];
             if (AnnouncementData.departmentsAllowed[1])
            {
                iseButton.Background = (Brush)(new BrushConverter().ConvertFrom("#800000"));
            }
            else
            {
                iseButton.Background = (Brush)(new BrushConverter().ConvertFrom("#FFA4A4A4"));
            }
        }

        private void meButton_Click(object sender, RoutedEventArgs e)
        {
            if (AnnouncementData.departmentsAllowed[2])
            {
                eceButton.Background = (Brush)(new BrushConverter().ConvertFrom("#FF82B3C9"));
            }
        }

        private void eceButton_Click(object sender, RoutedEventArgs e)
        {
            if (AnnouncementData.departmentsAllowed[3])
            {
                eeeButton.Background = (Brush)(new BrushConverter().ConvertFrom("#FF82B3C9"));
            }
        }

        private void eeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (AnnouncementData.departmentsAllowed[4])
            {
                meButton.Background = (Brush)(new BrushConverter().ConvertFrom("#FF82B3C9"));
            }
        }

        private void civButton_Click(object sender, RoutedEventArgs e)
        {
            if (AnnouncementData.departmentsAllowed[5])
            {
                civButton.Background = (Brush)(new BrushConverter().ConvertFrom("#FF82B3C9"));
            }
        }

        public void getValues()
        {
            EntryOne e1 = new EntryOne();
            string heading = e1.returnHeading();
            string description = e1.returnDescription();


        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
