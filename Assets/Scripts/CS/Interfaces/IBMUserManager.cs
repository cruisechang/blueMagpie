using System.Collections.Generic;

public interface IBMUserManager
{
	bool ContainsUser (int userID);


	BMUser GetUser (int userID);


	Dictionary<int,BMUser> GetUsers();

}

