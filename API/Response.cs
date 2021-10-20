using Newtonsoft.Json;

namespace Screeps.Network.API
{
    public class Response
    {
        [JsonProperty("ok")]
        public readonly bool OK;

        [JsonProperty("error")]
        public readonly string Error;
    }
}