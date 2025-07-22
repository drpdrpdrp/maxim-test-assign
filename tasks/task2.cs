using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Task2
{
        /// <summary>
        /// Обрабатывает строку в зависимости от её длины.
        /// Если длина строки чётная, разделяет её пополам и переворачивает каждую половину.
        /// Если длина строки нечётная, возвращает перевёрнутую строку + исходную строку.
        /// В строку могут входить только символы латинского алфавита в нижнем регистре.
        /// </summary>
        /// <param name="input">Входная строка для обработки</param>
        /// <returns>Обработанная строка согласно правилам</returns>
    public static string ProcessString(string input, out bool isValid)
    {
        isValid = true;
        if (string.IsNullOrEmpty(input))
            return "";
                

        string invalidSymbols = "";
        for (int i = 0; i < input.Length; i++)
        {
            string lowercaseLettersString = "abcdefghijklmnopqrstuvwxyz";
            if(!lowercaseLettersString.Contains(input[i]))
                {
                    invalidSymbols += input[i];
                    isValid = false;
                }
        }

        if (!isValid)
            return $"Некорректный ввод. Неподходящие символы: {invalidSymbols}";

        return Task1.ProcessString(input);
    }
    public static void RunTests()
    {
        Console.WriteLine("=== Запуск тестов по задаче 2 ===");
        bool allPassed = true;
        allPassed &= TestCase("abcd", "badc");
        allPassed &= TestCase("abc", "cbaabc");
        allPassed &= TestCase("", "");
        allPassed &= TestCase("a", "aa");
        allPassed &= TestCase("ab", "ab");
        allPassed &= TestCase("hello!", "Некорректный ввод. Неподходящие символы: !");
        allPassed &= TestCase("world", "dlrowworld");

        Console.WriteLine($"Все тесты пройдены: {(allPassed ? "ДА" : "НЕТ")}");

        Console.WriteLine("=== Тесты завершены ===\n");
    }

    private static bool TestCase(string input, string? expected)
    {
        string result = ProcessString(input, out bool isvalid);
        bool passed = result == expected;


        Console.WriteLine($"Вход: '{input}'");
        Console.WriteLine($"  Ожидаемый результат: '{expected}'");
        Console.WriteLine($"  Фактический результат: '{result}'");
        Console.WriteLine($"  Тест: {(passed ? "ПРОЙДЕН" : "ПРОВАЛЕН")}\n");
        return passed;
    }
}