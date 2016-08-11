
public class HTTPUserInfoRequest : BaseHTTPRequest,IBMRequest {

	public string account;
	public string sid;

	public HTTPUserInfoRequest (string sid, string account)
	{
		this.sid = sid;
		this.account = account;
	}

}
