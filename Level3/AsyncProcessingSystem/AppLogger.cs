
using System;
using System.IO;

public class AppLogger
{
    private readonly string logFile = "application.log";

    public void LogInfo(string message)
    {
        WriteLog("INFO", message);
    }

    public void LogWarning(string message)
    {
        WriteLog("WARNING", message);
    }

    public void LogError(string message)
    {
        WriteLog("ERROR", message);
    }

    private void WriteLog(string level, string message)
    {
        string logMessage =
            $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";

        File.AppendAllText(
            logFile,
            logMessage + Environment.NewLine
        );

        Console.WriteLine(logMessage);
    }
}
