using System.Collections.Generic;

internal class BMUserManager : IBMManager,IBMUserManager
{
	private  static Dictionary<int,BMUser> userTable = new Dictionary<int,BMUser> ();


	private static BMUserManager instance;

	private BMUserManager ()	{}

	internal static BMUserManager GetInstance ()
	{
		if (instance == null)
			instance = new BMUserManager ();
		return instance;
	}
	

	public bool ContainsUser (int userID)
	{
		return userTable.ContainsKey (userID);
	}


	public BMUser GetUser (int userID)
	{
		if (userTable.ContainsKey (userID)) {
			return userTable [userID];
		}
		return null;
	}


	public Dictionary<int,BMUser> GetUsers ()
	{
		return userTable;
	}
}

