using System.Runtime.Serialization;

namespace CP.BLL.Exceptions
{
    [Serializable]
    public class GuardClauseException : Exception
    {
        public GuardClauseException()
        {
        }

        public GuardClauseException(string message) : base(message)
        {
        }

        public GuardClauseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GuardClauseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
