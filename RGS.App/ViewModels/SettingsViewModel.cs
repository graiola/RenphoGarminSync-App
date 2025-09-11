using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RGS.App.ViewModels;

public partial class SettingsViewModel : ObservableObject
{
    [ObservableProperty] private string _sinceDays = "30";

    [RelayCommand]
    private Task Save() => Shell.Current.DisplayAlert("Saved", $"Sync since last {SinceDays} days", "OK");
}

