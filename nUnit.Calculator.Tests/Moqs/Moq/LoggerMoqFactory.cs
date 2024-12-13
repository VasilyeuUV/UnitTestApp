using Calculator.Logger;
using Moq;

namespace nUnit.Calculator.Tests.Moqs.Moq;

/// <summary>
/// Фабрика создания Moq-объекта для логгера.
/// </summary>
internal static class LoggerMoqFactory
{
    public static ILogger Order()
    {
        Mock<ILogger> mock = new();                             // - инициализация moq-объекта логгера.

        // Настройка moq-объекта
        mock.Setup(m => m.Log(It.IsAny<string>()))              // - метод, принимающий любую строку
            .Verifiable();                                      // - т.к. метод возвращает void, то тут только проверяем, что данный метод был вызван

        return mock.Object;
    }
}
