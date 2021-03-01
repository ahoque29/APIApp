using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace APIClient
{
	public class OutwardCodeService
	{
		#region Properties

		//RestSharp object which handles communication with the API
		public RestClient Client { get; set; }

		// a NewtonSoft object representing the json response
		public JObject OutcodeResponeContent { get; set; }

		// an object model ofthe response
		public OutcodeResponse OutcodeResponseObject { get; set; }

		// the outcode used in the API request
		public string OutcodeSelected { get; set; }

		#endregion

		/// <summary>
		/// Defines and makes the PI request, and stores the response.
		/// </summary>
		/// <param name="outcode"></param>
		/// <returns></returns>
		public async Task MakeRequest(string outcode)
		{
			// Set up the request
			var request = new RestRequest();
			request.AddHeader("Content-Type", "application/json");

			// Define request resource path
			// Changing to lower case
			request.Resource = $"outcodes/{outcode.ToLower()}";

			// Make the request
			IRestResponse response = await Client.ExecuteAsync(request);

			// Parse it into a json object
			OutcodeResponeContent = JObject.Parse(response.Content);

			// Parse Json into an object tree
			OutcodeResponseObject = JsonConvert.DeserializeObject<OutcodeResponse>(response.Content);
		}

	}
}
