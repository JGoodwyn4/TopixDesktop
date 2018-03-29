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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TopixApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ContentDisplay.Content = new UserProfile();
        }

        private void OpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ToggleMenu("slideOut");
        }

        private void CloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ToggleMenu("slideIn");
        }

        private void ProfileNav_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HubNav_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TopixNav_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EventNav_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchNav_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MessageNav_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SettingsNav_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LogoutNav_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ToggleMenu(string sbType)
        {
            // Code based on http://www.codescratcher.com/wpf/sliding-panel-in-wpf/

            Storyboard sb = Resources[sbType] as Storyboard;
            sb.Begin(navBar);

            if(sbType.Equals("slideOut"))
            {
                OpenButton.Visibility = Visibility.Hidden;
                CloseButton.Visibility = Visibility.Visible;
            }
            else
            {
                OpenButton.Visibility = Visibility.Visible;
                CloseButton.Visibility = Visibility.Hidden;
            }
        }
    }
}
