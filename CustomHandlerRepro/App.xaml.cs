namespace CustomHandlerRepro;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new ContentPage
		{
			Content = new MyView(),
		});
	}
}

