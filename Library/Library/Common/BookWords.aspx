<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookWords.aspx.cs" Inherits="Library.Common.BookWords" %>
<%@ Register Src="~/Common/Top.ascx" TagName="top" TagPrefix="ucl" %>
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
        您的位置>>海大图书馆》书籍留言<br />
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>

    </div>
    </form>
</body>
</html>
