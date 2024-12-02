namespace AdventOfCode.Application.Result;

public class AdventError
{    public int ErrorCode { get; }
    public string ErrorMessage { get; }
    public Exception? Exception { get; }

    public AdventError(int errorCode, string errorMessage, Exception? exception = null)
    {
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
        Exception = exception;
    }
}
