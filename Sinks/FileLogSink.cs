using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class FileLogSink : ILogSink
{
    private readonly string _logFilePath;

    public FileLogSink(string logFilePath)
    {
        _logFilePath = logFilePath;
    }

    public void WriteLog(string level, string message, Dictionary<string, object> properties)
    {
        var formattedProperties = properties != null
            ? string.Join(", ", properties.Select(p => $"{p.Key}={p.Value}"))
            : string.Empty;

        var logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message} {formattedProperties}";

        File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
    }
}
