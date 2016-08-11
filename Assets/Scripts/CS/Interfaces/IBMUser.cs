using System.Collections.Generic;

public interface IBMUser
{

	bool ContainsVariable (string name);

	BMUserVariable GetVariable (string name);

	//Sets variable. Returns true if success,false if failure.
	bool SetVariable (string name, BMUserVariable variable);

	bool RemoveVariable (string name);

	Dictionary<string,BMUserVariable> GetVariables ();



}

