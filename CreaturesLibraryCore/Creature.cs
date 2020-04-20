using System;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace CreaturesLibrary
{
    [DataContract]
    public class Creature
    {
        // Паттерн для проверки имени.
        const string regexNamePattern = @"^[A-z][a-z]{5-9}$";

        // Допустимое здоровье.
        public const double healthMin = 0;
        public const double healthMax = 9;

        string name;
        [DataMember()]
        /// <summary>
        /// Имя существа.
        /// Альтернативное решение: не использовать Regex.
        /// </summary>
        public string Name
        {
            get => name;
            private set {
                if (!Regex.IsMatch(value, @"^[A-Z][a-z]{5,9}$"))
                    throw new CreatureException($"Имя {value} не соответсвует шаблону.");
                name = value;
            }
        }

        [DataMember()]
        /// <summary>
        /// Тип передвижения.
        /// </summary>
        public MovementType MovementType { get; private set; }

        double health;
        [DataMember()]
        /// <summary>
        /// Здоровье.
        /// </summary>
        public double Health
        {
            get => health;
            private set {
                if (value < healthMin || value > healthMax)
                    throw new CreatureException($"Недопустимое здоровье: {value}");
                health = value;
            }
        }

        /// <summary>
        /// Конструктор, задающий имя, тип и здоровье.
        /// </summary>
        public Creature(string name, MovementType movementType, double health)
        {
            Name = name;
            MovementType = movementType;
            Health = health;
        }

        public Creature() { }

        /// <summary>
        /// Переопределенный ToString.
        /// </summary>
        public override string ToString()
        {
            return $"{MovementType} creature {Name}: Health = {Health:F3}";
        }

        /// <summary>
        /// Перегруженный оператор умножения.
        /// Имена склеиваются, здоровье - среднее арифметическое.
        /// Выбрасывает ArgumentException если типы существ не совпадают.
        /// </summary>
        public static Creature operator *(Creature first, Creature second)
        {
            if (first.MovementType != second.MovementType)
                throw new ArgumentException("Типы родителей не совпадают.");

            string maxName = first.Name.Length < second.Name.Length ? second.Name : first.Name;
            string minName = second.Name.Length > first.Name.Length ? first.Name : second.Name;
            string name =
                maxName.Substring(0, (int)Math.Ceiling(maxName.Length / 2.0))
                + minName.Substring((int)Math.Ceiling(minName.Length / 2.0));

            return new Creature(name, first.MovementType, (first.Health + second.Health) / 2);
        }

        /// <summary>
        /// Переопределено для тестов.
        /// </summary>
        public override bool Equals(object obj)
        {
            var other = obj as Creature;
            return Name.Equals(other.Name)
                && Health.Equals(other.Health)
                && MovementType.Equals(other.MovementType);
        }
    }
}
