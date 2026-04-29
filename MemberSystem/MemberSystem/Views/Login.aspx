<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MemberSystem.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Small World 會員登入</h2>

          
            帳號：<asp:TextBox ID="txtAccount" runat="server"></asp:TextBox>
            <br />
            <br />

            
            密碼：<asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />

           
            <asp:Button ID="btnLogin" runat="server" Text="登入" OnClick="btnLogin_Click" />
            <br />
            <br />

           
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <a href="Register.aspx">還沒有帳號？點此註冊</a>
        </div>
    </form>
</body>
</html>
