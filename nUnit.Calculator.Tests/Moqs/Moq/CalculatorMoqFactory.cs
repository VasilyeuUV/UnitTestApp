using Calculator;
using Moq;

namespace nUnit.Calculator.Tests.Moqs.Moq;

/// <summary>
/// Фабрика создания Moq-объекта для калькулятора.
/// </summary>
static class CalculatorMoqFactory
{
    public static ICalc Order(decimal returnValue)
    {
        Mock<ICalc> mock = new();                                                   // - инициализация объекта иммитации (moq-объекта) на основе интерфейса ICalc

        // - Настройка moq-объекта:
        mock.Setup(m => m.Add(It.IsAny<decimal>(), It.IsAny<decimal>()))            // - если будет вызван метод Add с любыми значениями decimal для первого и второго аргументов
            .Returns(returnValue);                                                  // то вернуть значение, которое было передано в метод Order в качестве аргумента.
        mock.Setup(m => m.Subtract(It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns(returnValue);
        mock.Setup(m => m.Multiply(It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns(returnValue);
        mock.Setup(m => m.Divide(It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns(returnValue);
        mock.Setup(m => m.Divide(It.IsAny<decimal>(), 0))                           // - если второй аргумент метода Devide будет == 0,
            .Throws<DivideByZeroException>();                                       // то вернуть исключение DivideByZeroException

        return mock.Object;
    }

    public static ICalc Order()
    {
        Mock<ICalc> mock = new();
        mock.Setup(m => m.Add(2, 3))
            .Returns(5);
        mock.Setup(m => m.Subtract(4, 3))
            .Returns(1);
        mock.Setup(m => m.Multiply(2, 3))
            .Returns(6);
        mock.Setup(m => m.Divide(6, 3))
            .Returns(2);
        mock.Setup(m => m.Divide(6, 0))
            .Throws<DivideByZeroException>();
        return mock.Object;
    }
}
