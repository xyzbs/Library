<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="Library.Common.Book" %>
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
        您的位置>>海大图书馆》书籍查询<br />
        <asp:TextBox ID="searchname" runat="server"></asp:TextBox>
        <asp:Button ID="search" runat="server" Text="搜索" OnClick="search_Click" />
        <asp:DropDownList ID="searchlist" runat="server"><asp:ListItem>ID</asp:ListItem></asp:DropDownList>
        <br />提醒：借书时需要输入ID和用户名
<asp:Repeater ID="RptBooks" runat="server" OnItemCommand="RptBooks_ItemCommand" OnItemDataBound="RptBooks_ItemDataBound">                                                                                     
    <HeaderTemplate>
        <table>
            <tr>
                <th>状态</th>
                <th>ID</th>
                <th>书名</th>
                <th>作者</th>
                <th>学科</th>
                <th>状态</th>
                <th>存货</th>
                <th>编码</th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
              <tr>
                  <td><asp:Label ID="ubstate" runat="server" Text="已借"></asp:Label></td>
                  <td><asp:Label ID="ID" runat="server" Text='<%# Eval("ID")%>'></asp:Label></td>
                  <td><asp:Label ID="name" runat="server" Text='<%# Eval("书名")%>'></asp:Label></td>
                  <td><asp:Label ID="author" runat="server" Text='<%# Eval("作者")%>'></asp:Label></td>
                  <td><asp:Label ID="subject" runat="server" Text='<%# Eval("学科")%>'></asp:Label>
                  <td><asp:Label ID="state" runat="server" Text='<%# Eval("状态")%>'></asp:Label></td>
                  <td><asp:Label ID="lastnum" runat="server" Text='<%# Eval("存货")%>'></asp:Label></td>
                  <td><asp:Label ID="Label8" runat="server" Text='<%# Eval("编码")%>'></asp:Label></td>
                  <td><asp:LinkButton ID="linkknow" runat="server" Text="介绍" CommandName="book" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton></td>
                  <td><asp:LinkButton ID="linkborrow" runat="server" Text="预约" CommandName="update" Visible="true" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton></td>
                  <td><asp:LinkButton ID="word" runat="server" Text="留言" CommandName="word" Visible="false" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton></td>
                </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
        <asp:LinKButton ID="LBfirst" Text="首页" runat="server" OnClick="LBfirst_Click"></asp:LinKButton>
        <asp:LinkButton ID="LBlast" Text="尾页" runat="server" OnClick="LBlast_Click"></asp:LinkButton>
        <asp:Label ID="pagetotle" runat="server" Text="Label"></asp:Label>
        <asp:LinkButton ID="LBnup" Text="上一页" runat="server" OnClick="LBnup_Click"></asp:LinkButton>
        <asp:LinkButton ID="LBdown" Text="下一页" runat="server" OnClick="LBdown_Click"></asp:LinkButton>
        <asp:TextBox ID="pagecount" runat="server" Width="30px" TextMode="Number" onkeyup="this.value=this.value.replace(/\D/g,'')"></asp:TextBox>
        <asp:LinkButton ID="LBleave" Text="跳转" runat="server" OnClick="LBleave_Click"></asp:LinkButton>
    </div>
    </form>
</body>
</html>
