namespace Practice_MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Views.SignUp), typeof(Views.SignUp));
            Routing.RegisterRoute(nameof(Views.LogIn), typeof(Views.LogIn));
            Routing.RegisterRoute(nameof(Views.MainPage1), typeof(Views.MainPage1));
        }
    }
}
