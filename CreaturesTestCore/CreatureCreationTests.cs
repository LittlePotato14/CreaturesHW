using System;
using CreaturesLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CreaturesTests
{
    /// <summary>
    /// Проверка конструктора и сеттеров.
    /// </summary>
    [TestClass]
    public class CreatureCreationTests
    {
        /// <summary>
        /// Проверка на имя меньше доступного.
        /// </summary>
        [TestMethod]
        public void Smaller_than_min_name()
        {
            try
            {
                var temp = new Creature("Ala", MovementType.Flying, Creature.healthMin);
                Assert.Fail("Не выкинуто исключение.");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is CreatureException);
            }
        }

        /// <summary>
        /// Проверка на имя больше доступного.
        /// </summary>
        [TestMethod]
        public void Bigger_than_max_name()
        {
            try
            {
                var temp = new Creature("Alalalalalalalla", MovementType.Flying, Creature.healthMin);
                Assert.Fail("Не выкинуто исключение.");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is CreatureException);
            }
        }

        /// <summary>
        /// Проверка на некорректное имя, подходящее по длине.
        /// </summary>
        [TestMethod]
        public void Incorrect_name()
        {
            try
            {
                var temp = new Creature("maHitoro", MovementType.Flying, Creature.healthMin);
                Assert.Fail("Не выкинуто исключение.");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is CreatureException);
            }
        }

        /// <summary>
        /// Проверка на маленькое здоровье.
        /// </summary>
        [TestMethod]
        public void Less_than_min_health()
        {
            try
            {
                var temp = new Creature("Mambara", MovementType.Flying, Creature.healthMin - 1);
                Assert.Fail("Не выкинуто исключение.");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is CreatureException);
            }
        }

        /// <summary>
        /// Проверка на большое здоровье.
        /// </summary>
        [TestMethod]
        public void More_than_max_health()
        {
            try
            {
                var temp = new Creature("Mambara", MovementType.Flying, Creature.healthMax + 1);
                Assert.Fail("Не выкинуто исключение.");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is CreatureException);
            }
        }

        /// <summary>
        /// Првоерка корректного создания.
        /// </summary>
        [TestMethod]
        public void Correct_Creation()
        {
            try
            {
                var temp = new Creature("Mambara", MovementType.Flying, Creature.healthMin);
            }
            catch (Exception ex)
            {
                Assert.Fail("Не ожидалось исключение, но было получено: " + ex.Message);
            }
        }
    }
}
