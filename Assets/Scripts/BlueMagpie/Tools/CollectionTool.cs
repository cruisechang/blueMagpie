using System;
using System.Collections.Generic;

public static class CollectionTool
{

	//Sets dictionary value using the provided value. If a value already exists,
	//uses the lambda function provided to compute the new value.
	/// <summary>
	/// Updates value or set.
	/// Sets dictionary value using the provided value. If a value already exists,
	//  uses the lambda function provided to compute the new value.
	/// </summary>
	/// <param name="dict">Dict.</param>
	/// <param name="key">Key.</param>
	/// <param name="value">Value.</param>
	/// <param name="operation">Operation.</param>
	/// <typeparam name="K">The 1st type parameter.</typeparam>
	/// <typeparam name="V">The 2nd type parameter.</typeparam>
	public static void UpdateOrSet<K, V> (this Dictionary<K, V> dict, K key, V value, Func<V, V,V> operation)
	{
		V currentValue;
		if (dict.TryGetValue (key, out currentValue))
			dict [key] = operation (currentValue, value);
		else
			dict [key] = value;
	}
}
