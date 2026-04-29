<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs"Inherits="MemberSystem.Views.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>基本資料</h2>
            <hr />
            
            帳號：<asp:Label ID="lblAccount" runat="server" Font-Bold="True"></asp:Label>
            <br /><br />
            
            姓名：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br /><br />
            
            生日：<asp:TextBox ID="txtBirthday" runat="server" TextMode="Date"></asp:TextBox>
            <br /><br />
            
            信箱：<asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
            <br /><br />
            
           
            <asp:Button ID="btnSave" runat="server" Text="儲存修改" Visible="False" OnClick="btnSave_Click" />
            <br /><br />
            
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <br /><br />
            <a href="Dashboard.aspx">返回會員中心</a>
        </div>
    </form>
</body>
</html>
