using CreaturesLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CreaturesTests
{
    /// <summary>
    /// Проврека перемножения существ.
    /// </summary>
    [TestClass]
    public class MultiplyTests 
    {
        /// <summary>
        /// Првоерка перемножения с нименами нечетной длины.
        /// </summary>
        [TestMethod]
        public void Check_odd_names()
        {
            var temp1 = new Creature("Mambarala", MovementType.Flying, 2.9236458);
            var temp2 = new Creature("Barabar", MovementType.Flying, 2.9236458);
            Assert.AreEqual("Mambabar", (temp1 * temp2).Name);
        }

        /// <summary>
        /// Проверка еремножения с именами четной длины.
        /// </summary>
        [TestMethod]
        public void Check_even_names()
        {
            var temp1 = new Creature("Mambar", MovementType.Flying, 2.9236458);
            var temp2 = new Creature("Barabara", MovementType.Flying, 2.9236458);
            Assert.AreEqual("Barabar", (temp1 * temp2).Name);
        }

        /// <summary>
        /// Проверка здоровья при перемножении.
        /// </summary>
        [TestMethod]
        public void Check_health()
        {
            var temp1 = new Creature("Mambar", MovementType.Flying, 3);
            var temp2 = new Creature("Barabara", MovementType.Flying, 8);
            Assert.AreEqual(5.5, (temp1 * temp2).Health);
        }
    }
}
