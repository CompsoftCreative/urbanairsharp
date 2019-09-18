using Newtonsoft.Json;
using UrbanAirSharp;
using UrbanAirSharp.Dto;
using Xunit;

namespace UnitTests
{
    public class AudienceTests
    {
        [Fact]
        public void DeserialisationTest1()
        {
            var contentJson = "{\"named_user\":\"Bob\"}";
            var actual = JsonConvert.DeserializeObject<Audience>(contentJson, new AudienceConverter());
            Assert.Equal("Bob", actual.NamedUser);
            Assert.Null(actual.IosDeviceId);
            Assert.Null(actual.Not);
            Assert.False(actual.IsAll());
        }

        [Fact]
        public void DeserialisationTest2()
        {
            var contentJson = "\"all\"";
            var actual = JsonConvert.DeserializeObject<Audience>(contentJson, new AudienceConverter());
            Assert.Null(actual.IosDeviceId);
            Assert.Null(actual.Not);
            Assert.True(actual.IsAll());
        }

        [Fact]
        public void SerialisationTest1()
        {
            var audience = Audience.All;
            var contentJson = JsonConvert.SerializeObject(audience, new AudienceConverter());
            Assert.Equal("\"all\"", contentJson);
        }

        [Fact]
        public void SerialisationTest2()
        {
            var audience = new Audience(UrbanAirSharp.Type.AudienceType.NamedUser, "Bob");
            var contentJson = JsonConvert.SerializeObject(audience, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore, Converters = new[] { new AudienceConverter() } });
            Assert.Equal("{\"named_user\":\"Bob\"}", contentJson);
        }
    }
}
