using Newtonsoft.Json;

namespace RunpathApi.Data
{
    public class ErrorMessage
    {
        [JsonProperty("error")]
        public string Message { get; set; }
    }
}
