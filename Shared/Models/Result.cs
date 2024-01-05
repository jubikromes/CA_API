namespace Shared.Models;

public class Result
{
    public bool IsSuccessful { get; set; }
    public string Code { get; set; }

    protected Result() { }

    public static Result Success(string message = null)
    {
        return new Result()
        {
            IsSuccessful = true,
            Code = "200",
        };
    }

    public static Result Failure(string code = null, string message = null)
    {
        return new Result()
        {
            Code = code,
        };

    }
}

public class Result<T> : Result
{
    public new T Data { get; set; }

    public static Result<T> Success(T data, string code = null)
    {
        return new Result<T>()
        {
            IsSuccessful = true,
            Code = code ?? "200",
            Data = data,
        };
    }
    public static Result<T> Failure(T data, string code = null)
    {
        return new Result<T>()
        {
            IsSuccessful = false,
            Code = code ?? "303",
            Data = data,
        };
    }
}
