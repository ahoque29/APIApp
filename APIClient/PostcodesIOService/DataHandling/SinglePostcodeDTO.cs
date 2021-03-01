using Newtonsoft.Json;

namespace APIClient.PostcodesIOService
{
	public class SinglePostcodeDTO
	{
		public SinglePostcodeResponse PostcodeResponse { get; set; }

		public void DeserializeResponse(string postcodeResponse)
		{
			PostcodeResponse = JsonConvert.DeserializeObject<SinglePostcodeResponse>(postcodeResponse);
		}
	}
}
