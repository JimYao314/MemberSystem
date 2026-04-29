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
            <asp:GridView ID="gvUserList" runat="server" AutoGenerateColumns="False" CellPadding="10" OnRowCommand="gvUserList_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Account" HeaderText="帳號" />
                    <asp:BoundField DataField="UserName" HeaderText="姓名" />
                    <asp:BoundField DataField="RoleName" HeaderText="目前身分" />

                    <asp:TemplateField HeaderText="變更權限">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlNewRole" runat="server">
                                <asp:ListItem Value="1" Text="管理者"></asp:ListItem>
                                <asp:ListItem Value="2" Text="VIP"></asp:ListItem>
                                <asp:ListItem Value="3" Text="一般會員"></asp:ListItem>
                            </asp:DropDownList>

                            <asp:Button ID="btnUpdate" runat="server" Text="確認修改"
                                CommandName="UpdateRole"
                                CommandArgument='<%# Eval("UserID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <a href="Dashboard.aspx">返回會員中心</a>
        </div>
    </form>
</body>
</html>
