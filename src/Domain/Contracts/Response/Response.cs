using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Patterns.Contracts.Response.Entities
{
    public class Response : IResponse
    {
        internal List<Error> _error = new List<Error>();
        public IReadOnlyList<Error> Erros => _error;
        public bool Success { get { return !Erros.Any(); } }

        public Response() { }

        public Response Result() => this;

        public Response<T> Result<T>(T obj) => new Response<T>(obj, _error);

        public void AddError(Error error) =>
            _error.Add(error);

        public void AddError(string jsonMessage)
            => AddError(JsonConvert.DeserializeObject<Error>(jsonMessage));

        public void AddError(string code, string message) =>
            AddError(new Error() { Code = code, Message = message });

        public void AddError<T>(string jsonMessage) =>
             AddError(JsonConvert.DeserializeObject<Error>(jsonMessage));
    }

    public class Response<T> : Response
    {
        public T Objeto { get; set; }

        public Response()
        { }

        public Response(T @object, List<Error> error)
        {
            Objeto = @object;
            _error = error;
        }

        public Response(T @object)
        {
            Objeto = @object;
        }
    }
}
