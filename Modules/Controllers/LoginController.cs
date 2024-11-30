using CSC317PassManagerP2Starter.Modules.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC317PassManagerP2Starter.Modules.Controllers
{
    public enum AuthenticationError { NONE, INVALIDUSERNAME, INVALIDPASSWORD }
    public class LoginController
    {
        private string testUsername = "test"; // Username
        private string testPassword = "ab1234"; // Password

        /*
         * This class is incomplete.  Fill in the method definitions below.
         */
        private User _user = new User
        {
            FirstName = "John",
            LastName = "Doe"
        };        
        private bool _loggedIn = false;

        public User? CurrentUser
        {
            get
            {
                // If the user is logged in, return a copy of the user data
                return _loggedIn ? _user : null;
            }
        }

        public AuthenticationError Authenticate(string username, string password)
        {
            if (username != testUsername)
            {
                return AuthenticationError.INVALIDUSERNAME; // Invalid username
            }
            // Check if the entered password matches the test password
            if (password != testPassword)
            {
                return AuthenticationError.INVALIDPASSWORD; // Invalid password
            }

            // If both username and password are correct, mark the user as logged in
            _loggedIn = true;
            return AuthenticationError.NONE; // Successful login
        }

        
    }

}
