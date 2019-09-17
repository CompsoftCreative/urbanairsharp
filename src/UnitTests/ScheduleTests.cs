using Newtonsoft.Json;
using System;
using UrbanAirSharp.Dto;
using UrbanAirSharp.Response;
using Xunit;

namespace UnitTests
{
    public class ScheduleTests
    {
        [Fact]
        public void DeserialisationTest1()
        {
            var contentJson = "{\"ok\":true,\"operation_id\":\"cf8dc65d-9049-45ce-a4c9-668d21662552\",\"schedule_urls\":[\"https://go.urbanairship.com/api/schedules/cf8dc65d-9049-45ce-a4c9-668d21662552\"],\"schedule_ids\":[\"cf8dc65d-9049-45ce-a4c9-668d21662552\"],\"schedules\":[{\"url\":\"https://go.urbanairship.com/api/schedules/cf8dc65d-9049-45ce-a4c9-668d21662552\",\"schedule\":{\"scheduled_time\":\"2019-09-17T10:02:00\"},\"push\":{\"audience\":{\"named_user\":\"cf8dc65d-9049-45ce-a4c9-668d21662552\"},\"device_types\":[\"ios\",\"android\"],\"notification\":{\"alert\":\"cf8dc65d-9049-45ce-a4c9-668d21662552\",\"ios\":{\"alert\":\"cf8dc65d-9049-45ce-a4c9-668d21662552\",\"badge\":\"auto\",\"content_available\":true,\"expiry\":3600,\"priority\":10,\"extra\":{\"Type\":\"NewMessageNotification\",\"Id\":\"168029\"}},\"android\":{\"alert\":\"cf8dc65d-9049-45ce-a4c9-668d21662552\",\"time_to_live\":3600,\"delay_while_idle\":true,\"extra\":{\"Id\":\"168029\",\"Type\":\"NewMessageNotification\"}}}},\"push_ids\":[\"cf8dc65d-9049-45ce-a4c9-668d21662552\"]}]}";
            var actual = JsonConvert.DeserializeObject<ScheduleCreateResponse>(contentJson);
            Assert.Null(actual.Error);
            Assert.Equal(0, actual.ErrorCode);
            Assert.Null(actual.Message);
            Assert.True(actual.Ok);
            Assert.Equal(new Guid("cf8dc65d-9049-45ce-a4c9-668d21662552"), actual.OperationId);
            Assert.Single(actual.Schedules);
            Assert.Single(actual.ScheduleUrls);
        }

        [Fact]
        public void DeserialisationTest2()
        {
            var contentJson = "{ \"url\": \"https://go.urbanairship.com/api/schedules/cf8dc65d-9049-45ce-a4c9-668d21662552\", \"schedule\": { \"scheduled_time\": \"2019-09-17T10:02:00\" }, \"push\": { \"audience\": { \"named_user\": \"cf8dc65d-9049-45ce-a4c9-668d21662552\" }, \"device_types\": [ \"ios\", \"android\" ], \"notification\": { \"alert\": \"cf8dc65d-9049-45ce-a4c9-668d21662552\", \"ios\": { \"alert\": \"cf8dc65d-9049-45ce-a4c9-668d21662552\", \"badge\": \"auto\", \"content_available\": true, \"expiry\": 3600, \"priority\": 10, \"extra\": { \"Type\": \"NewMessageNotification\", \"Id\": \"168029\" } }, \"android\": { \"alert\": \"cf8dc65d-9049-45ce-a4c9-668d21662552\", \"time_to_live\": 3600, \"delay_while_idle\": true, \"extra\": { \"Id\": \"168029\", \"Type\": \"NewMessageNotification\" } } } }, \"push_ids\": [ \"cf8dc65d-9049-45ce-a4c9-668d21662552\" ] }";
            var actual = JsonConvert.DeserializeObject<Schedule>(contentJson);
            Assert.Null(actual.Name);
            Assert.Equal("https://go.urbanairship.com/api/schedules/cf8dc65d-9049-45ce-a4c9-668d21662552", actual.Url);
        }
    }
}
