<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MemberSystem.Views.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Small World 會員註冊</h2>
            <hr />
            帳號：<asp:TextBox ID="txtAccount" runat="server"></asp:TextBox><br /><br />
            密碼：<asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br /><br />
            姓名：<asp:TextBox ID="txtName" runat="server"></asp:TextBox><br /><br />
            生日：<asp:TextBox ID="txtBirthday" runat="server" TextMode="Date"></asp:TextBox><br /><br />
            信箱：<asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox><br /><br />

            身分：
            <asp:DropDownList ID="ddlRole" runat="server">
                <asp:ListItem Value="3" Text="一般會員"></asp:ListItem>
                <asp:ListItem Value="2" Text="VIP 會員"></asp:ListItem>
                <asp:ListItem Value="1" Text="管理者"></asp:ListItem>
            </asp:DropDownList>
            <br /><br />

            <asp:Button ID="btnRegister" runat="server" Text="註冊" OnClick="btnRegister_Click" />
            <br /><br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
