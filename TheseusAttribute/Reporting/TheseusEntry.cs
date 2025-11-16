using System.Reflection;
using TheseusMarker.Attributes;

namespace TheseusMarker.Reporting
{
	public class TheseusEntry
	{
		public MemberInfo Member { get; }
		public TheseusAttribute Attribute { get; }

		public TheseusEntry(MemberInfo member, TheseusAttribute attribute)
		{
			Member = member;
			Attribute = attribute;
		}
	}
}