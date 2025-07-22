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
            return;
        }


        switch (taskNumber)
        {
            case 1:
                RunTask1();
                break;

            default:
                Console.WriteLine("=== Запуск всех тестов ===");
                Task1.RunTests();
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

}