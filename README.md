# Small World 會員管理系統 (MemberSystem)

本專案為 ASP.NET 4.6 Web Forms 會員管理系統，符合 MVC 設計概念。具備完整的身分驗證、權限控管與資料庫互動功能。

##  系統功能
- **身分驗證**：支援一般會員、VIP、管理者三種權限等級。
- **會員管理**：註冊、登入、個人資料修改、密碼變更。
- **權限控管**：根據 RoleID 動態顯示功能按鈕。
- **管理者後台**：會員清單瀏覽與權限編輯功能。

##  技術棧 (Tech Stack)
- **前端**：HTML5, CSS3, ASPX
- **後端**：C# (.NET Framework 4.6)
- **資料庫**：MSSQL (Stored Procedures, Views, Functions)
- **版本控管**：Git / GitHub

##  如何執行此專案

1. **資料庫建置**：
   - 請將專案內的 `DB_Scripts` 資料夾下的 SQL 腳本在 SQL Server 中執行，以建立資料庫與物件。
   - 確保資料庫名稱為 `SmallWorld`。

2. **環境需求**：
   - Visual Studio 2022/2026
   - SQL Server Express / SSMS
   - .NET Framework 4.6 SDK

3. **啟動方式**：
   - 開啟 `MemberSystem.sln` (或 `MemberSystem.slnx`) 解決方案。
   - 確認 `Web.config` 中的連線字串 (`connectionStrings`) 指向你的本地 SQL Server 實例。
   - 按下 `F5` 啟動 IIS Express 進行測試。

---
*Created by Yao
