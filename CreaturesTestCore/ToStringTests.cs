using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreaturesLibrary;

namespace CreaturesTests
{
    /// <summary>
    /// Првоерка ToString и форматирования даблов.
    /// </summary>
    [TestClass]
    public class ToStringTests
    {
        /// <summary>
        /// ToString с округлением вверх.
        /// </summary>
        [TestMethod]
        public void To_string_test_fup()
        {
            var temp = new Creature("Mambara", MovementType.Flying, 2.9236458);
            Assert.AreEqual("Flying creature Mambara: Health = 2,924", temp.ToString());
        }

        /// <summary>
        /// ToString с округлением вниз.
        /// </summary>
        [TestMethod]
        public void To_string_test_fdown()
        {
            var temp = new Creature("Mambara", MovementType.Flying, 3.454200595);
            Assert.AreEqual("Flying creature Mambara: Health = 3,454", temp.ToString());
        }
    }
}
