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
    public static async Task<(string? processed, string message)> ProcessString(string input, string sortType = "QSort") // NOTE: стоит разделить подзадачи (подсчет, сортировка), возможно использовать инстанс класса
    {
        string message;
        bool isValid = true;
        // Проверка на пустоту строки
        if (string.IsNullOrEmpty(input))
        {
            message = "На вход получена пустая строка";
            return (null, message);
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
            message = $"Некорректный ввод. Неподходящие символы: '{invalidSymbols}'";
            return (null, message);
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
        message += $"Самая длинная подстрока начинающаяся и заканчивающаяся на гласную: {vowelMatch}\n";

        // NOTE: можно подсчитывать кол-во символов уже отсортированной строки, не нужен будет Dictionary
        // Сортировка строки
        var sortedString = processedString.ToArray();

        switch (sortType)
        {
            case "QSort":
                QuickSorter.QuickSort(sortedString);
                break;
            case "TreeSort":
                sortedString = TreeNode<char>.TreeSort(sortedString.ToArray());
                break;
            default:
                QuickSorter.QuickSort(sortedString);
                break;
        }

        message += $"Отсортированная обработанная строка: {new(sortedString)}\n";

        var radnNum = new RandomNumberFetcher();
        var rnd = await radnNum.GetRandomNumberAsync(0, processedString.Length);
        var processedStringWithoutOne = processedString.Remove(rnd.Value, 1); 
        message += $"Обработанная строка с случайно удаленным символом ('{processedString[rnd.Value]}' на {rnd.Value} месте): {processedStringWithoutOne}";


        return (processedString, message);
    }
}