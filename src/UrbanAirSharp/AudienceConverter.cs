using Newtonsoft.Json;
using UrbanAirSharp.Dto;

namespace UrbanAirSharp
{
    public class AudienceConverter : JsonConverter<Audience>
    {
        public override Audience ReadJson(JsonReader reader, System.Type objectType, Audience existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (JsonToken.String.Equals(reader.TokenType) &&
                "all".Equals(reader.Value?.ToString()))
            {
                return Audience.All;
            }
            var serialiserSettings = new JsonSerializerSettings
            {
                NullValueHandling = serializer.NullValueHandling
            };
            var defaultSerialiser = JsonSerializer.CreateDefault(serialiserSettings);
            return defaultSerialiser.Deserialize(reader, objectType) as Audience;
        }

        public override void WriteJson(JsonWriter writer, Audience value, JsonSerializer serializer)
        {
            if (value.IsAll())
            {
                serializer.Serialize(writer, "all");
            }
            else
            {
                var serialiserSettings = new JsonSerializerSettings
                {
                    NullValueHandling = serializer.NullValueHandling
                };
                var defaultSerialiser = JsonSerializer.CreateDefault(serialiserSettings);
                defaultSerialiser.Serialize(writer, value);
            }
        }
    }
}
