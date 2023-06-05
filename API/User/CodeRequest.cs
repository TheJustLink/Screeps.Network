using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Screeps.Network.API.User
{
    public class CodeRequest
    {
        public string Branch;
        
        public Dictionary<string, string> Modules;

        [JsonProperty("_hash")]
        public long Hash;

        public CodeRequest(string branch, Dictionary<string, string> modules)
        {
            Branch = branch;
            Modules = modules;
            Hash = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }
    }
}