namespace TheseusMarker.Attributes
{
	/// <summary>
	/// 移行の進捗状態を表す。
	/// </summary>
	public enum MigrationStatus
	{
		/// <summary>移行予定（まだ未着手）</summary>
		[Display(Name = "移行予定")]
		Planned,

		/// <summary>移行元コードのレビュー中（現行コードの品質確認）</summary>
		[Display(Name = "移行元レビュー中")]
		SourceReview,

		/// <summary>移行元コードのレビュー指摘を受けて修正中</summary>
		[Display(Name = "移行元修正中")]
		SourceRevising,

		/// <summary>移行作業中（新環境への移植・調整中）</summary>
		[Display(Name = "移行作業中")]
		Migrating,

		/// <summary>移行後コードのレビュー中（移植結果の確認）</summary>
		[Display(Name = "移行先レビュー中")]
		TargetReview,

		/// <summary>移行後コードのレビュー指摘を受けて修正中</summary>
		[Display(Name = "移行先修正中")]
		TargetRevising,

		/// <summary>トラブル発生（ビルドエラーや動作不良など）</summary>
		[Display(Name = "トラブル発生")]
		TroubleDetected,

		/// <summary>トラブル対応中（調査・修正・再試行中）</summary>
		[Display(Name = "トラブル対応中")]
		Troubleshooting,

		/// <summary>移行完了</summary>
		[Display(Name = "移行完了")]
		Done,

		/// <summary>非推奨（削除予定）</summary>
		[Display(Name = "非推奨")]
		Deprecated
	}
}