using System;

namespace TheseusMarker.Attributes
{

	/// <summary>
	/// 移行対象であることを示す構造的メタ情報属性。
	/// 
	/// 使用例:
	/// [Theseus(
	///     note: "移行先は.NET 10でUIはMAUI",
	///     target: TargetFramework.Net10,
	///     platform: UIPlatform.Maui,
	///     status: MigrationStatus.Migrating,
	///     group: MigrationGroup.ViewModel)]
	/// public class LegacyViewModel { ... }
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public sealed class TheseusAttribute : Attribute
	{
		/// <summary>
		/// 移行の背景や理由を記述する。
		/// </summary>
		public string Note { get; }

		/// <summary>
		/// 移行先のターゲットフレームワークを指定する。
		/// </summary>
		public TargetFramework Target { get; }

		/// <summary>
		/// UIプラットフォーム（MAUI, WPF, Blazorなど）を指定する。
		/// </summary>
		public UIPlatform Platform { get; }

		/// <summary>
		/// 移行の進捗状態を指定する。
		/// </summary>
		public MigrationStatus Status { get; }

		/// <summary>
		/// 移行対象の責務・分類（UI/ViewModel/Modelなど）を指定する。
		/// </summary>
		public MigrationGroup Group { get; }

		public TheseusAttribute(
			string note,
			TargetFramework target = TargetFramework.Unknown,
			UIPlatform platform = UIPlatform.None,
			MigrationStatus status = MigrationStatus.Planned,
			MigrationGroup group = MigrationGroup.None)
		{
			Note = note;
			Target = target;
			Platform = platform;
			Status = status;
			Group = group;
		}

		public static TheseusAttribute CreateSyntheticDone()
		{
			return new TheseusAttribute(
				"親クラスが Done のため自動的に Done 扱い",
				TargetFramework.Net10,
				UIPlatform.Maui,
				MigrationStatus.Done,
				MigrationGroup.Inherited
			);
		}
	}
}