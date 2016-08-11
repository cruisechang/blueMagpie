using System;
using UnityEngine;

public class HTTPLoginRequest : BaseHTTPRequest,IBMRequest
{
	public string account;
	public string password;
	public int gameID;
	public int clientKind;

	public HTTPLoginRequest (string account, string password,int gameID,int clientKind)
	{
		this.account = account;
		this.password = password;
		this.gameID = gameID;
		this.clientKind = clientKind;
	}
}
