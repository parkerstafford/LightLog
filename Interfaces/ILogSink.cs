using System.Collections.Generic;

public interface ILogSink
{
    void WriteLog(string level, string message, Dictionary<string, object> properties);
}
