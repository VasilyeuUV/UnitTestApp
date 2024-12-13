namespace Calculator;


/// <summary>
/// Контракт калькулятора.
/// </summary>
public interface ICalc
{
    /// <summary>
    /// Сложение
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    decimal Add(decimal a, decimal b);

    /// <summary>
    /// Вычитание
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    decimal Subtract(decimal a, decimal b);

    /// <summary>
    /// Умножение
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    decimal Multiply(decimal a, decimal b);

    /// <summary>
    /// Деление
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    decimal Divide(decimal a, decimal b);


}
