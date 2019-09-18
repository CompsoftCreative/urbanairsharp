// Copyright (c) 2014-2015 Jeff Gosling (jeffery.gosling@gmail.com)

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UrbanAirSharp.Type;

namespace UrbanAirSharp.Dto
{
	/// <summary>
	/// Used to form a PUSH request
	/// Send a push notification to a specified device or list of devices
	/// 
	/// audience - Required
	/// notification - Required
	/// device_types - Required
	/// 
	/// options - optionally specify an expiry date
	/// actions - TODO not supported yet 
	/// message - RICH PUSH message - TODO not supported yet
	/// 
	/// http://docs.urbanairship.com/reference/api/v3/push.html
	/// </summary>
	public class Push
	{
		[JsonProperty("notification")]
		public Notification Notification { get; set; }

        [JsonConverter(typeof(AudienceConverter))]
        [JsonProperty("audience")]
		public Audience Audience { get; set; }

        [JsonConverter(typeof(DeviceTypeConverter))]
		[JsonProperty("device_types")]
		public IList<DeviceType> DeviceTypes { get; set; }

		[JsonProperty("options")]
		public Options Options { get; set; }

		//TODO: not implemented yet
		[JsonProperty("actions")]
		public Actions Actions { get; private set; }

		//TODO: not implemented yet
		[JsonProperty("message")]
		public RichMessage RichMessage { get; private set; }

		public void SetAudience(AudienceType audienceType, String value)
		{
			Audience = new Audience(audienceType, value);
		}
	}
}
