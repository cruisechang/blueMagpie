
/// <summary>
/// BM event is enum for events definition.
/// </summary>
public enum BMEvent
{
	//None.
	None,

	//Dispatched after sending HttpRegisterRequest.
	Register,

	//Dispatched after sending HttpLoginRequest.
	Login,

	//Dispatched after sending HttpLogoutRequest.
	Logout,

	//Dispatched after sending HttpCreateGameRequest.
	CreateGame,

	UserInfo
}

