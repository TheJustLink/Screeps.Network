using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Screeps.Network.API.User
{
    public class CodeRequest
    {
        [JsonProperty("branch")]
        public readonly string Branch;

        [JsonProperty("modules")]
        public readonly Dictionary<string, string> Modules;

        [JsonProperty("_hash")]
        public readonly long Hash;

        public CodeRequest(string branch, Dictionary<string, string> modules)
        {
            Branch = branch;
            Modules = modules;
            Hash = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }
    }
}