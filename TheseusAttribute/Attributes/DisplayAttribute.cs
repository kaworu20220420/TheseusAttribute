using System;

/// <summary>
/// enum の表示名を指定するための軽量属性。
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public sealed class DisplayAttribute : Attribute
{
	/// <summary>
	/// 表示名（日本語など）
	/// </summary>
	public string Name { get; set; }

	public DisplayAttribute() { }

	public DisplayAttribute(string name)
	{
		Name = name;
	}
}