using CommunityToolkit.Mvvm.ComponentModel;
using RGS.App.Services;
using System.Text;

namespace RGS.App.ViewModels;

public partial class LogsViewModel : ObservableObject
{
    private readonly ILogSink _log;
    [ObservableProperty] private string _logText = "";

    public LogsViewModel(ILogSink log)
    {
        _log = log;
        if (log is MemoryLogSink mem)
        {
            var sb = new StringBuilder();
            foreach (var line in mem.Lines) sb.AppendLine(line);
            LogText = sb.ToString();
        }
    }
}

