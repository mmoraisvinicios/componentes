using Newtonsoft.Json;

namespace Patterns.Contracts.Response.Entities
{
    public class Error
    {
        [JsonProperty("codigo")]
        public string Code { get; set; }

        [JsonProperty("mensagem")]
        public string Message { get; set; }
    }
}
