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
    /// Interaction logic for TopicListDisplay.xaml
    /// </summary>
    public partial class TopicListDisplay : UserControl
    {
        private MainWindow mainWindow;

        private struct TopicInfo
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Image { get; set; } // Will most likely want to change to a BitmapImage. Depends on how we read image info from server/etc.

            public TopicInfo(int topicID, string topicName, string topicImage)
            {
                ID = topicID;
                Name = topicName;
                Image = topicImage;
            }
        };

        public TopicListDisplay(List<int> topicList, MainWindow mainWin)
        {
            // Save instance of the main window
            mainWindow = mainWin;

            InitializeComponent();

            // Load the user items into the ItemsControl
            TopicDisplay.ItemsSource = LoadTopicInfo(topicList);
        }

        private void TopicButton_Click(object sender, RoutedEventArgs e)
        {
            // Get userID from the tag assigned to the button
            int topicID = (int)((System.Windows.Controls.Button)sender).Tag;

            // Set the main window display to the chosen user profile
            mainWindow.ContentDisplay.Content = new TopicProfile();
        }

        private List<TopicInfo> LoadTopicInfo(List<int> topicList)
        {
            List<TopicInfo> info = new List<TopicInfo>();

            foreach(int topicID in topicList)
            {
                // Get topic info from database/server/etc


                // Add topic info to list
                info.Add(new TopicInfo(topicID, "Topic Name", @"/Placeholder Images/profile.png"));
            }

            return info;
        }
    }
}
