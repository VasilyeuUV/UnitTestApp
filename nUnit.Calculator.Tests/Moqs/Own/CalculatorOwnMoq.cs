using Calculator;

namespace nUnit.Calculator.Tests.Moqs.Own;

/// <summary>
/// Пользовательский Moq калькулятора.
/// </summary>
public class CalculatorOwnMoq : ICalc
{
    public decimal Add(decimal a, decimal b)
        => 0;

    public decimal Divide(decimal a, decimal b)
        => b == 0
            ? throw new DivideByZeroException()
            : 0;

    public decimal Multiply(decimal a, decimal b)
        => 0;

    public decimal Subtract(decimal a, decimal b)
        => 0;
}
