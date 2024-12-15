using Calculator;
using Calculator.Logger;
using nUnit.Calculator.Tests.Moqs.Moq;

namespace nUnit.Calculator.Tests;


/// <summary>
/// Тесты с использованием библиотеки Moq.
/// </summary>
public class CalcNUnitTests_Moq
{
    private ICalc _testingObject;                                       // - тестируемый объект

    private ICalc _calculator;                                          // - Moq-объект, необходимый для инициализации калькулятора, но не влияет на работу тестируемого класса
    private ILogger _logger;                                            // - Moq-объект, необходимый для инициализации логгера, но не влияет на работу тестируемого класса




    [SetUp]
    public void Setup()
    {
        _calculator = CalculatorMoqFactory.Order();                     // - создание Moq-объекта для инициализации калькулятора. Не влияет на работу тестируемого класса
        _logger = LoggerMoqFactory.Order();                             // - создание Moq-объекта для инициализации логгера. Не влияет на работу тестируемого класса

        _testingObject = new CalcLogger(_logger, _calculator);          // - создание объекта для тестов. Тестовый класс зависит от сторонних объектов.
                                                                        // Вместо инициализации сторонних объектов, используем Moq-объекты.
    }




    [TestCase(2, 3, 5)]                                                 // - ПАРАМЕТРИЗИРОВАННЫЙ MOQ-ТЕСТ
    public void Add_TestCaseArgs_ReturnTestCaseMoqResult(
        decimal a,
        decimal b,
        decimal expected)
    {
        decimal result = _testingObject.Add(a, b);
        Assert.That(result, Is.EqualTo(expected));

    }

    [TestCase(4, 3, 1)]
    public void Substract_TestCaseArgs_ReturnTestCaseMoqResult(
        decimal a,
        decimal b,
        decimal expected)
    {
        decimal result = _testingObject.Subtract(a, b);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(2, 3, 6)]
    public void Multiply_TestCaseArgs_ReturnTestCaseMoqResult(
        decimal a,
        decimal b,
        decimal expected
        )
    {
        decimal result = _testingObject.Multiply(a, b);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(6, 3, 2)]
    public void Divide_TestCaseArgs_ReturnTestCaseMoqResult(
        decimal a,
        decimal b,
        decimal expected
        )
    {
        decimal result = _testingObject.Divide(a, b);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(6, 0)]
    public void Divide_TestCaseArgsOnZero_ReturnDevideByZeroException(decimal a, decimal b)
        => Assert.Throws<DivideByZeroException>(() => { _testingObject.Divide(a, b); });
}
