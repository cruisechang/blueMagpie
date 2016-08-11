using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class BlueMagpie : MonoBehaviour,IBlueMagpie
{
	private string version = "1.0.0";
	private Dictionary<string ,IBMManager> managerTable = new Dictionary<string,IBMManager> ();
	private BMServerOption serverOption = null;
	private static BlueMagpie instance;

	private BlueMagpie ()
	{
	}

	void Awake ()
	{
		instance = this;

	}

	void Start ()
	{
	}

	public static BlueMagpie GetInstance ()
	{
		return instance;
	}

	/// <summary>
	/// Gets the version.
	/// </summary>
	/// <value>The version.</value>
	public string Version {
		get{ return version; }
	}

	/// <summary>
	/// Adds the manager.
	/// Must after all game object Awake and Start.
	/// </summary>
	public void AddManager ()
	{
		managerTable.Add (typeof(BMHTTPRequestManager).Name, (new GameObject (typeof(BMHTTPRequestManager).Name)).AddComponent< BMHTTPRequestManager > ());
		managerTable.Add (typeof(BMEventManager).Name, BMEventManager.GetInstance ());
		managerTable.Add (typeof(BMUserManager).Name, BMUserManager.GetInstance ());
		managerTable.Add (typeof(BMRoomManager).Name, BMRoomManager.GetInstance ());
	}

	private IBMManager getManager (string typeofManagerName)
	{
		return managerTable [typeofManagerName];
	}

	/// <summary>
	/// Donts the destroy object. If you want inner gameObject don't be destroied.
	/// 
	/// </summary>
	public void DontDestroyObject()
	{
		BMHTTPRequestManager m = getManager (typeof(BMHTTPRequestManager).Name) as BMHTTPRequestManager;
		DontDestroyOnLoad (m.gameObject);
	}
	///
	/// <summary>
	/// Sets the server data.
	/// Sets data before start send request.
	/// Sets protocol ,hostName and port.
	/// Just hostName, "http://" is not needed.
	/// </summary>
	/// <param name="prococol">Protocol for connection.</param>
	/// <param name="hostName">Server host name.</param>
	/// <param name="port">Server port.</param>
	public void SetServerData (BMServerOption sd)
	{
		this.serverOption = sd;
	}

	/// <summary>
	/// Registers the request.
	/// </summary>
	/// <param name="className">Class name.</param>
	/// <param name="data">Data.</param>
	public void RegisterRequest (string className, BMHTTPRequestOption data)
	{
		Debug.Log (className);
		BMHTTPRequestManager m = getManager (typeof(BMHTTPRequestManager).Name) as BMHTTPRequestManager;
		m.RegisterRequest (className, data);
	}

	/// <summary>
	/// Adds the event listener.
	/// </summary>
	/// <param name="eventType">Event type.</param>
	/// <param name="handler">Handler.</param>
	public void AddEventListener (BMEvent eventType, BMEventCallback handler)
	{
		BMEventManager m = getManager (typeof(BMEventManager).Name) as BMEventManager;
		m.AddListener (eventType, handler);
	}

	/// <summary>
	/// Adds the event listener .
	/// Callback with EventData parameter.
	/// </summary>
	/// <param name="eventType">Event type.</param>
	/// <param name="handler">Handler.</param>
	public void AddEventListener (BMEvent eventType, BMEventCallback <BMEventData>handler)
	{
		BMEventManager m = getManager (typeof(BMEventManager).Name) as BMEventManager;
		m.AddListener <BMEventData> (eventType, handler);
	}

	/// <summary>
	/// Removes the event listener.
	/// </summary>
	/// <param name="eventType">Event type.</param>
	/// <param name="handler">Handler.</param>
	public void RemoveEventListener (BMEvent eventType, BMEventCallback handler)
	{
		BMEventManager m = getManager (typeof(BMEventManager).Name) as BMEventManager;
		m.RemoveListener (eventType, handler);
	}

	/// <summary>
	/// Removes the event listener.
	/// Callback with EventData parameter.
	/// </summary>
	/// <param name="eventType">Event type.</param>
	/// <param name="handler">Handler.</param>
	public void RemoveEventListener (BMEvent eventType, BMEventCallback <BMEventData>handler)
	{
		BMEventManager m = getManager (typeof(BMEventManager).Name) as BMEventManager;
		m.RemoveListener <BMEventData> (eventType, handler);
	}

	/// <summary>
	/// Send the specified request and callback.
	/// </summary>
	/// <param name="request">Request.</param>
	/// <param name="callback">Callback.</param>
	public void SendRequest (BaseHTTPRequest request, System.Action<BMEventData> callback)
	{
		BMHTTPRequestManager m = getManager (typeof(BMHTTPRequestManager).Name) as BMHTTPRequestManager;
		m.SendRequestByCallback (serverOption.GetHostString (), request, callback);
	}

	/// <summary>
	/// Send the specified request and dispatch relative event.
	/// </summary>
	/// <param name="request">Request.</param>
	public void SendRequest (BaseHTTPRequest request)
	{
		BMHTTPRequestManager m = getManager (typeof(BMHTTPRequestManager).Name) as BMHTTPRequestManager;
		BMEventManager em = getManager (typeof(BMEventManager).Name) as BMEventManager;
		m.SendRequestByEvent (serverOption.GetHostString (), request, em);
	}
	//**************************************
	//**** User manager
	/// <summary>
	/// Contains the user. Check if conatains target user.
	/// </summary>
	/// <returns><c>true</c>, if user was containsed, <c>false</c> otherwise.</returns>
	/// <param name="userID">User I.</param>
	public bool ContainsUser (int userID)
	{

		return (getManager (typeof(BMUserManager).Name) as BMUserManager).ContainsUser (userID);
	}

	/// <summary>
	/// Gets the user.
	/// </summary>
	/// <returns>The user.</returns>
	/// <param name="userID">User I.</param>
	public BMUser GetUser (int userID)
	{
		return (getManager (typeof(BMUserManager).Name) as BMUserManager).GetUser (userID);

	}

	/// <summary>
	/// Gets the users.
	/// </summary>
	/// <returns>The users.</returns>
	public Dictionary<int,BMUser> GetUsers ()
	{
		return (getManager (typeof(BMUserManager).Name) as BMUserManager).GetUsers ();
	}

	//**************************************
	//**** Room manager
	/// <summary>
	/// Contains the room. Check if contains the target room.
	/// </summary>
	/// <returns><c>true</c>, if room was containsed, <c>false</c> otherwise.</returns>
	/// <param name="ID">I.</param>
	public bool ContainsRoom (int ID)
	{

		return (getManager (typeof(BMRoomManager).Name) as BMRoomManager).ContainsRoom (ID);
	}

	/// <summary>
	/// Gets the room.
	/// </summary>
	/// <returns>The room.</returns>
	/// <param name="ID">I.</param>
	public BMRoom GetRoom (int ID)
	{
		return (getManager (typeof(BMRoomManager).Name) as BMRoomManager).GetRoom (ID);

	}

	/// <summary>
	/// Gets the rooms.
	/// </summary>
	/// <returns>The rooms.</returns>
	public Dictionary<int,BMRoom> GetRooms ()
	{
		return (getManager (typeof(BMRoomManager).Name) as BMRoomManager).GetRooms ();
	}

}
