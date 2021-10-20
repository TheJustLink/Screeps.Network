using Newtonsoft.Json;

namespace ScreepsNetworkAPI.API.User
{
    public class NameResponse : Response
    {
        [JsonProperty("username")]
        public readonly string Username;
    }
}