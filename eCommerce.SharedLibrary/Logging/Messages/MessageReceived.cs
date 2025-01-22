using Serilog;

namespace eCommerce.SharedLibrary.Logging.Messages;
public static class MessageReceived
{
    public static void LogMessage(string message)
    {
        Log.Information(message);
    }
}
