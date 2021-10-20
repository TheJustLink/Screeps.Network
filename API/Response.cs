using Newtonsoft.Json;

namespace ScreepsNetAPI.API
{
    public class Response
    {
        [JsonProperty("ok")]
        public readonly bool OK;

        [JsonProperty("error")]
        public readonly string Error;
    }
}