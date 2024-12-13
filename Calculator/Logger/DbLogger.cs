
namespace Calculator.Logger;

/// <summary>
/// Класс для сохранения логов в БД.
/// </summary>
public class DbLogger : ILogger
{
    public void Log(string message)
        => LogMessageToDb(message);


    private void LogMessageToDb(string message)
    {
        throw new Exception("No connection could me made to a database");
    }
}
