using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace APIClient.PostcodesIOService
{
	public class OutwardCodeService
	{
		#region Properties

		// Reference to the new CallManager
		public CallManager CallManager { get; set; }

		// A NewtonSoft object representing the json response
		public JObject Json_Response { get; set; }

		// an object model ofthe response
		public OutcodeDTO OutcodeDTO { get; set; }

		// the outcode used in the API request
		public string OutcodeSelected { get; set; }

		// The response content as a string
		public string OutcodeResponse { get; set; }

		#endregion

		public OutwardCodeService()
		{
			CallManager = new CallManager();
			OutcodeDTO = new OutcodeDTO();
		}

		/// <summary>
		/// Defines and makes the PI request, and stores the response.
		/// </summary>
		/// <param name="outcode"></param>
		/// <returns></returns>
		public async Task MakeRequest(string outcode)
		{
			OutcodeSelected = outcode;

			// Make the request
			OutcodeResponse = await CallManager.MakeOutcodeRequest(outcode);

			// Parse it into a json object
			Json_Response = JObject.Parse(OutcodeResponse);

			// Parse Json into an object tree
			OutcodeDTO.DeserializeResponse(OutcodeResponse);
		}
	}
}