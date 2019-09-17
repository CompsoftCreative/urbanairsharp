using Newtonsoft.Json;
using UrbanAirSharp.Dto;
using Xunit;

namespace UnitTests
{
    public class AudienceTests
    {
        [Fact]
        public void DeserialisationTest1()
        {
            var contentJson = "{ \"named_user\": \"1008009\" }";
            var actual = JsonConvert.DeserializeObject<Audience>(contentJson);
            Assert.Equal("1008009", actual.NamedUser);
            Assert.Null(actual.IosDeviceId);
            Assert.Null(actual.Not);
            Assert.False(actual.IsAll());
        }

        [Fact]
        public void DeserialisationTest2()
        {
            var contentJson = "\"all\"";
            var actual = JsonConvert.DeserializeObject<Audience>(contentJson);
            Assert.Null(actual.IosDeviceId);
            Assert.Null(actual.Not);
            Assert.True(actual.IsAll());
        }

        [Fact]
        public void SerialisationTest1()
        {
            var audience = Audience.All;
            var contentJson = JsonConvert.SerializeObject(audience);

        }
    }
}
