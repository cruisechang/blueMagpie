using System;

public class HTTPCreateGameRequest : BaseHTTPRequest,IBMRequest
{
	public int gameID;
	public int zoneID;
	public int tableID;

	public HTTPCreateGameRequest (int gameID, int zoneID, int tableID)
	{
		this.gameID = gameID;
		this.zoneID = zoneID;
		this.tableID = tableID;
	}
}

