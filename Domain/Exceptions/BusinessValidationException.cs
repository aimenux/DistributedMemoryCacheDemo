using System;

namespace Domain.Exceptions;

public class BusinessValidationException : BusinessException
{
    protected BusinessValidationException()
    {
    }

    protected BusinessValidationException(string message) : base(message)
    {
    }

    protected BusinessValidationException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static BusinessValidationException UrlIsBlackListed(string url)
    {
        var exception = new BusinessValidationException($"Url {url} is blacklisted.");
        return exception;
    }
}