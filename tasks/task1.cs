using System;
using System.Linq;

public static class Task1
{
    /// <summary>
    /// Обрабатывает строку в зависимости от её длины.
    /// Если длина строки чётная, разделяет её пополам и переворачивает каждую половину.
    /// Если длина строки нечётная, возвращает перевёрнутую строку + исходную строку.
    /// </summary>
    /// <param name="input">Входная строка для обработки</param>
    /// <returns>Обработанная строка согласно правилам</returns>
    public static string ProcessString(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        if (input.Length % 2 == 0)
        {
            int mid = input.Length / 2;
            string firstHalf = input[..mid];
            string secondHalf = input[mid..];

            string reversedFirst = new(firstHalf.Reverse().ToArray());
            string reversedSecond = new(secondHalf.Reverse().ToArray());

            return reversedFirst + reversedSecond;
        }
        else
        {
            string reversed = new(input.Reverse().ToArray());
            return reversed + input;
        }
    }
    public static void RunTests()
    {
        Console.WriteLine("=== Запуск тестов по задаче 1 ===");
        bool allPassed = true;
        allPassed &= TestCase("abcd", "badc");
        allPassed &= TestCase("abc", "cbaabc");
        allPassed &= TestCase("", "");
        allPassed &= TestCase("a", "aa");
        allPassed &= TestCase("ab", "ab");
        allPassed &= TestCase("hello!", "leh!ol");
        allPassed &= TestCase("world", "dlrowworld");

        Console.WriteLine($"Все тесты пройдены: {(allPassed ? "ДА" : "НЕТ")}");

        Console.WriteLine("=== Тесты завершены ===\n");
    }

    private static bool TestCase(string input, string expected)
    {
        string result = ProcessString(input);
        bool passed = result == expected;


        Console.WriteLine($"Вход: '{input}'");
        Console.WriteLine($"  Ожидаемый результат: '{expected}'");
        Console.WriteLine($"  Фактический результат: '{result}'");
        Console.WriteLine($"  Тест: {(passed ? "ПРОЙДЕН" : "ПРОВАЛЕН")}\n");
        return passed;
    }
}