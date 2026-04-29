<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="MemberSystem.Views.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>會員中心</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Small World 會員中心</h2>
            <hr />

            <asp:Button ID="btnChangePassword" runat="server" Text="修改密碼" OnClick="btnChangePassword_Click" />
            <asp:Button ID="btnViewProfile" runat="server" Text="瀏覽基本資料" OnClick="btnViewProfile_Click" />
            <asp:Button ID="btnEditProfile" runat="server" Text="編輯基本資料" OnClick="btnEditProfile_Click" />
            <asp:Button ID="btnUserList" runat="server" Text="帳號權限列表" OnClick="btnUserList_Click" />
            <asp:Button ID="btnUserEdit" runat="server" Text="帳號權限編輯" OnClick="btnUserEdit_Click" />
            <br />
            <br />
            <asp:Label ID="lblWelcome" runat="server" Font-Bold="True"></asp:Label>
        </div>
    </form>
</body>
</html>
