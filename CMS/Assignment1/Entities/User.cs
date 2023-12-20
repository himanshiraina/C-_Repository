using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities
{
    internal class User
    {
       private static int nextuserID = 1;

        int userID;
        string userName;
        string email;
        string password;
        long contactNumber;
        string address;

        // Default constructor
        public User()
        {
            userID = GenerateUserID();
        }

        // Parameterized constructor
        public User(string userName, string email, string password, long contactNumber, string address)
        {
            userID = GenerateUserID();
            this.userName = userName;
            this.email = email;
            this.password = password;
            this.contactNumber = contactNumber;
            this.address = address;
        }

// Getters and Setters
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public long ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        // Method to generate auto-incremented UserID
        private int GenerateUserID()
        {
            return nextuserID++;
        }

        // ToString method to represent object as a string
        public override string ToString()
        {
            return $"UserID: {userID}, UserName: {userName}, Email: {email}, ContactNumber: {contactNumber}, Address: {address}";
        }
    }
}

