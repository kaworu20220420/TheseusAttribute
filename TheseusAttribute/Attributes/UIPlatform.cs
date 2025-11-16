using System;

namespace TheseusMarker.Attributes
{
	/// <summary>
	/// UIプラットフォームの種類を表す。
	/// </summary>
	public enum UIPlatform
	{
		/// <summary>UIプラットフォーム未指定</summary>
		[Display(Name = "未指定")]
		None,

		/// <summary>マルチプラットフォームUI（iOS/Android/macOS/Windows）</summary>
		[Display(Name = "MAUI")]
		Maui,

		/// <summary>Windows専用のデスクトップUI（XAML + VisualTree）</summary>
		[Display(Name = "WPF")]
		Wpf,

		/// <summary>従来のWindowsフォームUI（WinForms）</summary>
		[Display(Name = "WinForms")]
		WinForms,

		/// <summary>Web UIをC#で構築（WASMまたはServer）</summary>
		[Display(Name = "Blazor")]
		Blazor,

		/// <summary>ASP.NET Coreのページ指向Web UI</summary>
		[Display(Name = "Razor Pages")]
		RazorPages,

		/// <summary>ASP.NET CoreのMVC構造によるWeb UI</summary>
		[Display(Name = "ASP.NET MVC")]
		AspNetMvc,

		/// <summary>RESTful API構築用のWebバックエンド</summary>
		[Display(Name = "ASP.NET Web API")]
		WebApi
	}
}