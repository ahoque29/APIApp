using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace APIClient
{
	public class SinglePostCodeService
	{
		#region Properties

		//RestSharp object which handles communication with the API
		public RestClient Client { get; set; }

		// a NewtonSoft object representing the json response
		public JObject ResponseContent { get; set; }

		// an object model of the response
		public SinglePostcodeResponse ResponseObject { get; set; }

		// the postcode used in this API request
		public string PostcodeSelected { get; set; }

		#endregion

		public SinglePostCodeService()
		{
			Client = new RestClient
			{
				BaseUrl = new Uri(AppConfigReader.BaseUrl)
			};
		}

		/// <summary>
		/// Defines and makes the API request, and stores the response.
		/// </summary>
		/// <param name="postcode"></param>
		public async Task MakeRequest(string postcode)
		{
			// Set up the request
			var request = new RestRequest();
			request.AddHeader("Content-Type", "application/json");
			PostcodeSelected = postcode;

			// Define request resource path
			// Changing to lower case
			// Removing and whitespace
			request.Resource = $"postcodes/{postcode.ToLower().Replace(" ", "")}";

			// Make the request
			IRestResponse response = await Client.ExecuteAsync(request);

			// Parse it into a json object
			ResponseContent = JObject.Parse(response.Content);

			// Parse Json into an object tree
			ResponseObject = JsonConvert.DeserializeObject<SinglePostcodeResponse>(response.Content);
		}
	}
}
