using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace lab16._2
{
    /* Разработать программу для получения информации о товаре из json-файла.
     * Десериализовать файл "Products.json" из задачи lab16.1. Определить название самого дорогого товара.*/
    class Program
    {
        static void Main(string[] args)
        {
            double max = 0;
            string itemName = "";
            string path = "C:\\Users\\f0rtt\\source\\repos\\lab16\\lab16.1\\bin\\Debug\\Products.json";
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            Product[] catalog = JsonSerializer.Deserialize<Product[]>(File.ReadAllText(path));
            for (int i = 0; i < catalog.Length; i++)
            {                
                Console.WriteLine("Код товара: {0} \nНазвание товара: {1} \nЦена товара: {2}", catalog[i].ItemCode, catalog[i].ItemName, catalog[i].ItemPrice);
                Console.WriteLine();
                if (catalog[i].ItemPrice > max)
                {
                    max = catalog[i].ItemPrice;
                    itemName = catalog[i].ItemName;
                }
            }
            Console.WriteLine("Самый дорогой товар - {0}", itemName);            
            Console.WriteLine("Для завершения нажмите любую клавишу на клавиатуре");
            Console.ReadKey();           
        }
    }
    class Product
    {
        [JsonPropertyName("itemCode")]
        public int ItemCode { get; set; }
        [JsonPropertyName("itemName")]
        public string ItemName { get; set; }
        [JsonPropertyName("itemPrice")]
        public double ItemPrice { get; set; }
    }
}
