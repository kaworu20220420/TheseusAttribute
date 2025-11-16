using System;
using System.Reflection;
using TheseusMarker.Attributes;

namespace TheseusMarker.Extensions
{
	public static class TargetFrameworkExtensions
	{
		/// <summary>
		/// Usage : var label = TargetFramework.Net10.DisplayName(); // ".NET 10"
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string DisplayName(this TargetFramework value)
		{
			var member = value.GetType().GetMember(value.ToString())[0];
			var attr = member.GetCustomAttribute<DisplayAttribute>();
			return attr?.Name ?? value.ToString();
		}
	}
}