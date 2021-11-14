namespace Sample.Shared.Models.Wrappers
{
    public class Result : IResult
    {
        public string Message { get; set; }
        public bool Succeded { get; set; }

        public static IResult Fail(string message)
        {
            return new Result { Succeded = false, Message = message };
        }

        public static IResult Successs(string message)
        {
            return new Result { Succeded = true, Message = message };
        }
    }

    public class Result<T> : Result, IResult<T>
    {
        public T Data { get; set; }

        public static Result<T> Success(T data)
        {
            return new Result<T> { Succeded = true, Data = data };
        }
    }
}
