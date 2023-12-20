using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities
{
    internal class User
    {
        int userID;
        string username;
        string email;
        string password;
        long contactnumber;
        string address;
        public int UserID { get { return userID; } set { userID = value; } }
        public string Name { get { return username; } set { username = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Password { get { return password; } set { password = value; } }
        public long ContactNumber { get { return contactnumber; } set { contactnumber = value; } }
        public string Address { get { return address; } set { address = value; } }
        public User(int userID, string username, string email, string password, long contactnumber, string address)
        {
            UserID = userID;
            Name = username;
            Email = email;
            Password = password;
            ContactNumber = contactnumber;
            Address = address;

        }
    }
}

