namespace Template.Core.Exceptions;

public class CoreException : Exception
{
    public int Code { get; init; }
    public CoreException( ExceptionCode error ) : base(error.Message)
    {
        Code = error.Code;
    }

    public CoreException( ExceptionCode error, Exception? innerException ) : base(error.Message, innerException)
    {
        Code = error.Code;
    }
}