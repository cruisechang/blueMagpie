using System.Collections.Generic;

public interface IBMRoomVariable 
{
	string Name{ get; }

	bool GetBoolValue ();

	double GetDoubleValue ();

	string GetStringValue ();

	int GetIntValue ();

	bool IsNull ();
}

