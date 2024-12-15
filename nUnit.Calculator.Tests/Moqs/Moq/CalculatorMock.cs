using Calculator;

namespace nUnit.Calculator.Tests.Moqs.Moq;


/// <summary>
/// Пример того, что может создавать библиотека Moq. 
/// Т.е. логики никакой не создается, и в качестве результата может быть возвращено любое значение.
/// </summary>
internal class CalculatorMock : ICalc
{
    public decimal Add(decimal a, decimal b)
        => a == 2 && b == 3
            ? 5
            : default;

    public decimal Divide(decimal a, decimal b)
        => a == 6 && b == 3 ? 2
         : a == 6 && b == 0 ? throw new DivideByZeroException()
         : default;

    public decimal Multiply(decimal a, decimal b)
        => a == 2 && b == 3
            ? 6
            : default;

    public decimal Subtract(decimal a, decimal b)
        => a == 4 && b == 3
            ? 1
            : default;
}
