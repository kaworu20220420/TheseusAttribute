# TheseusAttribute


## 🧭 TheseusMarker — 構造で進捗を刻む C# 属性ライブラリ

TheseusMarker は、コード移行・再設計・保守の進捗を「構造的に」可視化するための C# 属性ライブラリです。  
コメントや Excel ではなく、**型・メソッド・プロパティに直接意味を刻む**ことで、進捗をコードベースに統合します。

---

### ✨ 特徴

- ✅ `TheseusAttribute` による進捗の明示（Status / Group / Platform / Target / Note）
- ✅ `TheseusReporter` によるアセンブリスキャンと構造抽出
- ✅ `TheseusReport` による進捗集計とカテゴリ別出力
- ✅ 内部クラスと外部ライブラリの進捗を分離集計
- ✅ 構造に意味を刻むことで、進捗と責務が一致

---

### 🔍 使い方

```csharp
[TheseusAttribute(Status = MigrationStatus.Done, Group = MigrationGroup.Core, Platform = UIPlatform.Maui, Target = TargetFramework.Net8, Note = "移行完了")]
public class MainViewModel
{
    [Theseus(Status = MigrationStatus.Planned, Group = MigrationGroup.UI)]
    public void Initialize() { ... }
}
```

```csharp
var report = TheseusReporter.GenerateReport(typeof(App).Assembly, "YourNameSpace");
foreach (var line in report.GetProgressSummaryLines())
{
    Console.WriteLine(line);
}
```

### 出力

```
[0:] ▼ Class ▼
[0:] [未マーク] Google.GoogleCalendar
[0:] [未マーク] FancyNote2019.在庫管理
[0:] [未マーク] FancyNote2019.MainPage
[0:] [未マーク] FancyNote2019.ViewModel.MainViewModel
[0:] ▼ Method ▼
[0:] [未マーク] Todoly.Todoly.PostItem
[0:] [未マーク] StringEdit.StringEdit.splittext
[0:] [未マーク] Dropbox.Dropbox.RecoverUpload
[0:] [未マーク] Google.GoogleCalendar.SetPlan2GoogleCalnedarEvent
[0:] [未マーク] FancyNote2019.MainPage.GetAllItems
[0:] [未マーク] FancyNote2019.MainPage.GetLocation
[0:] [Planned] FancyNote2019.PickerLogic.ExecuteAsync / ExternalLibrary / Maui / Net10 / メニューの構築
[0:] [未マーク] FancyNote2019.Views.NewItemPage.OnQrButtonClicked
[0:] [未マーク] FancyNote2019.Views.NewItemPage.ScanQRCode
[0:] [未マーク] FancyNote2019.Views.NewItemPage.OnSaveButtonClicked
[0:] [Planned] FancyNote2019.Model.GoogleCalendar.CalendarCoreViewModel.RegisterPlan / ExternalLibrary / Maui / Net10 / 予定登録
[0:] [未マーク] FancyNote2019.Model.Address.GeoLocation.IsCurrentLocationWithin
[0:] ▼ Property ▼
[0:] [未マーク] AddressViewer.Models.Item.PhoneDataRootPath
[0:] [未マーク] AddressViewer.Models.Item.AddressRootPathAndroid9
[0:] [未マーク] AddressViewer.Models.Item.AddressRootPath
[0:] [未マーク] Todoly.TodolyModel.Id
[0:] [未マーク] Todoly.TodolyModel.Content
[0:] [未マーク] FancyNote2019.Models.BookInformation.BookImage
[0:] [未マーク] FancyNote2019.Models.BookInformation.Url
[0:] [未マーク] FancyNote2019.Models.BookInformation.Isbn
[0:] [未マーク] FancyNote2019.Constants.Constants.LocalInboxPath
[0:] 【Class: 内部】進捗: 0/32 (0%)
[0:] 【Class: 外部】進捗: 0/19 (0%)
[0:] 【Method】進捗: 2/209 (0%)
[0:] 【Property】進捗: 0/171 (0%)

```
---

### 📦 外部ライブラリと NuGet の扱い(作成中)

- NuGet ライブラリはコードに直接 Attribute を付けられないため、**チェックリスト（Json）で進捗を管理**(作成中)
- 外部ライブラリ（リンクされた .cs）は Attribute を付けられる場合は直接管理、不可ならチェックリストへ(作成中)
- WPF 製の `TheseusAttributeChecker` により、チェックリストを生成・編集可能(作成中)

---

### 📁 フォルダ構成

```
TheseusMarker/
├── Attributes/       // 属性定義と分類
├── Extensions/       // Enum拡張など
├── Reporting/        // 構造抽出と進捗集計
├── TheseusAttribute.csproj
└── README.md
```

---

### 🧠 哲学

> 「舟の部品をすべて数え、意味を刻み、進捗を構造に宿す」  
> Theseus の舟を再構築するなら、まず部品に名前を与えよう。  
> コメントではなく、構造に意味を刻む。それが TheseusMarker の思想です。

---

### 📎 ライセンス

MIT License — 自由に使ってください。  
進捗を刻む文化が広がることを願っています。

