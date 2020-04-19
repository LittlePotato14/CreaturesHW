using CreaturesLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.IO;

namespace CreaturesTests
{
    /// <summary>
    /// Проверка сериадизации.
    /// </summary>
    [TestClass]
    public class SerializationTests 
    {
        /// <summary>
        /// Проверка сериализации.
        /// </summary>
        [TestMethod]
        public void Serialize_one_creature()
        {
            var before = new Creature("Mambara", MovementType.Flying, 2.9236458);

            var writeSettings = new XmlWriterSettings();
            writeSettings.Indent = true;

            var serXML = new System.Runtime.Serialization.DataContractSerializer(typeof(Creature));
            using (var xmlWriter = XmlWriter.Create(@"../../../check.xml", writeSettings))
                serXML.WriteObject(xmlWriter, before);

            Creature after;
            using (var fs = new FileStream(@"../../../check.xml", FileMode.Open))
                after = (Creature)serXML.ReadObject(fs);

            // Убираем мусор.
            File.Delete(@"../../../check.xml");

            Assert.AreEqual(before, after);
        }

        /// <summary>
        /// Проверка того, что тесты работают и неравные объекты не равны. 
        /// (Я устала, я не могу так больше)
        /// </summary>
        [TestMethod]
        public void Not_equal()
        {
            var first = new Creature("Mambara", MovementType.Flying, 2.9236458);
            var second = new Creature("Copibara", MovementType.Flying, 3);

            Assert.AreNotEqual(first, second);
        }
    }
}
