using System.Runtime.Serialization;
namespace SkyProject.Exceptions;

public class EmployeeNotFoundExceptionException : Exception
{
    public EmployeeNotFoundExceptionException()
    {
    }

    public EmployeeNotFoundExceptionException(string? message) : base(message)
    {
    }

    public EmployeeNotFoundExceptionException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
    
}