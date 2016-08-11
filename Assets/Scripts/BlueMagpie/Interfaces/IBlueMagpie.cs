using System.Collections.Generic;

public interface IBlueMagpie
{
	void SetServerData (BMServerOption sd);

	void DontDestroyObject();

	void RegisterRequest (string className, BMHTTPRequestOption data);

	void AddEventListener (BMEvent eventType, BMEventCallback handler);

	void AddEventListener (BMEvent eventType, BMEventCallback <BMEventData>handler);

	void RemoveEventListener (BMEvent eventType, BMEventCallback handler);

	void RemoveEventListener (BMEvent eventType, BMEventCallback <BMEventData>handler);

	void SendRequest (BaseHTTPRequest request, System.Action<BMEventData> callback);

	void SendRequest (BaseHTTPRequest request);

	bool ContainsUser (int ID);

	BMUser GetUser (int ID);

	Dictionary<int,BMUser> GetUsers ();

	bool ContainsRoom (int ID);

	BMRoom GetRoom (int ID);

	Dictionary<int,BMRoom> GetRooms ();
}

