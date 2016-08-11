using System.Collections;

public class BMUserVariable :IBMUserVariable
{
	private object value = null;

	public BMUserVariable (string name, string value)
	{
		this.value = value;
	}

	public BMUserVariable (string name, bool value)
	{
		this.value = value;
	}

	public BMUserVariable (string name, double value)
	{
		this.value = value;
	}

	public BMUserVariable (string name, int value)
	{
		this.value = value;
	}

	public string Name {
		get { return Name; } 
	}

	public bool IsNull ()
	{
		if (value == null)
			return true;
		return false;
	}


	public bool GetBoolValue ()
	{
		return (bool)value;
	}

	public double GetDoubleValue ()
	{
		return (double)value;
	}

	public string GetStringValue ()
	{
		return (string)value;
	}

	public int GetIntValue ()
	{
		return (int)value;
	}


}

