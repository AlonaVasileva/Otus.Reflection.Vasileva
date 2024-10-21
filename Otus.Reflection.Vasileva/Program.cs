using Otus.Reflection.Vasileva;
using System;
using System.Diagnostics;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        int iterations = 1000;
        F obj = F.Get();

        // Сериализация с использованием Newtonsoft.Json
        Stopwatch stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
        {
            string json = JsonConvert.SerializeObject(obj);
        }
        stopwatch.Stop();
        Console.WriteLine($"Время сериализации JSON: {stopwatch.ElapsedMilliseconds} ms");

        // Десериализация с использованием Newtonsoft.Json
        string jsonString = JsonConvert.SerializeObject(obj);
        stopwatch.Restart();
        for (int i = 0; i < iterations; i++)
        {
            F newObj = JsonConvert.DeserializeObject<F>(jsonString);
        }
        stopwatch.Stop();
        Console.WriteLine($"Время десериализации JSON: {stopwatch.ElapsedMilliseconds} ms");
        Console.ReadKey();
    }
}