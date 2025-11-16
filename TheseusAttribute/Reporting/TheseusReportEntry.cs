using System.Reflection;
using TheseusMarker.Attributes;

namespace TheseusMarker.Reporting
{
	public class TheseusReportEntry
	{
		public MemberInfo Member { get; }
		public TheseusAttribute Attribute { get; set; } // set可能にする
		public string Category { get; } // "Class", "Method", "Property"

		public bool IsInternal { get; }

		public TheseusReportEntry(MemberInfo member, TheseusAttribute attribute, string category, bool isInternal)
		{
			Member = member;
			Attribute = attribute;
			Category = category;
			IsInternal = isInternal;
		}
	}
}