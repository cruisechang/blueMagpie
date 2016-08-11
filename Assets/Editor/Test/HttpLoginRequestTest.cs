using System;
using NUnit.Framework;

[TestFixture]
public class HttpLoginRequestTest {

	[Test]
	public void TestHttpLoginRequest()
	{
		string account = "account";
		string password = "pass";
	
	
		HTTPLoginRequest lr = new HTTPLoginRequest (account,password,0,0);

		Assert.IsNotNull (lr);
	}
}
