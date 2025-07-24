using System;

class Program
{
    static void Main(string[] args)
    {

        bool isTesting = false;
        if (isTesting)
        {
            StringProcessTask.RunTests();
            return;
        }

        Console.Write("Введите строку: ");
        string input = Console.ReadLine() ?? "";

        string? result = StringProcessTask.ProcessString(input, out string msg);

        if (result != null)
            Console.WriteLine($"Обработанная строка: {result}");
        Console.WriteLine(msg);



    }


}