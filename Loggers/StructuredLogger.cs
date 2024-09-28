using System.Collections.Generic;

public class StructuredLoggerWithSink : ILogger
{
    private readonly List<ILogSink> _logSinks;

    public StructuredLoggerWithSink(IEnumerable<ILogSink> logSinks)
    {
        _logSinks = new List<ILogSink>(logSinks);
    }

    public void LogInfo(string message, Dictionary<string, object> properties = null) =>
        WriteMessage("INFO", message, properties);

    public void LogWarning(string message, Dictionary<string, object> properties = null) =>
        WriteMessage("WARNING", message, properties);

    public void LogError(string message, Dictionary<string, object> properties = null) =>
        WriteMessage("ERROR", message, properties);

    public void LogDebug(string message, Dictionary<string, object> properties = null) =>
        WriteMessage("DEBUG", message, properties);

    public void LogCritical(string message, Dictionary<string, object> properties = null) =>
        WriteMessage("CRITICAL", message, properties);

    private void WriteMessage(string level, string message, Dictionary<string, object> properties = null)
    {
        foreach (var sink in _logSinks)
        {
            sink.WriteLog(level, message, properties);
        }
    }
}
