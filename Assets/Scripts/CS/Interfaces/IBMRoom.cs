using System.Collections.Generic;

public interface IBMRoom 
{

	bool ContainsVariable (string name);

	BMRoomVariable GetVariable (string name);

	//Sets variable. Returns true if success,false if failure.
	bool SetVariable (string name, BMRoomVariable variable);

	bool RemoveVariable (string name);

	Dictionary<string,BMRoomVariable> GetVariables ();
}

