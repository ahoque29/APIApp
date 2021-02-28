using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using APIClient;

namespace APITest.Tests
{
	public class WhenTheSinglePostCodeServiceIsCalled_WithValidPostcode
	{
		SinglePostCodeService _spcs = new SinglePostCodeService();

		public WhenTheSinglePostCodeServiceIsCalled_WithValidPostcode()
		{
			_spcs.MakeRequest("EC2Y 5AS");
		}

		[Test]
		public void StatusIs200()
		{
			Assert.That(_spcs.ResponseContent["status"].ToString(), Is.EqualTo("200"));
		}
	}
}
