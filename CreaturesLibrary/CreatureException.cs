using System;

namespace CreaturesLibrary
{
    /// <summary>
    /// Класс исключений для существ.
    /// </summary>
    [Serializable]
    public class CreatureException : Exception
    {
        public CreatureException() { }
        public CreatureException(string message) : base(message) { }
        public CreatureException(string message, Exception inner) : base(message, inner) { }
        protected CreatureException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
