using System;

public class ConsoleLogger : ILogger
{
    public void LogInfo(string message) => WriteMessage("INFO", message);

    public void LogWarning(string message) => WriteMessage("WARNING", message);

    public void LogError(string message) => WriteMessage("ERROR", message);

    public void LogDebug(string message) => WriteMessage("DEBUG", message);

    public void LogCritical(string message) => WriteMessage("CRITICAL", message);

    private void WriteMessage(string level, string message)
    {
        Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}");
    }
}
