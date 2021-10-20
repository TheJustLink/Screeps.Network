using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using ScreepsNetworkAPI.JsonConverters;

namespace ScreepsNetworkAPI.API.Auth
{
    public class AccountResponse : Response
    {
        [JsonProperty("_id")]
        public readonly string Id;

        [JsonProperty("email")]
        public readonly string Email;

        [JsonProperty("username")]
        public readonly string Username;

        [JsonProperty("cpu")]
        public readonly int CPU;

        [JsonProperty("password")]
        public readonly bool HasPassword;

        [JsonProperty("lastRespawnDate")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public readonly DateTime LastRespawnDate;

        [JsonProperty("gcl")]
        public readonly int GCL;

        [JsonProperty("credits")]
        public readonly int Credits;

        [JsonProperty("money")]
        public readonly double Money;

        [JsonProperty("subscriptionTokens")]
        public readonly int SubscriptionTokens;

        [JsonProperty("cpuShard")]
        public readonly Dictionary<string, int> CPUShards;

        [JsonProperty("resources")]
        public readonly Dictionary<string, int> Resources;
    }
}