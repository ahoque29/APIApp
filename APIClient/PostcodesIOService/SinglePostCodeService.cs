using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIClient.PostcodesIOService
{
	public class SinglePostCodeService
	{
		#region Properties

		// Reference to the new CallManager
		public CallManager CallManager { get; set; }

		// A NewtonSoft object representing the json response
		public JObject Json_Response { get; set; }

		// An object model of the response
		public SinglePostcodeDTO SinglePostcodeDTO { get; set; }

		// The postcode used in this API request
		public string PostcodeSelected { get; set; }

		// The response content as a string
		public string PostcodeResponse { get; set; }

		#endregion

		public SinglePostCodeService()
		{
			CallManager = new CallManager();
			SinglePostcodeDTO = new SinglePostcodeDTO();
		}


		/// <summary>
		/// Defines and makes the API request, and stores the response.
		/// </summary>
		/// <param name="postcode"></param>
		public async Task MakeRequest(string postcode)
		{
			PostcodeSelected = postcode;


			// Make the request
			PostcodeResponse = await CallManager.MakePostcodeRequest(postcode);

			// Parse it into a json object
			Json_Response = JObject.Parse(PostcodeResponse);

			// Parse Json into an object tree
			SinglePostcodeDTO.DeserializeResponse(PostcodeResponse);
		}

		/// <summary>
		/// Counts the number of codes the API returns
		/// </summary>
		/// <returns></returns>
		public int CodeCount()
		{
			var count = 0;
			foreach (var code in Json_Response["result"]["codes"])
			{
				count++;
			}

			return count;
		}

	}
}