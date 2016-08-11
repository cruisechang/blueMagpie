using System;

public class HTTPRegisterRequest : BaseHTTPRequest,IBMRequest
{
	
	public string account;
	public string password;

	public HTTPRegisterRequest (string account, string password)
	{
		this.account = account;
		this.password = password;
	}
}

