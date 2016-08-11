using UnityEngine;
using NUnit.Framework;
using LitJson;
using System;
using System.Collections.Generic;

namespace ToolTest
{
	[TestFixture]
	public class ToolsTest
	{
		[Test]
		public void TestSHA256 ()
		{
			string testStr1 = "testStr1";
			string testStr2 = "testStr2";
			string str11 = EncryptoTool.SHA256Encryption (testStr1);
			string str12 = EncryptoTool.SHA256Encryption (testStr1);
			string str2 = EncryptoTool.SHA256Encryption (testStr2);

			Assert.AreEqual (str11, str12);
			Assert.AreNotEqual (str11, str2);

		}

		[Test]
		public void TestLitJSONGetValue ()
		{
			string json = "{ 'strkey':'str','intkey':10,'boolkey':false,'doublekey':2.3,'nested':{ 'strkey':'str','intkey':10,'boolkey':false,'doublekey':2.3} }";

			JsonData jd = LitJSONTool.JSONStringToJSONData (json);

			string sValue =	LitJSONTool.GetStringValue (jd, "strkey");
			int iValue =	LitJSONTool.GetIntValue (jd, "intkey");
			bool bValue =	LitJSONTool.GetBoolValue (jd, "boolkey");
			double dValue =	LitJSONTool.GetDoubleValue (jd, "doublekey");

			Assert.AreEqual ("str", sValue);
			Assert.AreEqual (10, iValue);
			Assert.AreEqual (false, bValue);
			Assert.AreEqual (2.3, dValue);

			sValue = LitJSONTool.GetStringValue (jd, "nested", "strkey");
			iValue = LitJSONTool.GetIntValue (jd, "nested", "intkey");
			bValue = LitJSONTool.GetBoolValue (jd, "nested", "boolkey");
			dValue = LitJSONTool.GetDoubleValue (jd, "nested", "doublekey");


			Assert.AreEqual ("str", sValue);
			Assert.AreEqual (10, iValue);
			Assert.AreEqual (false, bValue);
			Assert.AreEqual (2.3, dValue);

		}

		[Test]
		[ExpectedException (typeof(System.Exception), ExpectedMessage = "Value not found.")]
		public void TestLitJSONGetValueException ()
		{
			string json = "{ 'strkey':'str','intkey':10,'boolkey':false,'doublekey':2.3,'nested':{ 'strkey':'str','intkey':10,'boolkey':false,'doublekey':2.3} }";

			JsonData jd = LitJSONTool.JSONStringToJSONData (json);

			//Methods with error parameter will throw exception.
			LitJSONTool.GetStringValue (jd, "strkey_");
			LitJSONTool.GetIntValue (jd, "intkey_");
			LitJSONTool.GetBoolValue (jd, "boolkey_");
			LitJSONTool.GetDoubleValue (jd, "doublekey_");

			LitJSONTool.GetStringValue (jd, "nested", "strkey_");
			LitJSONTool.GetIntValue (jd, "nested", "intkey_");
			LitJSONTool.GetBoolValue (jd, "nested", "boolkey_");
			LitJSONTool.GetDoubleValue (jd, "nested", "doublekey_");

		}

		[Test]
		public void Test3Des ()
		{
			string originalStr = "targetStr";
			string keyStr = "中中中中中中中中";

			string encryptStr = EncryptoTool.TripleDESEncryption (originalStr, keyStr);
			string decryptStr = EncryptoTool.TripleDESDecryption (encryptStr, keyStr);

			Assert.AreEqual (originalStr, decryptStr);
		}

		[Test]
		public void TestUpdateOrSet ()
		{
			Dictionary<string,int> intDict = new Dictionary<string,int> ();
			intDict ["key"] = 10;

			CollectionTool.UpdateOrSet (intDict,"key",10,(x,y)=>x+y);

			Assert.AreEqual (20,intDict["key"]);

			Dictionary<string,string> strDict = new Dictionary<string,string> ();
			strDict ["key"] = "10";

			CollectionTool.UpdateOrSet(strDict,"key", "10", (x, y) => x + "," + y);
			Assert.AreEqual ("10,10",strDict["key"]);

			//myLists.UpdateOrSet("Animals", (List<T>) Dogs, (x, y) => x.AddRange(y));
		}
	}

}

