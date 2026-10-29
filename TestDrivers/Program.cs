using System;

namespace TestDrivers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Запуск тестирования класса CSquareMatrix");
            Console.WriteLine("Результаты записываются в файл logFile.dat ...");
            CTest_Driver driver = new CTest_Driver();
            Console.WriteLine("Тестирование завершено. Откройте logFile.dat для просмотра.");
            Console.ReadKey();
        }
    }
}