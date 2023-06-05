using System;

using Newtonsoft.Json;

using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Screeps.Network.JsonConverters
{
    class UnixDateTimeConverter : JsonConverter<DateTime>
    {
        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return DateTime.UnixEpoch.AddMilliseconds((long)reader.Value);
        }
    }
}