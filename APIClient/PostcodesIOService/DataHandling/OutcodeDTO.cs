using Newtonsoft.Json;

namespace APIClient.PostcodesIOService
{
	public class OutcodeDTO
	{
		public OutcodeResponse OutcodeResponse { get; set; }

		public void DeserializeResponse(string outcodeResponse)
		{
			OutcodeResponse = JsonConvert.DeserializeObject<OutcodeResponse>(outcodeResponse);
		}
	}
}
