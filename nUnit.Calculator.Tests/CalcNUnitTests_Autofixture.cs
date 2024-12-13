using AutoFixture;
using Calculator;

namespace nUnit.Calculator.Tests;

/// <summary>
/// Тесты с использованием библиотеки Autofixture.
/// </summary>
public class CalcNUnitTests_Autofixture
{
    private static Fixture _fixture = new();                        // - инициализация объекта Autofixture, который будет генерировать данные.

    private ICalc _testingObject;                                            // - объект, который будет тестироваться (ДОЛЖЕН БЫТЬ ОДИН!!! Нельзя в одном классе тестировать несколько объектов)

    private decimal _a;                                             // - переменные, в которые будут генерироваться данные
    private decimal _b;




    [SetUp]
    public void Setup()
    {
        _testingObject = new Calc();

        _a = _fixture.Create<decimal>();                            // - создание рандомного значения decimal
        _b = _fixture.Create<decimal>();
    }




    /// <summary>
    /// Тест метода Add с валидными аргументами, возвращающего корректный результат
    /// </summary>
    [Test]                                                          // - атрибут, обозначающий, что отмеченный метод - НЕПАРАМЕТРИЗИРОВАННЫЙ тестовый
    public void Add_AutofixureArgs_ReturnCorrectResult()
    {
        // Act
        decimal result = _testingObject.Add(_a, _b);                         // - использование рандомно сгенерированных значений

        // Assert
        Assert.That(result, Is.EqualTo(_a + _b));                   // - в качестве ожидаемого значения результат операции с _a и _b
    }


    /// <summary>
    /// Тест метода Substract с валидными аргументами, возвращающего корректный результат
    /// </summary>
    [Test]
    public void Substract_AutofixureArgs_ReturnCorrectResult()
    {
        decimal result = _testingObject.Subtract(_a, _b);
        Assert.That(result, Is.EqualTo(_a - _b));
    }


    /// <summary>
    /// Тест метода Multiply с валидными аргументами, возвращающего корректный результат
    /// </summary>
    [Test]
    public void Multiply_AutofixureArgs_ReturnCorrectResult()
    {
        decimal result = _testingObject.Multiply(_a, _b);
        Assert.That(result, Is.EqualTo(_a * _b));
    }


    /// <summary>
    /// Тест метода Divide с валидными аргументами, возвращающего корректный результат
    /// </summary>
    [Test]
    public void Divide_AutofixureArgs_ReturnCorrectResult()
    {
        if (_b == 0)
        {
            Assert.Throws<DivideByZeroException>(() => _testingObject.Divide(_a, 0));
        }
        else
        {
            decimal result = _testingObject.Divide(_a, _b);
            Assert.That(result, Is.EqualTo(_a / _b));
        }
    }


    /// <summary>
    /// Тест метода Divide при делении на 0, возвращающего исключение DevideByZeroException
    /// </summary>
    [Test]
    public void Divide_AutofixureArgs_ReturnDevideByZeroException()
        => Assert.Throws<DivideByZeroException>(() => _testingObject.Divide(_a, 0));
}
