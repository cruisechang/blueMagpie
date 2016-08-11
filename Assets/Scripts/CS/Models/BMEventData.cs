using UnityEngine;
using System.Collections;
using LitJson;

/// <summary>
/// Event data.
/// </summary>
public class BMEventData
{
	//Request success or failure. Not this command success or failure.
	private bool requestSuccess = true;
	private string requestMessage = "";
	//If request success, this contains response contents.
	private ResponseData data;


	/// <summary>
	/// Initializes a new instance of the <see cref="EventData"/> class.
	/// </summary>
	/// <param name="www">Www.</param>
	public BMEventData (WWW www)
	{
		init (www);
	}

	public bool RequestSuccess { 
		get { return requestSuccess; } 
	}

	public string RequestMessage { 
		get { return requestMessage; } 
	}
	/// <summary>
	/// Gets the data.
	/// </summary>
	/// <returns>The data.</returns>
	/// 
	public ResponseData Data { 
		get { return data; }
	}

	private void init (WWW www)
	{
		
		if (www.error != null) {
			requestSuccess = false;
			requestMessage = www.error;
			data = new ResponseData (false, 1, "Request failure.", LitJSONTool.JSONStringToJSONData (""));
			//errorCode = 1;
			//message = www.error;
		} else {
			requestSuccess = true;
			data = new ResponseData (true, 0, "Request success.", LitJSONTool.JSONStringToJSONData (www.text));
		}
	}

	/// <summary>
	/// Response data. Inner class for json data.
	/// </summary>
	public  class ResponseData
	{
		//Indicates whether this event is success.
		public bool Success = true;

		//Error code 0 means success, others means failure.
		public int ErrorCode = 0;

		//Message
		public string Message = "Success.";

		//LitJson data if this event is success.
		public LitJson.JsonData Data = null;

		public ResponseData (bool success, int errCode, string msg, JsonData data)
		{
			this.Success = success;

			this.ErrorCode = errCode;

			this.Message = msg;

			this.Data = data;
		}
	}

}





