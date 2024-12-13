namespace Calculator.Logger;

/// <summary>
/// Контракт логгера.
/// </summary>
public interface ILogger
{
    /// <summary>
    /// Залогировать сообщение.
    /// </summary>
    /// <param name="message"></param>
    void Log(string message);
}
