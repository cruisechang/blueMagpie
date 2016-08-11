using System;
using System.Collections.Generic;

public class BMUser :IBMUser
{
	private Dictionary<string,BMUserVariable> variableTable = new Dictionary<string,BMUserVariable> ();
	private int id;
	private string name;

	public BMUser (int id, string name)
	{
		this.id = id;
		this.name = name;
	}

	/// <summary>
	/// Gets the ID.
	/// </summary>
	/// <value>The I.</value>
	public int ID {
		get{ return id; }
	}

	/// <summary>
	/// Gets the name.
	/// </summary>
	/// <value>The name.</value>
	public string Name {
		get{ return name; }
	}

	/// <summary>
	/// Contains the variable.
	/// </summary>
	/// <returns><c>true</c>, if variable was contained, <c>false</c> otherwise.</returns>
	/// <param name="variableName">Variable name.</param>
	public bool ContainsVariable (string variableName)
	{
		return variableTable.ContainsKey (variableName);
	}

	/// <summary>
	/// Gets the variable.
	/// </summary>
	/// <returns>The variable.</returns>
	/// <param name="variableName">Variable name.</param>
	public BMUserVariable GetVariable (string variableName)
	{
		if (variableTable.ContainsKey (variableName)) {
			return 	variableTable [variableName];
		}

		return null;
	}

	/// <summary>
	/// Sets the variable. Set value to null will remove target varialbe.
	/// </summary>
	/// <returns><c>true</c>, if variable was set, <c>false</c> otherwise.</returns>
	/// <param name="variableName">Variable name.</param>
	/// <param name="variable">Variable.</param>
	public bool SetVariable (string variableName, BMUserVariable variable)
	{
		try {
			if (variable == null && variableTable.ContainsKey (variableName)) {
				variableTable.Remove (variableName);
			}

			variableTable [variableName] = variable;
			return true;

		} catch (Exception e) {
			Console.Write (e.Message);
			return false;
		}
	}

	/// <summary>
	/// Removes the variable.
	/// </summary>
	/// <returns><c>true</c>, if variable was removed, <c>false</c> otherwise.</returns>
	/// <param name="variableName">Variable name.</param>
	public bool RemoveVariable (string variableName)
	{
		return variableTable.Remove (variableName);
	}

	/// <summary>
	/// Gets the variables.
	/// </summary>
	/// <returns>The variables.</returns>
	public Dictionary<string,BMUserVariable> GetVariables ()
	{
		return variableTable;
	}
}

