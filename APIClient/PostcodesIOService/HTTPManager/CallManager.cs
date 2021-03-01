using System;
using System.Threading.Tasks;
using RestSharp;

namespace APIClient.PostcodesIOService
{
	public class CallManager
	{
		readonly IRestClient _client;

		public CallManager()
		{
			_client = new RestClient
			{
				BaseUrl = new Uri(AppConfigReader.BaseUrl)
			};
		}

		/// <summary>
		/// Defines and makes a request for info on a single postcode and stores the response.
		/// </summary>
		/// <param name="postcode"></param>
		public async Task<string> MakePostcodeRequest(string postcode)
		{
			// Set up the request
			var request = new RestRequest();
			request.AddHeader("Content-Type", "application/json");

			// Define request resource path
			// Changing to lower case
			// Removing any whitespace
			request.Resource = $"postcodes/{postcode.ToLower().Replace(" ", "")}";

			// Make the request
			IRestResponse response = await _client.ExecuteAsync(request);

			return response.Content;
		}

		/// <summary>
		/// Defines and makes a request for info on an outward code and stores the response.
		/// </summary>
		/// <param name="outcode"></param>
		/// <returns></returns>
		public async Task<string> MakeOutcodeRequest(string outcode)
		{
			//Set up the request
			var request = new RestRequest();
			request.AddHeader("Content-Type", "application/json");

			// Define request resource path
			// Changing to lower case
			request.Resource = $"outcodes/{outcode.ToLower()}";

			// Make the request
			IRestResponse response = await _client.ExecuteAsync(request);

			return response.Content;
		}
	}
}
