using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class RandomNumberFetcher
{
    public async Task<int?> GetRandomNumberAsync(int min, int max)
    {
        try
        {
            using HttpClient client = new HttpClient();
            var url = $"https://www.randomnumberapi.com/api/v1.0/random?min={min}&max={max}&count=1";
            var response = await client.GetStringAsync(url);

            int[] numbers = JsonSerializer.Deserialize<int[]>(response)!;
            return numbers[0];
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при выполнении запроса: {ex.Message}");
            Console.WriteLine("Число генерируется локально");
            return new Random().Next(min, max);
        }
    }
}
