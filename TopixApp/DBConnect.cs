using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TopixApp
{
    public class DBConnect
    {
        // Currently following https://www.codeproject.com/Articles/837599/Using-Csharp-to-connect-to-and-query-from-a-SQL-da for executing commands/etc
        SqlConnection connection;
        
        public DBConnect()
        {
            StartConnection();
        }

        public void StartConnection()
        {
            // Will need to change the Attach DbFilename to dynamically select the database security file in "..\TopixApp\TopixApp\"
            // John Connection String = Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\John\Desktop\TopixApp\TopixApp\TopixDatabase.mdf;Integrated Security=True
            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ben\source\repos\TopixDesktop\TopixApp\TopixDatabase.mdf;Integrated Security=True");
        }

        public void CloseConnection()
        {
            connection.Dispose();
        }

        public User GetUserInfo(int userID)
        {
            User user = new User();

            using(SqlCommand cmd = new SqlCommand("SELECT Id, FirstName, LastName, Bio FROM dbo.UserData WHERE Id = " + userID, connection))
            {
                connection.Open();
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            user.ID = reader.GetInt32(reader.GetOrdinal("Id"));
                            user.Firstname = reader.GetString(reader.GetOrdinal("FirstName"));

                            // Only recording index for nullable values to avoid calling GetOrdinal multiple times
                            // Normally will use GetOrdinal within reader.GetString(x), etc.
                            int lastNameIndex = reader.GetOrdinal("LastName");
                            int userBio = reader.GetOrdinal("Bio");
                            
                            // For nullable columns, check if null
                            if(!reader.IsDBNull(lastNameIndex))
                                user.Lastname = reader.GetString(lastNameIndex);
                            if (!reader.IsDBNull(userBio))
                                user.Bio = reader.GetString(userBio);
                        }
                    }
                }
                connection.Close();
            }

            return user;
        }

        public int LoginUser(string email, string password)
        {
            int userID = -1; // Default ID

            using(SqlCommand cmd = new SqlCommand("SELECT Id FROM dbo.LoginTable WHERE Email = '" + email + "' AND Password = '" + password + "'", connection))
            {
                connection.Open();
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        reader.Read(); // Read entry
                        userID = reader.GetInt32(reader.GetOrdinal("Id")); // Get data
                    }
                }
                connection.Close();
            }

            return userID;
        }
    }
}
