namespace Sample.Shared.Models.Wrappers
{
    public interface IResult
    {
        string Message { get; set; }
        bool Succeded { get; set; }
    }

    public interface IResult<out T> : IResult
    {
        T Data { get; }
    }
}
