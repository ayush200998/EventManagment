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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void prevButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void switchButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
