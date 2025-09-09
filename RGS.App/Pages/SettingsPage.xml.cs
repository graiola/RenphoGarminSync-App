using RGS.App.ViewModels;

namespace RGS.App.Pages;
public partial class SettingsPage : ContentPage
{
    public SettingsPage(SettingsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}

