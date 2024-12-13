using Calculator;
using Calculator.Logger;
using nUnit.Calculator.Tests.Moqs.Own;

namespace nUnit.Calculator.Tests;


/// <summary>
/// Тесты с использованием собственных (пользовательских) объектов Moq (не очень хороший вариант).
/// </summary>
public class CalcNUnitTests_MoqOwn
{
    private ICalc _testingObject;                                       // - тестируемый объект

    private ICalc _calculator;
    private ILogger _logger;



    [SetUp]
    public void Setup()
    {
        _calculator = new CalculatorOwnMoq();                           // - Moq-объект, необходимый для инициализации калькулятора, но не влияет на работу тестируемого класса
        _logger = new LoggerOwnMock();                                  // - Moq-объект, необходимый для инициализации логгера, но не влияет на работу тестируемого класса

        _testingObject = new CalcLogger(_logger, _calculator);          // - тестовый класс зависит от сторонних объектов.
                                                                        // Вместо инициализации сторонних объектов, используем пользовательские Moq-объекты.
                                                                        // Недостаток - проверку осуществлять с учетом значений, возвращаемых соответствующим Moq-объектом.
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
        Assert.That(result, Is.EqualTo(0));                         // - результат всегда == 0 (возвращаемому значению из Moq-объекта калькулятора)   !!!
    }


    /// <summary>
    /// Тест метода Substract с валидными аргументами, возвращающего корректный результат
    /// </summary>
    [Test]
    public void Substract_AutofixureArgs_ReturnCorrectResult()
    {
        decimal result = _testingObject.Subtract(2, 3);
        Assert.That(result, Is.EqualTo(0));
    }


    /// <summary>
    /// Тест метода Multiply с валидными аргументами, возвращающего корректный результат
    /// </summary>
    [Test]
    public void Multiply_AutofixureArgs_ReturnCorrectResult()
    {
        decimal result = _testingObject.Multiply(2, 3);
        Assert.That(result, Is.EqualTo(0));
    }


    /// <summary>
    /// Тест метода Divide с валидными аргументами, возвращающего корректный результат
    /// </summary>
    [Test]
    public void Divide_AutofixureArgs_ReturnCorrectResult()
    {
        decimal result = _testingObject.Divide(2, 3);
        Assert.That(result, Is.EqualTo(0));
    }


    /// <summary>
    /// Тест метода Divide при делении на 0, возвращающего исключение DevideByZeroException
    /// </summary>
    [Test]
    public void Divide_AutofixureArgs_ReturnDevideByZeroException()
        => Assert.Throws<DivideByZeroException>(() => _testingObject.Divide(2, 0));
}
