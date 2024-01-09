using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Введите количество запросов:");

        // Читаем количество запросов, указанное пользователем
        int requestCount = int.Parse(Console.ReadLine());

        // Создаем экземпляр HttpClient
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Отправляем указанное количество запросов
                for (int i = 0; i < requestCount; i++)
                {
                    HttpResponseMessage response = await client.GetAsync("https://en-ege.sdamgia.ru/test?id=2588500");


                    // Получаем ответ в виде строки
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Выводим ответ на экран
                    Console.WriteLine($"Response {i + 1}: {responseBody}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Ошибка при выполнении запроса: {ex.Message}");
            }
        }
    }
}