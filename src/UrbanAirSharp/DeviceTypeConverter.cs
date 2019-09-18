using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
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
            if (value.Contains(DeviceType.All))
            {
                serializer.Serialize(writer, "all");
            }
            else
            {
                var serialiserSettings = new JsonSerializerSettings
                {
                    NullValueHandling = serializer.NullValueHandling
                };
                serialiserSettings.Converters.Add(new StringEnumConverter(typeof(DeviceTypeNamingStrategy)));
                var defaultSerialiser = JsonSerializer.CreateDefault(serialiserSettings);
                defaultSerialiser.Serialize(writer, value);
            }
        }

        private class DeviceTypeNamingStrategy : NamingStrategy
        {
            protected override string ResolvePropertyName(string name)
            {
                return name.ToLower();
            }
        }
    }
}
