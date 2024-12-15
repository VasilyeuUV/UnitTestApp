//using NUnit.Framework;                                            // - пространство имен mUnit-теста
using Calculator;

namespace nUnit.Calculator.Tests;

/// <summary>
/// Класс тестирования класса Calc средствами библиотеки nUnit
/// </summary>
[Explicit]
public class CalcNUnitTests
{
    private ICalc _testingObject;                                       // - объект, который будет тестироваться (ДОЛЖЕН БЫТЬ ОДИН!!! Нельзя в одном классе тестировать несколько объектов)


    //#################################################################################################
    // ИСТОЧНИКИ ДЛЯ АТРИБУТОВ [TestCaseSource(nameof(Источник))]

    /// <summary>
    /// Тестовые данные для метода сложения. Вариант 1 тестовых данных
    /// </summary>
    private static readonly object[] _addCases = [
        new object[] { 2m, 3m, 5m },
        new object[] { 3m, 4m, 7m },
        new object[] { 4m, 5m, 9m },
        ];

    private static readonly object[] _multiplyCases = [
        new object[] { 2m, 3m, 6m },
        new object[] { -3m, 4m, -12m },
        new object[] { -5m, -4m, 20m },
        ];

    private static readonly object[] _divideCases = [
        new object[] { 3m, 2m, 1.5m },
        new object[] { -3m, 4m, -0.75m },
        new object[] { -5m, -4m, 1.25m },
        ];

    private static readonly object[] _divideByZeroCases = [
        new object[] { 2m, 0m },
        new object[] { -3m, 0m },
        new object[] { -5m, 0m },
        ];


    /// <summary>
    /// Тестовые данные для метода вычитания. Вариант 2 тестовых данных
    /// </summary>
    private static IEnumerable<TestCaseData> SubstractCases
    {
        get
        {
            yield return new TestCaseData(2m, 3m, -1m);
            yield return new TestCaseData(3m, 4m, -1m);
            yield return new TestCaseData(5m, 4m, 1m);
        }
    }



    //#################################################################################################
    // САМИ ТЕСТЫ

    /// <summary>
    /// Определение исходных данных.
    /// </summary>
    [OneTimeSetUp]                                                  // - атрибут исходных данных. Метод выполнится один раз.
    //[SetUp]                                                         // - атрибут исходных данных. Метод, отмеченный им, запускается перед каждым тестовым методом 
    public void Setup()                                             // - исходные данные для тестов (Arrange)
    {
        _testingObject = new Calc();
    }



    /// <summary>
    /// Тест метода Add с валидными аргументами, возвращающего корректный результат
    /// </summary>
    [Test]                                                          // - атрибут, обозначающий, что отмеченный метод - НЕПАРАМЕТРИЗИРОВАННЫЙ тестовый
    public void Add_OnValidSimpleArgs_ReturnCorrectResult()
    {
        // Act
        decimal result = _testingObject.Add(2, 3);

        // Assert
        Assert.That(result, Is.EqualTo(5));                         // вариант 1 проверки равенства
        Assert.That(result == 5);                                   // вариант 2 проверки равенства
    }

    /// <summary>
    /// Параметризированный Тест метода Add 
    /// </summary>
    [TestCase(2, 3, 5)]                                             // - атрибут, обозначающий, что отмеченный метод - ПАРАМЕТРИЗИРОВАННЫЙ тестовый
    [TestCase(3, 4, 7)]
    [TestCase(4, 5, 9, TestName = "Add_WithChange_TestName")]       // - можно изменить название теста
    public void Add_TestCaseArgs_ReturnTestCaseResult(decimal a, decimal b, decimal res)
    {
        decimal result = _testingObject.Add(a, b);
        Assert.That(result, Is.EqualTo(res));
    }

    /// <summary>
    /// Параметризированный Тест метода Add с указанием источника параметров
    /// </summary>
    [TestCaseSource(nameof(_addCases))]                              // - атрибут, обозначающий, что отмеченный метод - ПАРАМЕТРИЗИРОВАННЫЙ тестовый. В качестве источника параметров - имя указанного объекта
    public void Add_ArgsFromSource_ReturnCorrectResult(decimal a, decimal b, decimal res)
    {
        decimal result = _testingObject.Add(a, b);
        Assert.That(result, Is.EqualTo(res));
    }




    /// <summary>
    /// Тест метода Substract с валидными аргументами, возвращающего корректный результат
    /// </summary>
    [Test]
    public void Substract_OnValidSimpleArgs_ReturnCorrectResult()
    {
        decimal result = _testingObject.Subtract(2, 3);
        Assert.That(result, Is.EqualTo(-1));
    }

