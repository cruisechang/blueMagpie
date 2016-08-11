using UnityEngine;
using System.Collections;

public class HTTPJoinGameRequest : BaseHTTPRequest,IBMRequest
{
	public int gameID;
	public int zoneID;
	public int tableID;

	public HTTPJoinGameRequest (int gameID, int zoneID, int tableID)
	{
		this.gameID = gameID;
		this.zoneID = zoneID;
		this.tableID = tableID;
	}
}

