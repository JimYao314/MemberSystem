<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="MemberSystem.Views.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>帳號權限管理後台</h2>
            <hr />
          
            <asp:GridView ID="gvUserList" runat="server" AutoGenerateColumns="True" CellPadding="10">
            </asp:GridView>
            <br />
            <a href="Dashboard.aspx">返回會員中心</a>
        </div>
    </form>
</body>
</html>
