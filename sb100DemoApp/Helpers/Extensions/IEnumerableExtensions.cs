using System;
using System.Collections.Generic;

namespace sb100DemoApp
{
	public static class IEnumerableExtensions
	{
		public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
		{
			foreach (T item in enumeration)
			{
				action(item);
			}
		}
	}
}