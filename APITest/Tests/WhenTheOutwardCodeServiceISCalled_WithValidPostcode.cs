using System.Threading.Tasks;
using APIClient;
using NUnit.Framework;
using APIClient.PostcodesIOService;

namespace APITest.Tests
{
	public class WhenTheOutwardCodeServiceISCalled_WithValidPostcode
	{
		private OutwardCodeService _ocs = new OutwardCodeService();

		[OneTimeSetUp]
		public async Task OneTimeSetUpAsync()
		{
			await _ocs.MakeRequest("EC2Y");
		}

		[Test]
		public void StatusIs200()
		{
			Assert.That(_ocs.OutcodeResponseObject.status, Is.EqualTo(200));
		}

		[Test]
		public void Outcode_IsEC2Y()
		{
			Assert.That(_ocs.OutcodeResponseObject.result.outcode, Is.EqualTo("EC2Y"));
		}

		[Test]
		public void AdminDistrict_IsIslingtonAndCityOfLondon()
		{
			Assert.That(_ocs.OutcodeResponseObject.result.admin_district, Is.EqualTo(new string[] { "Islington", "City of London" }));
		}

		[Test]
		public void AdminDistrict_IsLengthTwo()
		{
			Assert.That(_ocs.OutcodeResponseObject.result.admin_district.Length, Is.EqualTo(2));
		}
	}
}