using System;
using System.Linq;
using System.Text.RegularExpressions;
public static class StringProcessTask
{


    /// <summary>
    /// Обрабатывает строку в зависимости от её длины.
    /// Если длина строки чётная, разделяет её пополам и переворачивает каждую половину.
    /// Если длина строки нечётная, возвращает перевёрнутую строку + исходную строку.
    /// В строку могут входить только символы латинского алфавита в нижнем регистре.
    /// Возвращает пользователю информацию о том, сколько раз повторялся каждый символ в обработанной строке.
    /// Выводит самую длинную подстроку начинающуюся и заканчивающуюся на гласную
    /// </summary>
    /// <param name="input">Входная строка для обработки</param>
    /// <returns>Обработанная строка согласно правилам</returns>
    public static string? ProcessString(string input, out string message)
    {

        bool isValid = true;
        // Проверка на пустоту строки
        if (string.IsNullOrEmpty(input))
        {
            message = "На вход получена пустая строка";
            return null;
        }
                

        // Проверка на разрешенные символы
        string invalidSymbols = "";
        string lowercaseLettersString = "abcdefghijklmnopqrstuvwxyz";
        var lettersCount = lowercaseLettersString.ToDictionary(c => c, c => 0);
        for (int i = 0; i < input.Length; i++)
        {
            if(!lowercaseLettersString.Contains(input[i]))
            {
                invalidSymbols += input[i];
                isValid = false;
            }
            else
            {
                lettersCount[input[i]] += 1;
            }

        }

        if (!isValid)
        {
            message = $"Некорректный ввод. Неподходящие символы: {invalidSymbols}";
            return null;
        }



        // Обработка строки
        string processedString;
        if (input.Length % 2 == 0)
        {
            int mid = input.Length / 2;
            string firstHalf = input[..mid];
            string secondHalf = input[mid..];

            string reversedFirst = new(firstHalf.Reverse().ToArray());
            string reversedSecond = new(secondHalf.Reverse().ToArray());

            processedString = reversedFirst + reversedSecond;
        }
        else
        {
            string reversed = new(input.Reverse().ToArray());
            processedString = reversed + input;
        }

        // Подсчет и вывод кол-ва символов
        message = "";
        for (int i = 0; i < lettersCount.Count; i++)
        {
            var curChar = lowercaseLettersString[i];
            var curCharCount = lettersCount[curChar];
            var processedCountEven = input.Length % 2 + 1;
            if (curCharCount != 0)
                message += $"Символов '{curChar}' в обработанной строке: {curCharCount * processedCountEven}\n";
        };

        // Находим строку с началом и концом на гласную (greedy match гарантирует самую длинную строку, с фейлсейфом если гласная одна)
        string pattern = @"[aeiouy].*[aeiouy]|[aeiouy]";
        var vowelMatch = Regex.Match(processedString, pattern).ToString();
        message += $"Самая длинная подстрока начинающаяся и заканчивающаяся на гласную: {vowelMatch}";


        return processedString;
    }
    public static void RunTests()
    {
        Console.WriteLine("=== Запуск тестов по задаче 2 ===");
        bool allPassed = true;
        allPassed &= TestCase("abcd", "badc");
        allPassed &= TestCase("abc", "cbaabc");
        allPassed &= TestCase("", null);
        allPassed &= TestCase("a", "aa");
        allPassed &= TestCase("ab", "ab");
        allPassed &= TestCase("hello!", null);
        allPassed &= TestCase("world", "dlrowworld");
        allPassed &= TestCase("abc124", null);

        Console.WriteLine($"Все тесты пройдены: {(allPassed ? "ДА" : "НЕТ")}");

        Console.WriteLine("=== Тесты завершены ===\n");
    }

    // TODO: Добавить тесты сообщений
    private static bool TestCase(string input, string? expected)
    {
        string? result = ProcessString(input, out _);
        bool passed = result == expected;

        Console.WriteLine($"Вход: '{input}'");
        Console.WriteLine($"  Ожидаемый результат: '{expected}'");
        Console.WriteLine($"  Фактический результат: '{result}'");
        Console.WriteLine($"  Тест: {(passed ? "ПРОЙДЕН" : "ПРОВАЛЕН")}\n");
        return passed;
    }
}