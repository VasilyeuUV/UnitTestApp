using Calculator;

namespace CalculatorTests
{
    /// <summary>
    /// ����� ��� ������������ ������� ������ Calc
    /// </summary>
    [TestClass]                                     // - �������, ���������� ����� ��� ��������
    public class CalcTests
    {
        [TestMethod]                                // - �������, ���������� ����� ��� ��������
        public void Sum_10plus20_return30()         // - ����� ��������� ������������ ������������ � ������ Sum(int, int)
        {
            // Arrange (���������)
            int x = 10;
            int y = 20;
            int expected = 30;                      // - ���������, ������� �� �������

            // Act (��������� ��������)
            int actual = Calc.Sum(x, y);            // - ���������, ������� �������� � ���������� ������ ������

            // Assert (��������� ���������)
            Assert.AreEqual(expected, actual);      // - �������� ��������� � ����������
        }
    }
}