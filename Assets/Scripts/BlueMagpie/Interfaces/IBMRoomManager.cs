using System.Collections.Generic;

public interface IBMRoomManager
{
	bool ContainsRoom (int ID);

	BMRoom GetRoom (int ID);

	Dictionary<int,BMRoom> GetRooms();
}

