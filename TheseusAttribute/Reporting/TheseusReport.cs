using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TheseusMarker.Reporting
{
	public class TheseusReport
	{
		public List<TheseusReportEntry> Entries { get; }
		public int MarkedCount { get; }
		public int TotalCount { get; }

		public TheseusReport(List<TheseusReportEntry> entries)
		{
			Entries = entries;
			TotalCount = entries.Count;
			MarkedCount = entries.Count(e => e.Attribute != null);
		}

		public IEnumerable<string> Lines
		{
			get
			{
				foreach (var entry in Entries)
				{
					var name = GetFullMemberName(entry.Member);
					if (entry.Attribute == null)
					{
						yield return $"[未マーク] {name}";
					}
					else
					{
						var attr = entry.Attribute;
						yield return $"[{attr.Status}] {name} / {attr.Group} / {attr.Platform} / {attr.Target} / {attr.Note}";
					}
				}
			}
		}

		public Dictionary<string, List<string>> GetLinesByCategory()
		{
			var result = new Dictionary<string, List<string>>();

			foreach (var entry in Entries)
			{
				var category = entry.Category;
				if (!result.ContainsKey(category))
					result[category] = new List<string>();

				var name = GetFullMemberName(entry.Member);
				if (entry.Attribute == null)
				{
					result[category].Add($"[未マーク] {name}");
				}
				else
				{
					var attr = entry.Attribute;
					result[category].Add($"[{attr.Status}] {name} / {attr.Group} / {attr.Platform} / {attr.Target} / {attr.Note}");
				}
			}

			return result;
		}

		private static string GetFullMemberName(MemberInfo member)
		{
			if (member is Type type)
			{
				return type.FullName ?? type.Name;
			}

			var declaring = member.DeclaringType?.FullName ?? "(不明)";
			return $"{declaring}.{member.Name}";
		}

		public Dictionary<string, (int marked, int total)> GetProgressByCategory()
		{
			return Entries
				.GroupBy(e => e.Category)
				.ToDictionary(
					g => g.Key,
					g => (
						marked: g.Count(e => e.Attribute != null),
						total: g.Count()
					)
				);
		}

		public (int internalMarked, int internalTotal, int externalMarked, int externalTotal) GetClassProgressByOrigin()
		{
			var classEntries = Entries.Where(e => e.Category == "Class");

			var internalEntries = classEntries.Where(e => e.IsInternal);
			var externalEntries = classEntries.Where(e => !e.IsInternal);

			return (
				internalMarked: internalEntries.Count(e => e.Attribute != null),
				internalTotal: internalEntries.Count(),
				externalMarked: externalEntries.Count(e => e.Attribute != null),
				externalTotal: externalEntries.Count()
			);
		}

		public IEnumerable<string> GetProgressSummaryLines()
		{
			var lines = new List<string>();

			var (internalMarked, internalTotal, externalMarked, externalTotal) = GetClassProgressByOrigin();
			lines.Add($"【Class: 内部】進捗: {internalMarked}/{internalTotal} ({(0 < internalTotal ? internalMarked * 100 / internalTotal : 0)}%)");
			lines.Add($"【Class: 外部】進捗: {externalMarked}/{externalTotal} ({(0 < externalTotal ? externalMarked * 100 / externalTotal : 0)}%)");

			var progress = GetProgressByCategory();
			foreach (var kv in progress)
			{
				if (kv.Key == "Class") continue;
				var marked = kv.Value.marked;
				var total = kv.Value.total;
				var percent = (0 < total) ? marked * 100 / total : 0;
				lines.Add($"【{kv.Key}】進捗: {marked}/{total} ({percent}%)");
			}

			return lines;
		}
	}
}