namespace RGS.App.Services;

public interface ILogSink
{
    void Info(string message);
    void Error(string message);
}

public class MemoryLogSink : ILogSink
{
    readonly object _gate = new();
    public IReadOnlyList<string> Lines => _lines;
    private readonly List<string> _lines = new();

    public void Info(string message)  => Append($"[INFO] {DateTime.Now:t}  {message}");
    public void Error(string message) => Append($"[ERR ] {DateTime.Now:t}  {message}");

    private void Append(string line)
    {
        lock (_gate)
        {
            _lines.Add(line);
            if (_lines.Count > 500) _lines.RemoveAt(0);
        }
    }
}

