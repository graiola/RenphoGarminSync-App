using RGS.App.ViewModels;

namespace RGS.App.Pages;

public partial class HomePage : ContentPage
{
    public HomePage(HomeViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}

