namespace RGS.App;

public partial class App : Application
{
    public App(Pages.HomePage home)
    {
        InitializeComponent();
        MainPage = new NavigationPage(home);
    }
}

