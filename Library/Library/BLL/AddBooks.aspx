<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBooks.aspx.cs" Inherits="Library.BLL.AddBooks" %>
<%@ Register  Src="~/BLL/Top.ascx" TagName="top" TagPrefix="ucl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ucl:top ID="top" runat="server" /><br />       
        书名<asp:TextBox ID="Textname" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="must1" runat="server" ValidationGroup="test" ControlToValidate="Textname" BackColor="Red">*学号不能为空</asp:RequiredFieldValidator><br />
        作者<asp:TextBox ID="Textauth" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="must2" runat="server" ValidationGroup="test" ControlToValidate="Textauth" BackColor="Red">*作者不能为空</asp:RequiredFieldValidator><br />
        学科<asp:TextBox ID="Texttype" runat="server"></asp:TextBox><br />
        存货<asp:TextBox ID="Textnownum" runat="server" TextMode="Number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="must4" runat="server" ValidationGroup="test" ControlToValidate="Textnownum" BackColor="Red">*存货不能为空</asp:RequiredFieldValidator><br />
        编码<asp:TextBox ID="Textcode" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="must5" runat="server" ValidationGroup="test" ControlToValidate="Textcode" BackColor="Red">*编码不能为空</asp:RequiredFieldValidator><br />
        <asp:Button ID="add" runat="server" Text="添加" ValidationGroup="test" OnClick="add_Click" />
    </div>
    </form>
</body>
</html>
