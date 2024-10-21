using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Otus.Reflection.Vasileva
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = F.Get();
            int iterations = 100000;

            // Замер сериализации в CSV
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                var csv = CsvSerializer.Serialize(obj);
            }
            stopwatch.Stop();
            Console.WriteLine($"Сериализация в CSV: {stopwatch.ElapsedMilliseconds} мс");

            // Замер десериализации из CSV
            string serializedData = CsvSerializer.Serialize(obj);
            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                var deserializedObj = CsvSerializer.Deserialize<F>(serializedData);
            }
            stopwatch.Stop();
            Console.WriteLine($"Десериализация из CSV: {stopwatch.ElapsedMilliseconds} мс");

            // Сравнение с Newtonsoft.Json
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                var jsonSerialized = JsonConvert.SerializeObject(obj);
            }
            stopwatch.Stop();
            Console.WriteLine($"Сериализация с Newtonsoft.Json: {stopwatch.ElapsedMilliseconds} мс");

            stopwatch.Reset();
            var json = JsonConvert.SerializeObject(obj);
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                var jsonObj = JsonConvert.DeserializeObject<F>(json);
            }
            stopwatch.Stop();
            Console.WriteLine($"Десериализация с Newtonsoft.Json: {stopwatch.ElapsedMilliseconds} мс");

            Console.ReadKey();
        }
    }
}