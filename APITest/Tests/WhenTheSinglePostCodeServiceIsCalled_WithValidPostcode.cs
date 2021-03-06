﻿using System.Threading.Tasks;
using APIClient.PostcodesIOService;
using NUnit.Framework;

namespace APITest.Tests
{
	public class WhenTheSinglePostCodeServiceIsCalled_WithValidPostcode
	{
		private SinglePostCodeService _spcs = new SinglePostCodeService();

		[OneTimeSetUp]
		public async Task OneTimeSetUpAsync()
		{
			await _spcs.MakeRequest("EC2Y 5AS");
		}

		[Test]
		public void StatusIs200()
		{
			Assert.That(_spcs.Json_Response["status"].ToString(), Is.EqualTo("200"));
		}

		[Test]
		public void ObjectStatusIs200()
		{
			Assert.That(_spcs.SinglePostcodeDTO.PostcodeResponse.status, Is.EqualTo(200));
		}

		[Test]
		public void AdminDistrict_IsCityOfLondon()
		{
			Assert.That(_spcs.SinglePostcodeDTO.PostcodeResponse.result.admin_district, Is.EqualTo("City of London"));
		}

		[Test]
		public void NumberOfCodes_IsCorrect()
		{
			Assert.That(_spcs.CodeCount(), Is.EqualTo(12));
		}
	}
}