using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TheseusMarker.Attributes;

namespace TheseusMarker.Reporting
{
	public static class TheseusReporter
	{
		public static TheseusReport GenerateReport(Assembly assembly, string internalNamespacePrefix)
		{
			var entries = GenerateStructuredReport(assembly, internalNamespacePrefix);
			return new TheseusReport(entries);
		}

		public static List<TheseusReportEntry> GenerateStructuredReport(Assembly assembly, string internalNamespacePrefix)
		{
			var entries = new List<TheseusReportEntry>();
			var classStatus = new Dictionary<Type, MigrationStatus>();

			foreach (var type in assembly.GetTypes())
			{
				if (!IsRelevant(type)) continue;

				bool isInternal = type.Namespace != null && type.Namespace.StartsWith(internalNamespacePrefix);
				var typeAttr = type.GetCustomAttribute(typeof(TheseusAttribute)) as TheseusAttribute;
				entries.Add(new TheseusReportEntry(type, typeAttr, "Class", isInternal));

				if (typeAttr != null && typeAttr.Status == MigrationStatus.Done)
				{
					classStatus[type] = MigrationStatus.Done;
				}

				foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
				{
					if (IsAccessor(method) || !IsRelevant(method)) continue;

					bool isInternalMethod = method.DeclaringType?.Namespace != null &&
											method.DeclaringType.Namespace.StartsWith(internalNamespacePrefix);

					var attr = method.GetCustomAttribute(typeof(TheseusAttribute)) as TheseusAttribute;
					if (attr == null && classStatus.ContainsKey(type))
					{
						attr = TheseusAttribute.CreateSyntheticDone();
					}

					entries.Add(new TheseusReportEntry(method, attr, "Method", isInternalMethod));
				}

				foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
				{
					if (!IsRelevant(prop)) continue;

					bool isInternalProp = prop.DeclaringType?.Namespace != null &&
										  prop.DeclaringType.Namespace.StartsWith(internalNamespacePrefix);

					var attr = prop.GetCustomAttribute(typeof(TheseusAttribute)) as TheseusAttribute;
					if (attr == null && classStatus.ContainsKey(type))
					{
						attr = TheseusAttribute.CreateSyntheticDone();
					}

					entries.Add(new TheseusReportEntry(prop, attr, "Property", isInternalProp));
				}
			}

			return entries;
		}

		private static bool IsRelevant(MemberInfo member)
		{
			var type = member.DeclaringType ?? member as Type;
			if (type == null) return false;
			var ns = type.Namespace;
			if (string.IsNullOrEmpty(ns)) return false;
			if (type == typeof(object)) return false;
			if (ns.StartsWith("System.") || ns.StartsWith("Xamarin.")) return false;
			if (type.FullName != null && type.FullName.Contains("DisplayClass")) return false;
			if (member.Name.StartsWith("<")) return false;
			return true;
		}

		private static bool IsAccessor(MethodInfo method)
		{
			return method.IsSpecialName && (method.Name.StartsWith("get_") || method.Name.StartsWith("set_"));
		}
	}
}