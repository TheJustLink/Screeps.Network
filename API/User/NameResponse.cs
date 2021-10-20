using Newtonsoft.Json;

namespace Screeps.Network.API.User
{
    public class NameResponse : Response
    {
        [JsonProperty("username")]
        public readonly string Username;
    }
}