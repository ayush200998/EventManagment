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
