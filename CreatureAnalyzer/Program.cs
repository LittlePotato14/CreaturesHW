using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using CreaturesLibrary;

namespace CreatureAnalyzer
{
    class Program
    {
        /// <summary>
        /// Производит десериализацию и возвращает список объектов.
        /// </summary>
        static List<T> ReadFromXml<T>(string path)
        {
            List<T> result = null;
            try
            {
                var serXML = new DataContractSerializer(typeof(List<T>));
                using (var fs = new FileStream(path, FileMode.Open))
                    result = (List<T>)serXML.ReadObject(fs);
            }
            #region exceptions
            catch (IOException)
            {
                Console.WriteLine("Ошибка ввода-вывода.");
            }
            catch (SecurityException)
            {
                Console.WriteLine("Ошибка безопасности.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Ошибка доступа.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Упс, что-то пошло не так...\n" + ex.Message);
            }
            #endregion exceptions

            return result;
        }

        static void Main()
        {
            var creatures = ReadFromXml<Creature>(@"../../../creatures.xml");

            // Количество плавающих.
            Console.WriteLine("Количество плавающих: " +
                $"{creatures.Where(x => x.MovementType == MovementType.Swimming).Count()}");
            Console.WriteLine();

            // сортировка по убыванию здоровья и первые 10 эдементов оттуда.
            creatures = creatures.OrderByDescending(x => x.Health).Take(10).ToList();
            Console.WriteLine(String.Join(Environment.NewLine, creatures));
            Console.WriteLine();

            // Объединение по группам по типу движения и перемножение внутри групп.
            creatures = creatures.GroupBy(x => x.MovementType).Select(g=>g.Aggregate((a, b)=> a * b)).ToList();
            Console.WriteLine(String.Join(Environment.NewLine, creatures));
            Console.WriteLine();

            // Сордировка по убыванию здоровья и первые 10.
            creatures = creatures.OrderByDescending(x=>x.Health).Take(10).ToList();
            Console.WriteLine(String.Join(Environment.NewLine, creatures));
        }
    }
}
