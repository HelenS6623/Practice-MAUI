
using System.Diagnostics;

namespace Practice_MAUI
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            //Create instance of class
        }

        string _username = " ";
        string _password = " ";

        string[,] loginDetails = new string[1, 2];

        private void OnLoginClicked(object sender, EventArgs e)
        {
            ErrorLabel.Text = "";
            _username = UsernameInput.Text;
            _password = PasswordInput.Text;
            if (IsUserValid(_username) == true && IsPasswordValid(_password) == true)
            {
                loginDetails[0,0] = _username;
                loginDetails[0,1] = _password;
                LoginButton.Text = "Logged in";
            }
            else 
            {
                ErrorLabel.Text = "Error! Password or username empty or contains spaces.";
            }

        }

        private static bool IsUserValid(string username)
        {
            if (username != null)
            {
                if (username.Contains(" ") || username.Length < 5)
                {
                    return false;
                }

                else { return true; }
            }
             
            else { return false; }
        }

        private static bool IsPasswordValid(string password)
        {
            if (password != null)
            {
                if (password.Length > 15 || password.Length < 7 || password.Contains(" "))
                {
                    return false;

                }

                else
                {
                    return true;
                }
            }

            else { return false; }
        }
    }
}