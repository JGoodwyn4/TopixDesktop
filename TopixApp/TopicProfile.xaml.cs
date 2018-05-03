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
    /// Interaction logic for TopicProfile.xaml
    /// </summary>
    public partial class TopicProfile : Page
    {
        private MainWindow mainWindow;
        private int userID;
        private int topicID;
        private List<User> followers;
        //private List<Event> events;

        public TopicProfile(int tID, MainWindow mainWin)
        {
            mainWindow = mainWin;
            userID = mainWindow.GetCurrentUserID();
            topicID = tID;

            InitializeComponent();

            TopicName.Content = "Topic #" + topicID;

            TopicFollowerList.Content = new UserListDisplay(new List<int>(){0,1,2}, mainWindow); // Use list of userID's received from database info
            TopicEventList.Content = new EventListDisplay(new List<int>(){0,1,2,3,4}, userID, mainWindow); // Use list of eventID's received from database info
        }

        private void TopicButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
