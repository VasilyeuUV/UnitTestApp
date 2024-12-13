using Calculator;

namespace xUnit.Calculator.Tests;

/// <summary>
/// Тестовый класс для класса Calc.
/// </summary>
public class CalcXunitTests
{
    /// <summary>
    /// Одиночный непараметрический тест
    /// </summary>
    [Fact(                                                              // - атрибут НЕПАРАМЕТРИЧЕСКОГО теста
        DisplayName = "SolveQuadratic: 2x^2 + 2x + (-40) = 0"           // -- отображаемое название теста
        )]
    public void SolveQuadratic_2and2andm40_resultm5and4()               // - Название тестируемого метода: [ТестируемыйМетод]_[Сценарий]_[ОжидаемыйРезультат]
    {
        // Arrange (исходные данные для проверки)
        double a = 2;
        double b = 2;
        double c = -40;

        // Act (вычисление)
        double[] result = Calc.SolveQuadratic(a, b, c);

        // Assert (проверить результат)
        Assert.Equal([-5, 4], result);                                  // - сравнить два выражения (ожидаемое, фактическое)
    }


    /// <summary>
    /// Параметрический тест.
    /// </summary>
    /// <param name="a">входное значение</param>
    /// <param name="b">входное значение</param>
    /// <param name="c">входное значение</param>
    /// <param name="res1">результат 1</param>
    /// <param name="res2">результат 2</param>
    [Theory(DisplayName = "SolveQuadratic: ax^2 + bx + c = 0, где ")]     // - атрибут ПАРАМЕТРИЧЕСКОГО теста
    [InlineData(2d, 2d, -40d, -5d, 4d)]
    [InlineData(1d, 9d, 14d, -7d, -2d)]
    public void SolveQuadratic_SomeData_returnRightResult(
        double a,
        double b,
        double c,
        double res1,
        double res2)
    {
        // Arrange (исходные данные для проверки)

        // Act (вычисление)
        double[] result = Calc.SolveQuadratic(a, b, c);

        // Assert (проверить результат)
        Assert.Equal([res1, res2], result);
    }


    /// <summary>
    /// Параметрический тест при D == 0.
    /// </summary>
    /// <param name="a">входное значение</param>
    /// <param name="b">входное значение</param>
    /// <param name="c">входное значение</param>
    /// <param name="res">результат 1</param>
    [Theory(DisplayName = "SolveQuadratic: ax^2 + bx + c = 0, при В == 0, где ")]     // - атрибут ПАРАМЕТРИЧЕСКОГО теста
    [InlineData(1d, 2d, 1d, -1d)]
    [InlineData(3d, -18d, 27d, 3d)]
    public void SolveQuadratic_dIs0_resultRightOneAnswer(
        double a,
        double b,
        double c,
        double res)
    {
        // Arrange (исходные данные для проверки)

        // Act (вычисление)
        double[] result = Calc.SolveQuadratic(a, b, c);

        // Assert (проверить результат)
        Assert.Equal([res], result);
    }

}
