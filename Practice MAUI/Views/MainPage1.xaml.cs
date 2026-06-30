namespace Practice_MAUI.Views;

public partial class MainPage1 : ContentPage
{
	public MainPage1()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(MainPage1), typeof(MainPage1));
	}
}