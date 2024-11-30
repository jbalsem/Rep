using CSC317PassManagerP2Starter.Modules.Controllers;
using CSC317PassManagerP2Starter.Modules.Models;

namespace CSC317PassManagerP2Starter.Modules.Views;

public partial class LoginView : ContentPage
{
    private LoginController loginController; // This is the class that checks the login details.

    public LoginView()
    {
        InitializeComponent();
        loginController = new LoginController(); // Create the login controller when the page loads.
    }

    private void ProcessLogin(object sender, EventArgs e)
    {
        //Complete Process Login Functionality.  Called by Submit Button
        // Step 1: Get the username and password entered by the user.
        string username = txtUserName.Text; 
        string password = txtPassword.Text; 
        // Step 2: Check if the username or password is empty.
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            ShowErrorMessage("Please enter both username and password."); // Show an error if either field is empty.
            return; 
        }

        // Step 3: Ask the LoginController to check the username and password.
        AuthenticationError authError = loginController.Authenticate(username, password);

        // Step 4: Handle the result of the login attempt.
        if (authError == AuthenticationError.NONE)
        {
            // Login successful! Hide any error message and go to the next page.
            lblError.IsVisible = false; // Make sure the error label is hidden.
            User authenticatedUser = loginController.CurrentUser;
            Navigation.PushAsync(new PasswordListView(authenticatedUser)); // Go to the next page.
        }
        else if (authError == AuthenticationError.INVALIDUSERNAME)
        {
            ShowErrorMessage("The username you entered does not exist."); // Tell the user the username is wrong.
        }
        else if (authError == AuthenticationError.INVALIDPASSWORD)
        {
            ShowErrorMessage("The password you entered is incorrect."); // Tell the user the password is wrong.
        }
    
    }

    private void ShowErrorMessage(string message)
    {
        
        lblError.Text = message; 
        lblError.IsVisible = true;
    }

}