using System;
using System.Reflection;
using System.Text;

namespace Otus.Reflection.Vasileva
{
    public class CsvSerializer
    {
        public static string Serialize<T>(T obj)
        {
            StringBuilder csv = new StringBuilder();
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in properties)
            {
                csv.Append(prop.GetValue(obj));
                csv.Append(",");
            }

            return csv.ToString().TrimEnd(',');
        }

        public static T Deserialize<T>(string csv) where T : new()
        {
            T obj = new T();
            string[] values = csv.Split(',');
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            for (int i = 0; i < properties.Length && i < values.Length; i++)
            {
                properties[i].SetValue(obj, Convert.ChangeType(values[i], properties[i].PropertyType));
            }

            return obj;
        }
    }
}