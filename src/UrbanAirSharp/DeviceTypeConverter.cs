using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UrbanAirSharp.Type;

namespace UrbanAirSharp
{
    public class DeviceTypeConverter : JsonConverter<IList<DeviceType>>
    {
        public override IList<DeviceType> ReadJson(JsonReader reader, System.Type objectType, IList<DeviceType> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (JsonToken.String.Equals(reader.TokenType) &&
                "all".Equals(reader.Value?.ToString()))
            {
                return null;
            }
            var serialiserSettings = new JsonSerializerSettings
            {
                NullValueHandling = serializer.NullValueHandling
            };
            var defaultSerialiser = JsonSerializer.CreateDefault(serialiserSettings);
            return defaultSerialiser.Deserialize(reader, objectType) as IList<DeviceType>;
        }

        public override void WriteJson(JsonWriter writer, IList<DeviceType> value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