    /// <summary>
    /// Параметризированный Тест метода Substract
    /// </summary>
    [TestCase(2, 3, -1)]
    [TestCase(3, 4, -1)]
    [TestCase(5, 4, 1)]
    public void Substract_TestCaseArgs_ReturnTestCaseResult(decimal a, decimal b, decimal res)
    {
        decimal result = _testingObject.Subtract(a, b);
        Assert.That(result, Is.EqualTo(res));
    }

    /// <summary>
    /// Параметризированный Тест метода Substract с указанием источника параметров
    /// </summary>
    [TestCaseSource(nameof(SubstractCases))]
    public void Substract_ArgsFromSource_ReturnCorrectResult(decimal a, decimal b, decimal res)
    {
        decimal result = _testingObject.Subtract(a, b);
        Assert.That(result, Is.EqualTo(res));
    }





    /// <summary>
    /// Тест метода Multiply с валидными аргументами, возвращающего корректный результат
    /// </summary>
    [Test]
    public void Multiply_OnValidSimpleArgs_ReturnCorrectResult()
    {
        decimal result = _testingObject.Multiply(2, 3);
        Assert.That(result, Is.EqualTo(6));
    }

    /// <summary>
    /// Параметризированный Тест метода Multiply
    /// </summary>
    [TestCase(2, 3, 6)]
    [TestCase(-3, 4, -12)]
    [TestCase(-5, -4, 20)]
    public void Multiply_TestCaseArgs_ReturnTestCaseResult(decimal a, decimal b, decimal res)
    {
        decimal result = _testingObject.Multiply(a, b);
        Assert.That(result, Is.EqualTo(res));
    }

    /// <summary>
    /// Параметризированный Тест метода Multiply с указанием источника параметров
    /// </summary>
    [TestCaseSource(nameof(_multiplyCases))]
    public void Multiply_ArgsFromSource_ReturnCorrectResult(decimal a, decimal b, decimal res)
    {
        decimal result = _testingObject.Multiply(a, b);
        Assert.That(result, Is.EqualTo(res));
    }




    /// <summary>
    /// Тест метода Divide с валидными аргументами, возвращающего корректный результат
    /// </summary>
    [Test]
    public void Divide_OnValidSimpleArgs_ReturnCorrectResult()
    {
        decimal result = _testingObject.Divide(2, 3);
        Assert.That(result, Is.EqualTo(0.6666666666666667));
    }

    /// <summary>
    /// Параметризированный Тест метода Divide
    /// </summary>
    [TestCase(3, 2, 1.5)]
    [TestCase(-3, 4, -0.75)]
    [TestCase(-5, -4, 1.25)]
    public void Divide_TestCaseArgs_ReturnTestCaseResult(decimal a, decimal b, decimal res)
    {
        decimal result = _testingObject.Divide(a, b);
        Assert.That(result, Is.EqualTo(res));
    }

    /// <summary>
    /// Параметризированный Тест метода Divide с указанием источника параметров
    /// </summary>
    [TestCaseSource(nameof(_divideCases))]
    public void Divide_ArgsFromSource_ReturnCorrectResult(decimal a, decimal b, decimal res)
    {
        decimal result = _testingObject.Divide(a, b);
        Assert.That(result, Is.EqualTo(res));
    }




    /// <summary>
    /// Тест метода Divide при делении на 0, возвращающего исключение DevideByZeroException
    /// </summary>
    [Test]
    public void Divide_SimpleArgOnZero_ReturnDevideByZeroException()
        => Assert.Throws<DivideByZeroException>(() => _testingObject.Divide(2, 0));

    /// <summary>
    /// Параметризированный Тест метода Divide при делении на 0
    /// </summary>
    [TestCase(2, 0)]
    [TestCase(-3, 0)]
    [TestCase(-5, 0)]
    public void Divide_TestCaseArgsOnZero_ReturnDevideByZeroException(decimal a, decimal b)
        => Assert.Throws<DivideByZeroException>(() => _testingObject.Divide(a, b));

    /// <summary>
    /// Параметризированный Тест метода Divide при делении на 0 с указанием источника параметров
    /// </summary>
    [TestCaseSource(nameof(_divideByZeroCases))]
    public void Divide_ArgsFromSource_ReturnDevideByZeroException(decimal a, decimal b)
        => Assert.Throws<DivideByZeroException>(() => _testingObject.Divide(a, b));
}
