namespace TheseusMarker.Attributes
{
	/// <summary>
	/// 移行対象の責務・分類を表す。
	/// </summary>
	public enum MigrationGroup
	{
		/// <summary>未分類</summary>
		[Display(Name = "未分類")]
		None,

		/// <summary>UI（画面・XAML・View）</summary>
		[Display(Name = "UI")]
		UI,

		/// <summary>ViewModel（画面ロジック・状態管理）</summary>
		[Display(Name = "ViewModel")]
		ViewModel,

		/// <summary>Model（データ構造・DTO・Entity）</summary>
		[Display(Name = "Model")]
		Model,

		/// <summary>Service（ビジネスロジック・API連携）</summary>
		[Display(Name = "Service")]
		Service,

		/// <summary>Converter（値変換・Binding補助）</summary>
		[Display(Name = "Converter")]
		Converter,

		/// <summary>Helper（ユーティリティ・静的関数）</summary>
		[Display(Name = "Helper")]
		Helper,

		/// <summary>Resource（画像・XAML・スタイル）</summary>
		[Display(Name = "Resource")]
		Resource,

		/// <summary>外部ライブラリ（NuGetパッケージ・外部依存）</summary>
		[Display(Name = "外部ライブラリ")]
		ExternalLibrary,

		/// <summary>親クラスから継承された意味（合成属性）</summary>
		[Display(Name = "継承済み")]
		Inherited
	}
}