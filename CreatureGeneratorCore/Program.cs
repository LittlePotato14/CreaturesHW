using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using System.Xml;
using CreaturesLibrary;

namespace CreatureGenerator
{
    class Program
    {
        /// <summary>
        /// Это рандом ┌( ಠ_ಠ)┘
        /// </summary>
        static readonly Random rnd = new Random();

        /// <summary>
        /// Генерирует имя заданной длины. Первая буква заглавная, остальные строчные.
        /// </summary>
        /// <param name="len"> Длина имени. </param>
        static string GenerateName(int len)
        {
            /*
             * Альтернативное решение:
             * Не использовать StringBuilder, использовать просто String +=. (Но это не эффективно)
             */
            StringBuilder sb = new StringBuilder(len);
            sb.Append((char)rnd.Next('A', 'Z' + 1));

            for (int i = 1; i < len; i++)
                sb.Append((char)rnd.Next('a', 'z' + 1));

            return sb.ToString();
        }

        /// <summary>
        /// Выполняет сериализацию переданного списка объектов.
        /// </summary>
        static void WriteToXml<T>(List<T> list, string path)
        {
            var writeSettings = new XmlWriterSettings();
            writeSettings.Indent = true;
            try
            {
                var serXML = new DataContractSerializer(typeof(List<T>));
                using (var xmlWriter = XmlWriter.Create(path, writeSettings))
                    serXML.WriteObject(xmlWriter, list);
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
        }

        static void Main()
        {
            var creatures = new List<Creature>(30);
            var enumLen = Enum.GetNames(typeof(MovementType)).Length;
            for (int i = 0; i < 30; i++)
                creatures.Add(new Creature(
                    GenerateName(rnd.Next(6, 10)), 
                    (MovementType)rnd.Next(enumLen),
                    rnd.NextDouble() * (Creature.healthMax - Creature.healthMin) + Creature.healthMin));

            foreach (var creature in creatures)
                Console.WriteLine(creature.ToString());

            WriteToXml<Creature>(creatures, @"../../../../creatures.xml");
        }
    }
}
