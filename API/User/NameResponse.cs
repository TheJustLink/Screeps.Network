using Newtonsoft.Json;

namespace ScreepsNetAPI.API.User
{
    public class NameResponse : Response
    {
        [JsonProperty("username")]
        public readonly string Username;
    }
}