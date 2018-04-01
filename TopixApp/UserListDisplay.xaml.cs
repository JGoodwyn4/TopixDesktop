using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

namespace TopixApp
{
    /// <summary>
    /// Interaction logic for UserListDisplay.xaml
    /// </summary>
    public partial class UserListDisplay : UserControl
    {
        private MainWindow mainWindow;

        private struct UserInfo
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Image { get; set; } // Will probably want to change to a BitmapImage

            public UserInfo(int userID, string userName, string userImage)
            {
                ID = userID;
                Name = userName;
                Image = userImage;
            }
        };

        public UserListDisplay(List<int> userList, MainWindow mainWin)
        {
            // Save instance of the main window
            mainWindow = mainWin;

            InitializeComponent();

            // Load the user items into the ItemsControl
            UserDisplay.ItemsSource = LoadUserInfo(userList);
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            // Get userID from the tag assigned to the button
            int userID = (int)((System.Windows.Controls.Button)sender).Tag;

            // Set the main window display to the chosen user profile
            mainWindow.ContentDisplay.Content = new UserProfile();
        }

        private List<UserInfo> LoadUserInfo(List<int> userList)
        {
            List<UserInfo> info = new List<UserInfo>();

            foreach(int userID in userList)
            {
                // Get user info from database/server/etc


                // Add user info to list
                info.Add(new UserInfo(userID, "FirstName LastName", AppDomain.CurrentDomain.BaseDirectory + @"/Placeholder Images/profile.png"));
            }

            return info;
        }
    }
}
