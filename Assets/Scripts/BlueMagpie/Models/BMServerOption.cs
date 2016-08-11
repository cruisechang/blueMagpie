using UnityEngine;
using System;

public class BMServerOption 
{
	//Conntion protocol.
	private BMProtocol protocol = BMProtocol.None;
	private string hostName = String.Empty;
	private int port = 0;

	public BMServerOption(BMProtocol protocol,string hostName,int port)
	{
		this.protocol = protocol;
		this.hostName = hostName;
		this.port = port;
	}

	public string GetHostString()
	{
		string resStr = "";
		if (protocol == BMProtocol.HTTP) {
			resStr += "http://" + hostName;
		} else {
			resStr += "https://" + hostName;
		}
		if (port > 0) {
			resStr += ":" + Convert.ToString (port);
		}
		return resStr;
	}
}

