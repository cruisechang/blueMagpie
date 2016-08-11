using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StringTool
{
	/// <summary>
	/// 把字串中的數字改成英文字，傳回新字串
	/// </summary>
	/// <param name="targetStr"></param>
	/// <param name="isUpper">是否改成大寫</param>
	/// <returns></returns>
	public static string DigitStringToChar (string targetStr, bool isUpper)
	{
		int length = targetStr.Length;

		//建立新字串
		int i;
		string resStr = "";
		for (i = 0; i < length; i++) {
			resStr += digitToString (targetStr.Substring (i, 1), isUpper);
		}
		return isUpper ? resStr.ToUpper () : resStr;
	}

	private static string digitToString (string s, bool isUpper)
	{
		switch (s) {
		case "0":
			return isUpper ? "O" : "o";
		case "1":
			return isUpper ? "B" : "b";
		case "2":
			return isUpper ? "C" : "c";
		case "3":
			return isUpper ? "D" : "d";
		case "4":
			return isUpper ? "S" : "s";
		case "5":
			return isUpper ? "F" : "f";
		case "6":
			return isUpper ? "X" : "x";
		case "7":
			return isUpper ? "H" : "h";
		case "8":
			return isUpper ? "Y" : "y";
		case "9":
			return isUpper ? "J" : "j";
		default:
			return s;
		}
	}
}
