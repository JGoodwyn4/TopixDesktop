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
            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Syihan\Google Drive\West Virginia University\'17 - '18 Senior Year\CS 430 - Advanced Software Engineering\TopixDesktop\TopixApp\TopixDatabase.mdf;Integrated Security=True");
        }

        public void CloseConnection()
        {
            connection.Dispose();
        }

        public User GetUserInfo(int userID)
        {
            User user = new User();

            using(SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.UserData WHERE Id = " + userID, connection))
            {
                connection.Open();
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            user.firstName = reader.GetString(reader.GetOrdinal("FirstName"));

                            // Only recording index for nullable values to avoid calling GetOrdinal multiple times
                            // Normally will use GetOrdinal within reader.GetString(x), etc.
                            int lastNameIndex = reader.GetOrdinal("LastName");
                            int userBio = reader.GetOrdinal("Bio");
                            
                            // For nullable columns, check if null
                            if(!reader.IsDBNull(lastNameIndex))
                                user.lastName = reader.GetString(lastNameIndex);
                            if (!reader.IsDBNull(userBio))
                                user.bio = reader.GetString(userBio);
                        }
                    }
                }
                connection.Close();
            }

            return user;
        }
    }
}
