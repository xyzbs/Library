<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyBooks.aspx.cs" Inherits="Library.Common.MyBooks" %>
<%@ Register TagPrefix="uc1" TagName="top" Src="~/Common/Top.ascx"%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <uc1:top ID="top" runat="server" /><br />
        您的位置>>海大图书馆>>借阅历史<br />
        <asp:TextBox ID="searchname" runat="server"></asp:TextBox>     
        <asp:DropDownList ID="searchlist" runat="server"><asp:ListItem>书名</asp:ListItem></asp:DropDownList>
        <asp:Button ID="search" runat="server" Text="搜索" OnClick="search_Click"/>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        <asp:LinkButton ID="lnkbtnFrist" runat="server" OnClick="lnkbtnFrist_Click">首页</asp:LinkButton> 
        <asp:LinkButton ID="lnkbtnPre" runat="server" OnClick="lnkbtnPre_Click">上一页</asp:LinkButton> 
        <asp:Label ID="lblCurrentPage" runat="server"></asp:Label> 
        <asp:LinkButton ID="lnkbtnNext" runat="server" OnClick="lnkbtnNext_Click">下一页</asp:LinkButton> 
        <asp:LinkButton ID="lnkbtnLast" runat="server" OnClick="lnkbtnLast_Click">尾页</asp:LinkButton> 
跳转到第<asp:DropDownList ID="CurrentPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CurrentPage_SelectedIndexChanged"> 
        </asp:DropDownList>页<br />
    </div>
    </form>
</body>
</html>
