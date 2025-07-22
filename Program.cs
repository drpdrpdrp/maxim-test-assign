using System;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Введите номер задачи (или запустите тесты): ");
        if (!int.TryParse(Console.ReadLine(), out int taskNumber))
        {
            Console.WriteLine("Некорректный ввод. Запускаем тесты.");
            return;
        }


        switch (taskNumber)
        {


            default:
                Console.WriteLine("=== Запуск всех тестов ===");
                break;
        }
    }


}