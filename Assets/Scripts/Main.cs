using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

/// <summary>
/// This is a C/S 
/// </summary>
public class Main : MonoBehaviour
{

	// Use this for initialization
	void Awake ()
	{

	}

	/// <summary>
	/// Start this instance.
	/// Do not delete this method.
	/// </summary>
	void Start ()
	{

		//Gets BlueMaqpie instance.
		//BlueMagpie bm = BlueMagpie.GetInstance ();
		BlueMagpie bm=new GameObject().AddComponent<BlueMagpie>();

	

		//Add manager.
		bm.AddManager ();

		//Sets server data.
		bm.SetServerData (new BMServerOption (BMProtocol.HTTP, "47.89.43.167", 9794));



		//Register request.
		bm.RegisterRequest (typeof(HTTPLoginRequest).Name, new BMHTTPRequestOption (BMEvent.Login, "www.google.com"));

		//Create register request and ecrypt parameters. 
		HTTPLoginRequest request = new HTTPLoginRequest ("account", "12345678901234567890123456789012",1,1);
		string jstr = request.GetPublicFieldJSONString ();
		string keyStr = "qwertyui12345678";
		string shakey="qazwsx";
		string encStr= EncryptoTool.TripleDESEncryption (jstr, keyStr);
		request.AddQuery ("params", encStr);
		request.AddQuery ("key", EncryptoTool.SHA256Encryption (encStr + shakey));

		Debug.Log (" HTTPLoginRequest params:"+jstr);

		//by callback with EventData parameter
		bm.SendRequest (request, SampleRegisterCallback);

		//by event 
		//bm.AddEventListener (BMEvent.Register, SampleCallback);
		//bm.SendRequest (request);


		//If you want bm don't be destroied.
		//DontDestroyOnLoad (bm);	
		//bm.DontDestroyObject ();

	
	}

	private void SampleRegisterCallback (BMEventData data)
	{

		Debug.Log ("== SampleRegisterCallback");
		Debug.Log (data.RequestSuccess);
		if (data.RequestSuccess) {
			
			Debug.Log (data.Data.Success);		
			Debug.Log (data.Data.ErrorCode);		
			Debug.Log (data.Data.Message);		
			Debug.Log (data.Data.Data);				//Get JsonData
			Debug.Log (data.Data.Data ["code"]);	//Get JsonData
			Debug.Log (data.Data.Data ["msg"]);		//Get JsonData
		} else {
			Debug.Log (data.RequestMessage);	
		}
	}

	private void SampleCallback (BMEventData data)
	{

		Debug.Log ("== SampleCallback");
		if (data.RequestSuccess) {

			Debug.Log (data.Data.Success);		
			Debug.Log (data.Data.ErrorCode);		
			Debug.Log (data.Data.Message);		
			Debug.Log (data.Data.Data);		
		}
	}

	private void UserInfoCallback (BMEventData data)
	{

		Debug.Log ("== UserInfoCallback");
		Debug.Log (data.RequestSuccess);
		if (data.RequestSuccess) {

			Debug.Log (data.Data.Success);		
			Debug.Log (data.Data.ErrorCode);	
			Debug.Log (data.Data.Message);		
			Debug.Log (data.Data.Data);		
			Debug.Log (data.Data.Data["code"]);		
			Debug.Log (data.Data.Data["msg"]);		
		}
	}
}
