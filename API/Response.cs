using Newtonsoft.Json;

namespace ScreepsNetworkAPI.API
{
    public class Response
    {
        [JsonProperty("ok")]
        public readonly bool OK;

        [JsonProperty("error")]
        public readonly string Error;
    }
}