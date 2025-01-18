using Serilog;

namespace eCommerce.SharedLibrary.Logging.Exceptions;
public static class LogException
{
    public static void LogExceptions(Exception ex)
    {
        LogToFile(ex.Message);
        LogToConsole(ex.Message);
        LogToDebugger(ex.Message);
    }

    public static void LogToFile(string message) => Log.Information(message);
    public static void LogToConsole(string message) => Log.Warning(message);
    public static void LogToDebugger(string message) => Log.Debug(message);

}
