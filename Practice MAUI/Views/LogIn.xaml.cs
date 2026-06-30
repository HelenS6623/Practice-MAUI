namespace Practice_MAUI.Views;

public partial class LogIn : ContentPage
{
	public LogIn()
	{
		InitializeComponent();

        string _connectionStringMade = DataBase.ConnectionStringer();
        DataBase.CreateTable(_connectionStringMade);

    }

    string _username = " ";
    string _password = " ";
    string _errorMessageText;

    string[,] loginDetails = new string[5, 2];

    

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string _connectionStringMade = DataBase.ConnectionStringer();
        ErrorLabel.Text = "";
        _username = UsernameInput.Text;
        _password = PasswordInput.Text;
        if (IsLoginValid(_connectionStringMade, _username, _password) == true)
        {
            LoginButton.Text = "Logged in";
            await Shell.Current.GoToAsync(nameof(Views.MainPage1));
        }
        else
        {
            ErrorLabel.Text = _errorMessageText;
        }

    }

    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        SignUpButton.Text = "Clicked";
        await Shell.Current.GoToAsync(nameof(Views.SignUp));
    }

    private  bool IsLoginValid(string connectionString, string username, string password)
    {
        if (username != null)
        {
            if (DataBase.UserExists(connectionString, username) == true)
            { 
                if (DataBase.PasswordCorrect(connectionString, username, password))
                { return true; }
                else { _errorMessageText = "User not found. Please check your details."; return false; }
            }
            else
            {
                _errorMessageText = "User not found. Please check your details.";
                return false;
            }
        }

        else
        {
            _errorMessageText = "No username or password entered";
            return false;
        }
    }

    
    }