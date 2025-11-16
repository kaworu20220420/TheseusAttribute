using System;

namespace TheseusMarker.Attributes
{
	/// <summary>
	/// 移行先のターゲットフレームワークを表す。
	/// </summary>
	public enum TargetFramework
	{
		/// <summary>不明または未指定</summary>
		[Display(Name = "未指定")]
		Unknown,

		/// <summary>.NET 6</summary>
		[Display(Name = ".NET 6")]
		Net6,

		/// <summary>.NET 7</summary>
		[Display(Name = ".NET 7")]
		Net7,

		/// <summary>.NET 8</summary>
		[Display(Name = ".NET 8")]
		Net8,

		/// <summary>.NET 9</summary>
		[Display(Name = ".NET 9")]
		Net9,

		/// <summary>.NET 10</summary>
		[Display(Name = ".NET 10")]
		Net10
	}
}