<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="Library.BLL.Book" %>
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
        <ucl:top ID="top" runat="server" />
        您的位置》后台管理系统》书籍管理<br />
        <asp:TextBox ID="searchname" runat="server"></asp:TextBox>
        <asp:Button ID="search" runat="server" Text="搜索" OnClick="search_Click"/>
        <asp:DropDownList ID="searchlist" runat="server"><asp:ListItem>书名</asp:ListItem></asp:DropDownList>
        <asp:Repeater ID="RptBooks" runat="server" OnItemCommand="RptBooks_ItemCommand" OnItemDataBound="RptBooks_ItemDataBound">                                                                                     
    <HeaderTemplate>
        <table>
            <tr>
                <th>多选</th>
                <th>ID</th>
                <th>书名</th>
                <th>作者</th>
                <th>学科</th>
                <th>存货</th>
                <th>编码</th>
                <th>借出</th>
                <th>状态</th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>                                    
              <tr>
                  <td><asp:CheckBox ID="moreselect" runat="server" /></td>
                  <td><asp:label ID="ID" runat="server" Text='<%# Eval("ID")%>'></asp:label></td>
                  <asp:Panel ID="p" runat="server">
                  <td><asp:TextBox ID="name" Width="80PX" runat="server" Text='<%# Eval("书名")%>'></asp:TextBox></td>
                  <td><asp:TextBox ID="author" Width="60PX" runat="server" Text='<%# Eval("作者")%>'></asp:TextBox></td>
                  <td><asp:TextBox ID="subject" Width="60PX" runat="server" Text='<%# Eval("学科")%>'></asp:TextBox></td>
                  <td><asp:TextBox ID="lastnum" Width="20PX" runat="server" Text='<%# Eval("存货")%>'></asp:TextBox></td>
                  <td><asp:TextBox ID="code" Width="40PX" runat="server" Text='<%# Eval("编码")%>'></asp:TextBox></td>
                  <td><asp:Label ID="num" Width="20PX" runat="server" Text='<%# Eval("借出")%>'></asp:Label></td></asp:Panel>
                  <td><asp:Label ID="state" Width="60PX" runat="server" Text='<%# Eval("状态")%>'></asp:Label></td>
                  <td><asp:LinkButton ID="linkknow" runat="server" Text="介绍" PostBackUrl='<%#"~/Common/Words.aspx?ID="+Eval("ID") %>'></asp:LinkButton></td>
                  <td><asp:LinkButton ID="linkborrow" runat="server" Text="查询" CommandName="select" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton></td>
                  <td><asp:LinkButton ID="Linkre" runat="server" Text="编辑" CommandName="change"></asp:LinkButton></td>
                  <td><asp:LinkButton ID="Linkup" runat="server" Text="修改" CommandName="update" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton></td>
                </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
        <asp:Button ID="allre" runat="server" Text="反选" OnClick="allre_Click" />
        <asp:Button ID="delete" runat="server" Text="删除" OnClick="delete_Click" />
        <asp:Button ID="addbook" runat="server" Text="添加数据" OnClick="addbook_Click" />
        <asp:Panel ID="leave" runat="server">
        <asp:LinKButton ID="LBfirst" Text="首页" runat="server" OnClick="LBfirst_Click"></asp:LinKButton>
        <asp:LinkButton ID="LBlast" Text="尾页" runat="server" OnClick="LBlast_Click"></asp:LinkButton>
        <asp:Label ID="pagetotle" runat="server" Text="Label"></asp:Label>
        <asp:LinkButton ID="LBnup" Text="上一页" runat="server" OnClick="LBnup_Click"></asp:LinkButton>
        <asp:LinkButton ID="LBdown" Text="下一页" runat="server" OnClick="LBdown_Click"></asp:LinkButton>
        <asp:TextBox ID="pagecount" runat="server" Width="30px" TextMode="Number" onkeyup="this.value=this.value.replace(/\D/g,'')"></asp:TextBox>
        <asp:LinkButton ID="LBleave" Text="跳转" runat="server" OnClick="LBleave_Click"></asp:LinkButton></asp:Panel><br />
        <asp:GridView ID="GridView1" runat="server" Visible="false"></asp:GridView>
    </div>
    </form>   
</body>
</html>
