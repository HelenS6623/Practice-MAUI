


using Microsoft.Data.Sqlite;

namespace Practice_MAUI.Views;

public partial class SignUp : ContentPage
{
    public SignUp()
    {
        InitializeComponent();
    }

    string _username = " ";
    string _password = " ";
    List<string> _errorMessages = new List<string> { "Username or password empty",
        "Username or password cannot contain spaces", "Username must be longer than 5 characters",
        "Password must be at least 7 characters", "Unknown characters in username or password" };
    int _errorCode = 10;
    string[] _bannedChars = [";", ";", "(", ")", "=", "#"];
    int _errorCodeChars = 0;



    private void OnDoneClicked(object sender, EventArgs e)
    {
        string connectionStringMade = DataBase.ConnectionStringer();

        DataBase.CreateTable(connectionStringMade);

        ErrorLabelSignUp.Text = "";
        _username = UsernameInput.Text;
        _password = PasswordInput.Text;

        if (IsUserValid(_username) && IsPasswordValid(_password))
        {
            DataBase.InsertUser(connectionStringMade, _username, _password);
            ErrorLabelSignUp.Text = "Account created. Please return to login screen to login.";
        }

        else
        {
            if (_errorMessages != null && _errorMessages.Count > 0)
            {
                if (_errorCode != 10)
                { ErrorLabelSignUp.Text = _errorMessages[_errorCode]; }

            }
            else
            { ErrorLabelSignUp.Text = "Not accepted"; }
        }

    }

    private bool IsUserValid(string username)
    {
        if (username != null)
        {
            if (username.Length < 5)
            {
                _errorCode = 2;
                return false;
            }

            else if (username.Length == 0)
            { _errorCode = 0; return false; }

            else if (username.Contains(" "))
            {
                _errorCode = 1;
                return false;
            }

            else
            {
                for (int i = 0; i < _bannedChars.Length; i++)
                {
                    if (username.Contains(_bannedChars[i]))
                    { _errorCodeChars += 1; }

                }

                if (_errorCodeChars > 0)
                {
                    _errorCode = 4;
                    return false;
                }

                else { return true; }
            }
        }

        else
        {
            _errorCode = 0;
            return false;
        }
    }

    private bool IsPasswordValid(string password)
    {
        if (password != null)
        {
            if (password.Contains(" "))
            {
                _errorCode = 1;
                return false;

            }

            else if (password.Length < 7)
            {
                _errorCode = 3;
                return false;
            }

            else if (password.Length == 0)
            {
                _errorCode = 0;
                return false;
            }

            else
            {
                for (int i = 0; i < _bannedChars.Length; i++)
                {
                    if (password.Contains(_bannedChars[i]))
                    { _errorCodeChars += 1; }

                }

                if (_errorCodeChars > 0)
                {
                    _errorCode = 4;
                    return false;
                }

                else { return true; }
            }
        }

        else
        {
            _errorCode = 0;
            return false;
        }
    }
}
