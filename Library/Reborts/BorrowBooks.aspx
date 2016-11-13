
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BorrowBooks.aspx.cs" Inherits="Library.Reborts.BorrowBooks" %>
<%@ Register Src="~/Reborts/Top.ascx" TagName="top" TagPrefix="ucl" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ucl:top ID="top" runat="server" />
        <h3 style="color: #008000">借书</h3>
       ID<asp:TextBox ID="textID" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="mustid" runat="server" ValidationGroup="book" ControlToValidate="textID">ID不能为空</asp:RequiredFieldValidator><br />
        用户名<asp:TextBox ID="textName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="mustname" runat="server" ControlToValidate="textName" ValidationGroup="book">用户名不能为空</asp:RequiredFieldValidator><br />
        <asp:Button ID="BtnScan" runat="server" Text="扫描" OnClick="BtnScan_Click" ValidationGroup="book" />
    </div>
    </form>
</body>
</html>
