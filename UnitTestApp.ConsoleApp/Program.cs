namespace UnitTestApp.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var fn = Outer();       // fn = Inner, так как метод Outer возвращает функцию Inner

            // вызываем внутреннюю функцию Inner
            fn();       // 6
            fn();       // 7
            fn();       // 8
        }

        static Action Outer()      // метод или внешняя функция
        {
            int x = 5;  // лексическое окружение для внутренней функции - локальная переменная
            void Inner()    // локальная (внутренняя) функция
            {
                x++;    // операции с лексическим окружением
                Console.WriteLine(x);
            }
            return Inner;   // возвращаем локальную функцию
        }
    }
}