using System.Collections;

public class BMRoomVariable : IBMRoomVariable
{

	private object value = null;

	public BMRoomVariable (string name, string value)
	{
		this.value = value;
	}

	public BMRoomVariable (string name, bool value)
	{
		this.value = value;
	}

	public BMRoomVariable (string name, double value)
	{
		this.value = value;
	}

	public BMRoomVariable (string name, int value)
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

