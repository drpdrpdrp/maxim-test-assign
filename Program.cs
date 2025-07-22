using System;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Введите номер задачи (или запустите тесты): ");
        if (!int.TryParse(Console.ReadLine(), out int taskNumber))
        {
            Console.WriteLine("Некорректный ввод. Запускаем тесты.");
            Task1.RunTests();
            Task2.RunTests();
            return;
        }


        switch (taskNumber)
        {
            case 1:
                RunTask1();
                break;
            case 2:
                RunTask2();
                break;

            default:
                Console.WriteLine("=== Запуск всех тестов ===");
                Task1.RunTests();
                Task2.RunTests();
                break;
        }
    }

    static void RunTask1()
    {
        Console.WriteLine("=== Задача 1: Обработка строк ===");

        Console.WriteLine("Введите строку:");
        string input = Console.ReadLine() ?? "";

        string result = Task1.ProcessString(input);

        Console.WriteLine($"Обработанная строка: {result}");
    }
    static void RunTask2()
    {
        Console.WriteLine("=== Задача 2: Обработка строк с ограничениями ===");

        Console.WriteLine("Введите строку:");
        string input = Console.ReadLine() ?? "";

        string result = Task2.ProcessString(input, out bool isValid);

        if (isValid)
            Console.WriteLine($"Обработанная строка: {result}");
        else
            Console.WriteLine(result);
    }

}