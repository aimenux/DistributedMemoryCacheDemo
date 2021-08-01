using System;
using System.Runtime.Serialization;

namespace Domain.Exceptions
{
    public class BusinessException : ApplicationException
    {
        protected BusinessException()
        {
        }

        protected BusinessException(string message) : base(message)
        {
        }

        protected BusinessException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BusinessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
