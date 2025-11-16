using System;
using System.Collections.Generic;
using System.Reflection;
using TheseusMarker.Attributes;

namespace TheseusMarker.Reporting
{
	public static class TheseusScanner
	{
		public static IEnumerable<TheseusEntry> ScanAll(Assembly assembly)
		{
			var entries = new List<TheseusEntry>();

			foreach (Type type in assembly.GetTypes())
			{
				var typeAttr = type.GetCustomAttribute(typeof(TheseusAttribute)) as TheseusAttribute;
				entries.Add(new TheseusEntry(type, typeAttr));

				foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
				{
					// アクセサ（get_/set_）は除外
					if (method.IsSpecialName && (method.Name.StartsWith("get_") || method.Name.StartsWith("set_")))
						continue;

					var methodAttr = method.GetCustomAttribute(typeof(TheseusAttribute)) as TheseusAttribute;
					entries.Add(new TheseusEntry(method, methodAttr));
				}

				foreach (PropertyInfo prop in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
				{
					var propAttr = prop.GetCustomAttribute(typeof(TheseusAttribute)) as TheseusAttribute;
					entries.Add(new TheseusEntry(prop, propAttr));
				}
			}

			return entries;
		}
	}
}