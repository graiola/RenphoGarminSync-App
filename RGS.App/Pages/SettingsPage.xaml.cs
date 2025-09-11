namespace RGS.App.Pages;

public partial class SettingsPage : ContentPage
{
    public SettingsPage(ViewModels.SettingsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}

