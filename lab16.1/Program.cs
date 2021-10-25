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

namespace lab16._1
{
    /* Разработать программу для записи информации о товаре в текстовый файл в формате json.
    * Разрабоать класс для моделирования объекта "Товар". Предусмотреть члены класса "Код товара" (целое число), "Название товара" (строка), "Цена товара" (вещественное число).
    * Создать массив из пяти товаров, значения должны вводиться пользователем с клавиатуры.
    * Сериализовать массив в json-строку, сохранить её программно в файл "Products.json".*/
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Products.json";
            if (!File.Exists(path))
            {
                File.Create(path);
            }            
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            Product[] catalog = new Product[5];
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                for (int i = 0; i < 5; i++)
                {
                    catalog[i] = new Product();
                    catalog[i].Input();
                    Console.WriteLine();
                }
                string jsonString = JsonSerializer.Serialize(catalog, options);
                sw.WriteLine(jsonString);
            }            
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

        public void Input()
        {
            try
            {
                Console.Write("Введите код товара (целое число): ");
                ItemCode = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите название товара: ");
                ItemName = Console.ReadLine();
                Console.Write("Введите цену товара: ");
                ItemPrice = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
