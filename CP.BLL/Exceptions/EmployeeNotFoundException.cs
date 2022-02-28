using System.Runtime.Serialization;

namespace CP.BLL.Exceptions
{
    [Serializable]
    public class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException()
        {
        }

        public EmployeeNotFoundException(string message) : base(message)
        {
        }

        public EmployeeNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmployeeNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
