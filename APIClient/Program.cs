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
		}
	}
}
