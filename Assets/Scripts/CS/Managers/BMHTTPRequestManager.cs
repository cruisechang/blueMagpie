using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class BMHTTPRequestManager : MonoBehaviour,IBMManager
{

	private Dictionary<string,BMHTTPRequestOption> requestTable = new Dictionary<string,BMHTTPRequestOption> ();

	//private static BMHttpRequestManager instance ;


	private BMHTTPRequestManager ()
	{
		
	}

	void Awake ()
	{
		//instance = this;

	}
	void Start ()
	{
	}

	/*
	internal static BMHttpRequestManager GetInstance (GameObject go)
	{
		if (instance = null)
			instance = go.AddComponent< BMHttpRequestManager > ();
		return instance;
	}
	*/


	/// <summary>
	/// Registers the request route.
	/// Registers every routes of requests.
	/// For example "/login?" for LoginRequest.
	/// Use typeof(LoginRequest).Name to be key.
	/// </summary>
	internal void RegisterRequest (string className, BMHTTPRequestOption data)
	{
		requestTable [className] = data;
	}

	/// <summary>
	/// Sends the post request.
	/// Callback after yield.
	/// </summary>
	/// <param name="url">URL.</param>
	/// <param name="deviceID">Device I.</param>
	/// <param name="callback">Callback.</param>
	internal void SendRequestByCallback (string hostString, BaseHTTPRequest request, System.Action<BMEventData> callback)
	{
		Debug.Log (request.GetType ().Name);

		BMHTTPRequestOption rd = getRequestData (request.GetType ().Name);

		WWW www = new WWW (hostString + rd.PathName, request.GetWWWForm ());	
		StartCoroutine (requestByCallback (www, callback));
	}

	internal void SendRequestByEvent (string hostString, BaseHTTPRequest request,BMEventManager eventManager)
	{
		BMHTTPRequestOption rd = getRequestData (request.GetType ().Name);


		if (rd == null)
			return;

		WWW www = new WWW (hostString + rd.PathName, request.GetWWWForm ());


		StartCoroutine (requestByEvent (www, rd.EventType,eventManager));
	}

	/// <summary>
	/// Request coroutine. Requests the by callback.
	/// </summary>
	/// <returns>The by callback.</returns>
	/// <param name="www">Www.</param>
	/// <param name="callback">Callback.</param>
	private IEnumerator requestByCallback (WWW www, System.Action<BMEventData> callback)
	{
		yield return www;

		callback (new BMEventData (www));

	}

	/// <summary>
	/// Request coroutine. Requests the by broadcast.
	/// </summary>
	/// <returns>The by broadcast.</returns>
	/// <param name="www">Www.</param>
	private IEnumerator requestByEvent (WWW www, BMEvent eventType,BMEventManager manager)
	{
		yield return www;
		manager.DispatchEvent<BMEventData> (eventType,new BMEventData(www));

	}


	private BMHTTPRequestOption getRequestData (string className)
	{
		try {
			return requestTable [className];
		} catch (Exception e) {
			Debug.Log (e.Message);
			return null;
		}
	}

}

