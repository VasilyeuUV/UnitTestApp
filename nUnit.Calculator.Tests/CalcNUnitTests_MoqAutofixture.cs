using AutoFixture;
using Calculator;
using Calculator.Logger;
using nUnit.Calculator.Tests.Moqs.Moq;

namespace nUnit.Calculator.Tests;

/// <summary>
/// Тесты с использованием библиотеки Moq.
/// </summary>
public class CalcNUnitTests_MoqAutofixture
{
    private static Fixture _fixture = new();                            // - инициализация объекта Autofixture, который будет генерировать данные.

    private ICalc _testingObject;                                       // - тестируемый объект

    private ICalc _calculator;                                          // - Moq-объект, необходимый для инициализации калькулятора, но не влияет на работу тестируемого класса
    private ILogger _logger;                                            // - Moq-объект, необходимый для инициализации логгера, но не влияет на работу тестируемого класса

    private decimal _returnValue;


    [SetUp]
    public void Setup()
    {
        _returnValue = _fixture.Create<decimal>();                      // - генерация возвращаемого значения

        _calculator = CalculatorMoqFactory.Order(_returnValue);         // - создание Moq-объекта для инициализации калькулятора. Не влияет на работу тестируемого класса
        _logger = LoggerMoqFactory.Order();                             // - создание Moq-объекта для инициализации логгера. Не влияет на работу тестируемого класса

        _testingObject = new CalcLogger(_logger, _calculator);          // - создание объекта для тестов. Тестовый класс зависит от сторонних объектов.
                                                                        // Вместо инициализации сторонних объектов, используем Moq-объекты.
    }





    /// <summary>
    /// Тест метода Add с валидными аргументами, возвращающего корректный результат
    /// </summary>
    [Test]                                                          // - атрибут, обозначающий, что отмеченный метод - НЕПАРАМЕТРИЗИРОВАННЫЙ тестовый
    public void Add_AutofixureArgs_ReturnCorrectResult()
    {
        // Act
        decimal result = _testingObject.Add(2, 3);

        // Assert
        Assert.That(result, Is.EqualTo(_returnValue));              // - результат всегда == _returnValue !!!
    }


    /// <summary>
    /// Тест метода Substract с валидными аргументами, возвращающего корректный результат
    /// </summary>
    [Test]
    public void Substract_AutofixureArgs_ReturnCorrectResult()
    {
        decimal result = _testingObject.Subtract(2, 3);
        Assert.That(result, Is.EqualTo(_returnValue));
    }


    /// <summary>
    /// Тест метода Multiply с валидными аргументами, возвращающего корректный результат
    /// </summary>
    [Test]
    public void Multiply_AutofixureArgs_ReturnCorrectResult()
    {
        decimal result = _testingObject.Multiply(2, 3);
        Assert.That(result, Is.EqualTo(_returnValue));
    }


    /// <summary>
    /// Тест метода Divide с валидными аргументами, возвращающего корректный результат
    /// </summary>
    [Test]
    public void Divide_AutofixureArgs_ReturnCorrectResult()
    {
        decimal result = _testingObject.Divide(2, 3);
        Assert.That(result, Is.EqualTo(_returnValue));
    }


    /// <summary>
    /// Тест метода Divide при делении на 0, возвращающего исключение DevideByZeroException
    /// </summary>
    [Test]
    public void Divide_AutofixureArgs_ReturnDevideByZeroException()
        => Assert.Throws<DivideByZeroException>(() => _testingObject.Divide(2, 0));
}
