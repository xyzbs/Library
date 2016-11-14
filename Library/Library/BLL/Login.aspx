<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Library.BLL.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        管理员:<asp:TextBox ID="txtname"  runat="server"></asp:TextBox><br />
        密码:<asp:TextBox ID ="txtpwd" runat="server" TextMode="Password"></asp:TextBox><br />
        <asp:Button ID="btlogin" Text="登录" runat="server" OnClick="btlogin_Click" /> <br />
        <br />
    </div>
    </form>
</body>
</html>
