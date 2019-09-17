// Copyright (c) 2014-2015 Jeff Gosling (jeffery.gosling@gmail.com)
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UrbanAirSharp.Response;


namespace UrbanAirSharp.Request.Base
{
	public abstract class BaseRequest<TResponse> where TResponse : BaseResponse, new()
	{
		protected HttpClient HttpClient;
		protected JsonSerializerSettings SerializerSettings;
		protected String Host;
		protected String RequestUrl;
		protected HttpMethod RequestMethod;


		protected BaseRequest(String host, HttpClient httpClient, JsonSerializerSettings serializerSettings)
		{
			Host = host;
			HttpClient = httpClient;
			SerializerSettings = serializerSettings;

			if (!Host.EndsWith("/"))
			{
				Host += "/";
			}
		}

		public virtual async Task<TResponse> ExecuteAsync()
		{
			return null;
		}

		protected async Task<TResponse> DeserializeResponseAsync(HttpResponseMessage response)
		{
			var contentJson = await response.Content.ReadAsStringAsync();

			TResponse result;

			try
			{
				result = JsonConvert.DeserializeObject<TResponse>(contentJson);
			}
			catch (Exception e)
			{
                //Some calls to Urban Airship don't return with valid JSON :(
                result = new TResponse
                {
                    Message = $"{e} {contentJson}"
				};
			}

			if (result == null)
			{
				result = new TResponse();
			}

			if (String.IsNullOrEmpty(result.Message))
			{
				result.Message = response.ReasonPhrase;
			}

			result.HttpResponseCode = response.StatusCode;

			if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Accepted ||
					response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.NoContent)
			{
				result.Ok = true;
			}

			result.OnDeserialised();

			return result;
		}
	}
}
