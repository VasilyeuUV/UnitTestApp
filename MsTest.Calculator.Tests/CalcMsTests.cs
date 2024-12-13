using Calculator;

namespace MsTest.Calculator.Tests;

/// <summary>
/// Класс для тестирования методов класса Calc
/// </summary>
[TestClass]                                     // - атрибут, помечающий класс как тестовый
public class CalcMsTests
{
    [TestMethod]                                // - атрибут, отмечающий метод как тестовый
    public void Sum_10plus20_return30()         // - метод проверяет корректность суммирования в методе Sum(int, int)
    {
        // Arrange (настроить)
        var calc = new Calc();
        int x = 10;
        int y = 20;
        int expected = 30;                      // - результат, который мы ожидаем

        // Act (выполнить действие)
        decimal actual = calc.Add(x, y);        // - результат, который получаем в результате работы метода

        // Assert (проверить результат)
        Assert.AreEqual(expected, actual);      // - сравнить ожидаемое и получаемое
    }
}
