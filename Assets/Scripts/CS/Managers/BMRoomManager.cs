using System.Collections.Generic;

internal class BMRoomManager : IBMManager,IBMRoomManager
{

	private  Dictionary<int,BMRoom> roomTable = new Dictionary<int,BMRoom> ();


	private static BMRoomManager instance;

	private BMRoomManager ()	{}

	internal static BMRoomManager GetInstance ()
	{
		if (instance == null)
			instance = new BMRoomManager ();
		return instance;
	}


	public bool ContainsRoom (int ID)
	{
		return roomTable.ContainsKey (ID);
	}


	public BMRoom GetRoom (int ID)
	{
		if (roomTable.ContainsKey (ID)) {
			return roomTable [ID];
		}
		return null;
	}


	public Dictionary<int,BMRoom> GetRooms ()
	{
		return roomTable;
	}
}

