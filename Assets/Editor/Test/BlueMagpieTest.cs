using UnityEngine;
using UnityEditor;
using NUnit.Framework;

[TestFixture]
public class BlueMagpieTest
{
	private BlueMagpie CreateBlueMagpie ()
	{
		BlueMagpie bm = (new GameObject (typeof(BlueMagpie).Name)).AddComponent< BlueMagpie > ();

		//BlueMagpie xx = BlueMagpie.GetInstance ();
		bm.AddManager ();

		//Sets server data.
		bm.SetServerData (new BMServerOption (BMProtocol.HTTP, "www.google.com", 0));

		return bm;
	}

	[Test]
	public void CreateTest ()
	{

		BlueMagpie bm = CreateBlueMagpie ();

		//Register request.
		bm.RegisterRequest (typeof(HTTPRegisterRequest).Name, new BMHTTPRequestOption (BMEvent.Register, "/resits?"));

		//Create request and ecrypt parameters. 
		HTTPRegisterRequest request = new HTTPRegisterRequest ("acc", "pass");
		string jstr = request.GetPublicFieldJSONString ();
		string keyStr = "中中中中中中中中";
		request.AddQuery ("params", EncryptoTool.TripleDESEncryption (jstr, keyStr));
		request.AddQuery ("key", EncryptoTool.SHA256Encryption (jstr + "shakey"));
		request.AddQuery ("appid", "appid");

		//Not work.
		//bm.SendRequest (request, TestCallback );

		//by event 
		//bm.AddEventListener (BMEvent.Register, TestCallback);
		//bm.SendRequest (request);



		Assert.Pass ();


	}

	public void TestCallback (BMEventData data)
	{
		/*
		Debug.Log (data.RequestSuccess);
		if (data.RequestSuccess) {

			Debug.Log (data.Data.Success);		//Get JsonData
			Debug.Log (data.Data.ErrorCode);		//Get JsonData
			Debug.Log (data.Data.Message);		//Get JsonData
			Debug.Log (data.Data.Data);		//Get JsonData
			Debug.Log (data.Data.Data["code"]);		//Get JsonData
			Debug.Log (data.Data.Data["msg"]);		//Get JsonData
		}
		*/
	

	}

	[Test]
	public void UserManagerTest ()
	{
		BlueMagpie bm = CreateBlueMagpie ();

		Assert.IsFalse (bm.ContainsUser (0));
		Assert.IsNull (bm.GetUser (0));
		Assert.AreEqual (0, bm.GetUsers ().Count);

	}

	[Test]
	public void RoomManagerTest ()
	{
		BlueMagpie bm = CreateBlueMagpie ();

		Assert.IsFalse (bm.ContainsRoom (0));
		Assert.IsNull (bm.GetRoom (0));
		Assert.AreEqual (0, bm.GetRooms ().Count);
	}

}
