using System;
using Microsoft.VisualBasic;

class Program
{
    static async Task Main(string[] args)
    {

        Console.Write("Введите строку: ");
        string input = Console.ReadLine() ?? "";
        Console.WriteLine("Введите метод сортировки (1 - QSort, 2 - TreeSort, иначе QSort): ");
        string sortInput = Console.ReadLine() ?? "";
        string sortType = "";
        switch (sortInput)
        {
            case "1":
                sortType = "QSort";
                break;
            case "2":
                sortType = "TreeSort";
                break;
            default:
                sortType = "QSort";
                break;
        }

        (string? result, string msg) = await StringProcessTask.ProcessString(input, sortType);

        if (result != null)
            Console.WriteLine($"Обработанная строка: {result}");
        Console.WriteLine(msg);

    }


}