<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="MemberSystem.Views.ChangePassword" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改密碼</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>修改密碼</h2>
            <hr />
            
            輸入新密碼：<asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br /><br />
            
            
            <asp:Button ID="btnSubmitChange" runat="server" Text="確認修改" OnClick="btnSubmitChange_Click" />
            <br /><br />
            
           
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <br /><br />
            
            <a href="Dashboard.aspx">返回會員中心</a>
        </div>
    </form>
</body>
</html>
