namespace Practice_MAUI.Views;

public partial class LogIn : ContentPage
{
	public LogIn()
	{
		InitializeComponent();

        string connectionString = DataBase.ConnectionStringer();
        DataBase.CreateTable(connectionString);

    }

    string _username = " ";
    string _password = " ";
    string _errorMessageText;

    string[,] loginDetails = new string[5, 2];

    

    private void OnLoginClicked(object sender, EventArgs e)
    {
        ErrorLabel.Text = "";
        _username = UsernameInput.Text;
        _password = PasswordInput.Text;
        if (IsLoginValid("bob", _username, _password) == true)
        {
            LoginButton.Text = "Logged in";
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
            if (DataBase.UserExists(connectionString, username) == false) { return true; }
            else
            {
                _errorMessageText = "User already exists";
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