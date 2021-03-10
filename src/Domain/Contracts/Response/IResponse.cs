namespace Patterns.Contracts.Response.Entities
{
    public interface IResponse
    {
        Response Result();
        Response<T> Result<T>(T obj);
        void AddError<Error>(string jsonMessage);
        void AddError(string code, string message);
        void AddError(Error error);
    }
}
