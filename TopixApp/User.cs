using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopixApp
{
    public class User
    {
        // Set up all data contained in a user object
        public string firstName { get; set; }
        public string lastName { get; set; }
        //public string location{ get; set; }
        //public List<int> friendList { get; set; }
        //public List<int> topicList { get; set; }
        //public List<int> eventList { get; set; }

        public User()
        {
            // Initialize all values to empty/default
            firstName = string.Empty;
            lastName = string.Empty;
        }

        public string GetFullName()
        {
            if(lastName == string.Empty)
                return firstName;

            else
                return firstName + " " + lastName;
        }
    }
}
