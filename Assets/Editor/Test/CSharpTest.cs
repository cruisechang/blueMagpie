using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections.Generic;
using System;
namespace CSharpTest
{
	[TestFixture]
	public class CSharpTest
	{

		[Test]
		public void TestDictionary ()
		{
			Dictionary<string,string> routeData = new Dictionary<string,string> ();

			routeData.Add ("a", "a");

			routeData ["a"] = "b";

			Assert.AreEqual (routeData ["a"], "b");
		}

		[Test]
		public void TestStringComparision ()
		{
			string comStr = String.Empty;

			Assert.That (comStr==String.Empty);
			Assert.That (comStr.Equals(String.Empty));
			Assert.That (comStr.Equals(""));
		}

	}
}