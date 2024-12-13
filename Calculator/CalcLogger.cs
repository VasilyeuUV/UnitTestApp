using Calculator.Logger;

namespace Calculator;

/// <summary>
/// Калькулятор с логгированием.
/// </summary>
public class CalcLogger : ICalc
{
    private readonly ILogger _logger;
    private readonly ICalc _calc;


    /// <summary>
    /// CTOR
    /// </summary>
    /// <param name="logger">логгер</param>
    /// <param name="calc">Калькулятор</param>
    public CalcLogger(ILogger logger, ICalc calc)
    {
        _logger = logger;
        _calc = calc;
    }


    public decimal Add(decimal a, decimal b)
    {
        _logger.Log("Add operation");
        return _calc.Add(a, b);
    }

    public decimal Divide(decimal a, decimal b)
    {
        _logger.Log("Divide operation");
        return _calc.Divide(a, b);
    }

    public decimal Multiply(decimal a, decimal b)
    {
        _logger.Log("Multiply operation");
        return _calc.Multiply(a, b);
    }

    public decimal Subtract(decimal a, decimal b)
    {
        _logger.Log("Subtract operation");
        return _calc.Subtract(a, b);
    }
}
