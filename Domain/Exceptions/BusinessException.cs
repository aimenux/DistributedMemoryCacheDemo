using System;

namespace Domain.Exceptions;

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
}