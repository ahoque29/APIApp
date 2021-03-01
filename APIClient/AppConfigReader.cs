using System.Configuration;

namespace APIClient
{
	public static class AppConfigReader
	{
		public static readonly string BaseUrl = ConfigurationManager.AppSettings["base_url"];
	}
}