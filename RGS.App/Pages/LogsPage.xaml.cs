using RGS.App.ViewModels;

namespace RGS.App.Pages;
public partial class LogsPage : ContentPage
{
    public LogsPage(LogsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}

