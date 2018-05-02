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

namespace TopixApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private DBConnect dbConnect;
        private int userID;

        public LoginWindow(DBConnect database)
        {
            dbConnect = database;
            userID = -1;

            InitializeComponent();
        }

        private void NewAccountButton_Click(object sender, RoutedEventArgs e)
        {
            // Open a new account window


            // If the create account window returns true, get the userID created from the database
            if(true)
            {
                // Will get these values from the create account window, I just put these here so I can have the structure down
                string email = "";
                string password = "";

                userID = dbConnect.LoginUser(email,password);
                this.DialogResult = true; // Set the login result to be true
                this.Close(); // Automatically close the login window
            }
            
            // Otherwise, don't do anything
            
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Check for username/email and password in database/files/etc.
            // Call method in DBConnect that looks at login table and attempts to get the user ID given the email and password
            int dbUserID = dbConnect.LoginUser(EmailInput.Text, PasswordInput.Text);
            
            
            if(dbUserID != -1)
            {
                userID = dbUserID; // Set the login user ID to the ID we just read from the database
                this.DialogResult = true; // Set result of window to be true
                this.Close(); // Automatically close the login window
            }
            else
            {
                // Display or state a warning to user
                MessageBox.Show("One of the credentials are incorrect","Login Denied",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        public int GetID()
        {
            return userID;
        }
    }
}
