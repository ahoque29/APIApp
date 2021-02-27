using System;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace APIClient
{
	public class Program
	{
		static void Main(string[] args)
		{
			var restClient = new RestClient("https://api.postcodes.io/");
			var restRequest = new RestRequest();

			// Configure the request
			restRequest.Method = Method.GET;
			restRequest.AddHeader("Content-Type", "application/json");
			restRequest.Timeout = -1;

			// Set up the resource specification
			var postcode = "EC2Y 5AS";
			restRequest.Resource = $"postcodes/{postcode.ToLower().Replace(" ", "")}";

			// Call the API
			var restResponse = restClient.Execute(restRequest);

			// Output the result
			Console.WriteLine("Response content (string)");
			Console.WriteLine(restResponse.Content);

			Console.WriteLine();

			// Code obtained from postman
			var client = new RestClient("https://api.postcodes.io/postcodes/EC2Y5AS");
			client.Timeout = -1;
			var request = new RestRequest(Method.GET);
			request.AddHeader("Content-Type", "application/json");
			request.AddHeader("Cookie", "__cfduid=d4ab2ca91e79a617295e1f864acd2bf461614162765");
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);
		}
	}
}
