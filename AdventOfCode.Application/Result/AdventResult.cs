namespace AdventOfCode.Application.Result;

public class AdventResult<T>
{
    public bool IsSuccess { get; }
    public bool IsError => !IsSuccess;

    private readonly T? _Value;
    public T? Value => _Value;

    private readonly AdventError? _Error;
    public AdventError? Error => _Error;

    public AdventResult(T result)
    {
        IsSuccess = true;
        _Value = result;
        _Error = default;
    }

    public AdventResult(AdventError error)
    {
        IsSuccess = false;
        _Value = default;
        _Error = error;
    }

    public static AdventResult<T> Success(T result)
    {
        return new AdventResult<T>(result);
    }

    public static AdventResult<T> Failure(AdventError error)
    {
        return new AdventResult<T>(error);
    }
}
