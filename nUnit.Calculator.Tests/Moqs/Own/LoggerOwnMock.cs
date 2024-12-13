using Calculator.Logger;

namespace nUnit.Calculator.Tests.Moqs.Own;


/// <summary>
/// Пользовательский Moq логгера
/// </summary>
public class LoggerOwnMock : ILogger
{
    public void Log(string message)
    {
        return;
    }
}
