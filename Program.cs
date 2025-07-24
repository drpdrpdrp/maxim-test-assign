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

        string? result = StringProcessTask.ProcessString(input, out string msg, sortType);

        if (result != null)
            Console.WriteLine($"Обработанная строка: {result}");
        Console.WriteLine(msg);

    }


}