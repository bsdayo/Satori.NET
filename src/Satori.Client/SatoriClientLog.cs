namespace Satori.Client;

public class SatoriClientLog
{
    public DateTime LogTime { get; }

    public LogLevel LogLevel { get; }

    public string Message { get; }

    public Exception? Exception { get; }

    public SatoriClientLog(LogLevel logLevel, string message)
    {
        LogTime = DateTime.Now;
        LogLevel = logLevel;
        Message = message;
    }

    public SatoriClientLog(Exception e)
    {
        LogTime = DateTime.Now;
        Exception = e;
        LogLevel = LogLevel.Error;
        Message = e.Message;
    }
}