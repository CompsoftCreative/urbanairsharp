using Newtonsoft.Json;
using System.Collections.Generic;
using UrbanAirSharp;
using UrbanAirSharp.Dto;
using UrbanAirSharp.Type;
using Xunit;

namespace UnitTests
{
    public class DeviceTypeTests
    {
        [Fact]
        public void DeserialisationTest1()
        {
            var contentJson = "[\"ios\",\"android\"]";
            var actual = JsonConvert.DeserializeObject<IList<DeviceType>>(contentJson, new DeviceTypeConverter());
            Assert.Contains(DeviceType.Android, actual);
            Assert.Contains(DeviceType.Ios, actual);
            Assert.DoesNotContain(DeviceType.Mpns, actual);
        }

        [Fact]
        public void DeserialisationTest2()
        {
            var contentJson = "\"all\"";
            var actual = JsonConvert.DeserializeObject<IList<DeviceType>>(contentJson, new DeviceTypeConverter());
            Assert.Null(actual);
        }

        [Fact]
        public void SerialisationTest1()
        {
            IList<DeviceType> deviceTypes = new[] { DeviceType.All };
            var contentJson = JsonConvert.SerializeObject(deviceTypes, new DeviceTypeConverter());
            Assert.Equal("\"all\"", contentJson);
        }

        [Fact]
        public void SerialisationTest2()
        {
            var deviceTypes = new[] { DeviceType.Android, DeviceType.Ios };
            var contentJson = JsonConvert.SerializeObject(deviceTypes, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore, Converters = new[] { new DeviceTypeConverter() } });
            Assert.Equal("[\"android\",\"ios\"]", contentJson);
        }
    }
}
