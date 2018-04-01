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

namespace TopixApp
{
    /// <summary>
    /// Interaction logic for UserProfile.xaml
    /// </summary>
    public partial class UserProfile : Page
    {
        private bool isLoggedInUser;

        // Will change parameters to accept a userID and reference to parent window (so we can change the current page and do other methods in main class)
        public UserProfile()
        {
            // Placeholder variables
            int profileID = 0;
            int userID = 0; // Will get current logged in userID from the parent window reference

            // Obtain information from database/server/data file using correlated userID

            InitializeComponent();

            // Change what the profile button displays and keep track if logged in user
            if(isLoggedInUser = profileID == userID)
                ProfileButton.Content = "Edit Profile";
            else
                ProfileButton.Content = "Follow";

            // Initialize all usercontrols
            UserTopixList.Content = new TopicListDisplay(new List<int>(){0,1,2,3,4,5,6}, null); // Use list of topicID's received from database info
            UserFriendList.Content = new UserListDisplay(new List<int>(){0,1,2,3,4,5,6,7,8,9,10,11,12}, null); // Use list of userID's received from database info
            UserEventList.Content = new EventListDisplay(new List<int>(){0,1,2,3,4}, 0, null); // Use list of eventID's received from database info
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
