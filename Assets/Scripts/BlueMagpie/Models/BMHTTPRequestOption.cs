
/// <summary>
/// HTTP request option used for registering a request.
/// </summary>
public sealed class BMHTTPRequestOption
{
	//Dispatch event type by this request.
	private BMEvent eventType;

	//The example 'http:   // user:pass@host.com:8080/p/a/t/h?query=string#hash' which '/p/a/t/h' is path name.
	private string pathName;

	public BMHTTPRequestOption (BMEvent eventType, string urlPathName)
	{
		this.eventType = eventType;
		this.pathName = urlPathName;
	}

	/// <summary>
	/// Gets the type of the event.
	/// </summary>
	/// <value>The type of the event.</value>
	public BMEvent EventType {
		get{ return eventType; }
	}

	/// <summary>
	/// Gets the path name.
	/// </summary>
	/// <value>The name of the path.</value>
	public string PathName {
		get{ return pathName; }
	}
}
