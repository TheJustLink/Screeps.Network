using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using Screeps.Network.JsonConverters;

namespace Screeps.Network.API.Auth;

public class AccountResponse : Response
{
    [JsonProperty("_id")]
    public string Id;
        
    public string Email;
    public string Username;
        
    public int CPU;
        
    [JsonProperty("password")]
    public bool HasPassword;
        
    [System.Text.Json.Serialization.JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime LastRespawnDate;
        
    public int GCL;
    public int Credits;
    public double Money;
    public int SubscriptionTokens;

    [JsonProperty("cpuShard")]
    public Dictionary<string, int> CPUShards;
    public Dictionary<string, int> Resources;
}