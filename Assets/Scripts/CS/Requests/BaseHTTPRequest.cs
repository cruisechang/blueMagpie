using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class BaseHTTPRequest
{
	protected Dictionary<string,string> queryParametersString = new Dictionary<string,string> ();
	protected Dictionary<string,int> queryParametersInt = new Dictionary<string,int> ();

	internal BaseHTTPRequest ()
	{
		
	}

	public void AddQuery (string queryName, string value)
	{
		queryParametersString [queryName] = value;
	}
	public void AddQuery (string queryName, int value)
	{
		queryParametersInt [queryName] = value;
	}
	public string GetQueryString ()
	{
		string resStr = String.Empty;
		if (queryParametersString.Count > 0) {
			resStr = "?";

			foreach (KeyValuePair<string,string> kvp in queryParametersString) {
				resStr += kvp.Key + "=" + kvp.Value;
			}
		}

		if (queryParametersInt.Count > 0) {
			foreach (KeyValuePair<string,int> kvp in queryParametersInt) {
				resStr += kvp.Key + "=" + kvp.Value;
			}
		}

		return resStr;
	}
	public WWWForm GetWWWForm()
	{
		WWWForm form = new WWWForm ();

		if (queryParametersString.Count > 0) {
			foreach (KeyValuePair<string,string> kvp in queryParametersString) {
				form.AddField (kvp.Key, kvp.Value);
			}
		}


		if (queryParametersInt.Count > 0) {
			foreach (KeyValuePair<string,int> kvp in queryParametersInt) {
				form.AddField (kvp.Key, kvp.Value);
			}
		}
		return form;

	}
	/// <summary>
	/// Gets the public field JSON string.
	/// Serialize public fields into JSON string and return it.
	/// Public fields only,public consts are not included.
	/// </summary>
	/// <returns>The public field JSON string.</returns>
	public string GetPublicFieldJSONString ()
	{
		return JsonUtility.ToJson (this);
	}
		
}

