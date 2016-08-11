using System;
using System.Collections.Generic;
using System.Collections;
using LitJson;

/// <summary>
/// LitJson tool
/// litJson dll is needed.
/// http://lbv.github.io/litjson/
/// </summary>
public class LitJSONTool
{
	/// <summary>
	/// JSON strig to JSON data.
	/// </summary>
	/// <returns>The strig to JSON data.</returns>
	/// <param name="jsonStr">Json string.</param>
	public static LitJson.JsonData JSONStringToJSONData (string jsonStr)
	{
		return  JsonMapper.ToObject (jsonStr);
	}

	/// <summary>
	/// JSONS data to JSON string.
	/// </summary>
	/// <returns>The data to JSON string.</returns>
	/// <param name="jsonData">Json data.</param>
	public static string JSONSDataToJSONString (JsonData jsonData)
	{
		return jsonData.ToJson ();
	}

	/// <summary>
	/// Json string to class,
	/// Class field must be public.
	/// Class field must match json element.
	/// </summary>
	/// <typeparam name="T">Generic type</typeparam>
	/// <param name="jsonStr"></param>
	/// <returns></returns>
	public static T JsonStringToClass<T> (string jsonStr)
	{
		return JsonMapper.ToObject<T> (jsonStr);
	}

	/// <summary>
	/// Classe to json string.
	/// </summary>
	/// <returns>The to json string.</returns>
	/// <param name="clazz">Clazz.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static string ClassToJsonString<T> (T clazz)
	{
		return JsonMapper.ToJson (clazz);
	}

	public static string GetStringValue (JsonData jd, string targetKey)
	{
		ICollection<string> keys = jd.Keys;
		foreach (string k in keys) {
			if (k == targetKey) {
				if (jd [targetKey].IsString) {
					return (string)jd [targetKey];
				}
			}
		}
		throw new System.Exception ("Value not found.");
	}

	public static int GetIntValue (JsonData jd, string targetKey)
	{
		ICollection<string> keys = jd.Keys;
		foreach (string k in keys) {
			if (k == targetKey) {
				if (jd [targetKey].IsInt) {
					return (int)jd [targetKey];
				}
			}
		}
		throw new System.Exception ("Value not found.");
	}

	public static bool GetBoolValue (JsonData jd, string targetKey)
	{
		ICollection<string> keys = jd.Keys;
		foreach (string k in keys) {
			if (k == targetKey) {
				if (jd [targetKey].IsBoolean) {
					return (bool)jd [targetKey];
				}
			}
		}
		throw new System.Exception ("Value not found.");
	}

	public static double GetDoubleValue (JsonData jd, string targetKey)
	{
		ICollection<string> keys = jd.Keys;
		foreach (string k in keys) {
			if (k == targetKey) {
				if (jd [targetKey].IsDouble) {
					return (double)jd [targetKey];
				}
			}
		}
		throw new System.Exception ("Value not found.");
	}

	public static string GetStringValue (JsonData jd, string targetKey1, string targetKey2)
	{
		try {
			return (string)jd [targetKey1] [targetKey2];
		} catch (Exception e) {
			Console.Write (e.Message);
			throw new System.Exception ("Value not found.");
		}
	}
	public static int GetIntValue (JsonData jd, string targetKey1, string targetKey2)
	{
		try {
			return (int)jd [targetKey1] [targetKey2];
		} catch (Exception e) {
			Console.Write (e.Message);
			throw new System.Exception ("Value not found.");
		}
	}
	public static bool GetBoolValue (JsonData jd, string targetKey1, string targetKey2)
	{
		try {
			return (bool)jd [targetKey1] [targetKey2];
		} catch (Exception e) {
			Console.Write (e.Message);
			throw new System.Exception ("Value not found.");
		}
	}
	public static double GetDoubleValue (JsonData jd, string targetKey1, string targetKey2)
	{
		try {
			return (double)jd [targetKey1] [targetKey2];
		} catch (Exception e) {
			Console.Write (e.Message);
			throw new System.Exception ("Value not found.");
		}
	}
	/// Error Object must implement IConvertible.
	/// <summary>
	/// Gets the value from JsonData.
	/// </summary>
	/// <returns>The value.</returns>
	/// <param name="jd">Jd.</param>
	/// <param name="key">Key.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>

	public static T GetValue<T> (JsonData jd, string targetKey)
	{
		ICollection<string> keys = jd.Keys;
		foreach (string k in keys) {
			if (k == targetKey) {
				return (T)Convert.ChangeType (jd [targetKey], typeof(T));
			}
		}
		return (T)Convert.ChangeType (null, typeof(T));
	}


	/// Error Object must implement IConvertible.
	/// <summary>
	/// Gets the value from 2 dimensions json data.
	/// </summary>
	/// <returns>The value.</returns>
	/// <param name="jd">Jd.</param>
	/// <param name="targetKey1">Target key1.</param>
	/// <param name="targetKey2">Target key2.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>

	public static T GetValue<T> (JsonData jd, string targetKey1, string targetKey2)
	{
		try {
			return (T)Convert.ChangeType (jd [targetKey1] [targetKey2], typeof(T));
		} catch (Exception e) {
			Console.Write (e.Message);
			return (T)Convert.ChangeType (null, typeof(T));
		}
	}

}
