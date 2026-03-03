using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;

    class Program
    {
        static void Main()
        {
            int num;
            while (true)
            {
                try
                {
                    Console.Write("enter task number: ");
                    num = int.Parse(Console.ReadLine());
                    switch (num)
                    {
                        case 1:
                            Task1();
                            break;

                        case 2:
                            Task2();
                            break;

                        case 3:
                            Task3();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("enter valid value");
                }
            }
        }

        static void Task1()
        {
            Console.WriteLine("1 - ввести шлях вручну\n2 - використати стандартну папку");
            
            string path = "/Users/arinakhmeluk/Desktop/coding/2 sem";
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("введіть шлях: ");
                path = Console.ReadLine().Trim('\'', '\"', ' ');
            }
            else
            {
                Console.WriteLine($"обраний шлях: {path}");
            }
            
            if (Directory.Exists(path))
            {
                List<string> newList = new List<string>();

                try {
                    string[] entries = System.IO.Directory.GetFileSystemEntries(path, "*", System.IO.SearchOption.AllDirectories);
            
                    newList.AddRange(entries);
                    Console.WriteLine($"знайдено елементів: {newList.Count}");

                    foreach (string item in newList)
                    {
                        Console.WriteLine(System.IO.Path.GetFileName(item));
                    }
                }
                catch  {
                    Console.WriteLine("сталась помилка");
                }
            }
            else
            {
                Console.WriteLine("такої папки не існує");
            }

        }

        static void Task2()
        {
            Console.Write("enter string: ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("string cant be empty");
                return;
            }
            
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char c in input)
            {
                if (!char.IsLetter(c)) continue;
                
                if(dict.ContainsKey(c)) dict[c]++;
                
                else dict[c] = 1;
            }
            
            var sortedDict = dict.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value); //для кожної пари беремо її ключ

            foreach (var pair in sortedDict)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

            try
            {
                string jsonString = JsonSerializer.Serialize(sortedDict);
                string pathJson = "/Users/arinakhmeluk/Desktop/coding/2 sem/laba_1.2/result.json";
                using (StreamWriter writer = new StreamWriter(pathJson))
                {
                    writer.Write(jsonString);
                }

                Console.WriteLine("result saved to result.json");
            }
            catch
            {
                Console.WriteLine("error");
            }
        }

        static void Task3()
        {
            List<int> numbers = new List<int> { -5, 12, 3, -2, 25, 8 }; 
            Console.WriteLine("початкова послідовність: " + string.Join(", ", numbers));

            var multiplied = numbers.Select((x, index) => x * (index + 1));//беремо число х і множимо найого порядкоивй номер
            Console.WriteLine("після множення: " + string.Join(", ", multiplied));

            var result = multiplied
                .Where(x => Math.Abs(x).ToString().Length == 2)//фільтруємо
                .Reverse();                                        

         
            Console.Write("результат:");
            Console.WriteLine(result.Any() ? string.Join(", ", result) : "нічого не знайдено"); //хоча б один ел виодимо через ,
        }
    } 

