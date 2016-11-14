<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recode.aspx.cs" Inherits="Library.Common.Recode" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>验证页面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        验证页面<br />
        <asp:TextBox ID="recode" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="retu" runat="server" Text="取消" OnClick="retu_Click" />
        <asp:Button ID="reBtn" runat="server" Text="验证" OnClick="reBtn_Click" />
    </div>
    </form>
</body>
</html>
