
public interface IBMUserVariable
{
	string Name{ get; }

	bool GetBoolValue ();

	double GetDoubleValue ();

	string GetStringValue ();

	int GetIntValue ();

	bool IsNull ();
}

