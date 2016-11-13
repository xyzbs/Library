<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="Library.BLL.Students" %>
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
         <asp:TextBox ID="searchname" runat="server"></asp:TextBox>     
        <asp:DropDownList ID="searchlist" runat="server"><asp:ListItem>学号</asp:ListItem></asp:DropDownList>
        <asp:Button ID="search" runat="server" Text="搜索" OnClick="search_Click"/>
        <asp:GridView ID="GridView1" runat="server">
            <Columns>
                 <asp:TemplateField HeaderText="多选">
                  <ControlStyle Width="60px" />
                  <ItemTemplate>
                      <asp:CheckBox ID="alldata" runat="server" />
                  </ItemTemplate>
              </asp:TemplateField>          
              <asp:TemplateField HeaderText="学号">
                  <ControlStyle Width="60px" />
                  <ItemTemplate>
                      <asp:Label ID="txtnum" runat="server" Text='<%#Eval("学号") %>' ></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="姓名">
                  <ControlStyle Width="60px" />
                  <ItemTemplate>
                      <asp:Label ID="txtname" runat="server" Text='<%#Eval("姓名") %>' ></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="allre" runat="server" Text="反选" OnClick="allre_Click" />
        <asp:LinkButton ID="lnkbtnFrist" runat="server"  OnClick="lnkbtnFrist_Click">首页</asp:LinkButton> 
        <asp:LinkButton ID="lnkbtnPre" runat="server" OnClick="lnkbtnPre_Click">上一页</asp:LinkButton> 
        <asp:Label ID="lblCurrentPage" runat="server"></asp:Label> 
        <asp:LinkButton ID="lnkbtnNext" runat="server" OnClick="lnkbtnNext_Click">下一页</asp:LinkButton> 
        <asp:LinkButton ID="lnkbtnLast" runat="server" OnClick="lnkbtnLast_Click">尾页</asp:LinkButton> 
跳转到第<asp:DropDownList ID="CurrentPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CurrentPage_SelectedIndexChanged"> 
        </asp:DropDownList>页<br />
        <asp:Button ID="delete" runat="server" Text="删除数据" Width="360px" OnClick="delete_Click"/><br />
        <asp:Button ID="insert" runat="server" Text="添加数据" OnClick="insert_Click" />
               <asp:Button ID="BtnExcell" runat="server" Text="导出到excel" OnClick="BtnExcell_Click" />
        <asp:Button ID="BtnWord" runat="server" Text="导出到Word" OnClick="BtnWord_Click" />
    </div>
        <div id="div" runat="server" visible="false">
        姓名:<asp:TextBox ID="txtname"  runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="must2" runat="server" ValidationGroup="test" ControlToValidate="txtname" BackColor="Red">*姓名不能为空</asp:RequiredFieldValidator><br />     
        学号:<asp:TextBox ID="txtnum" runat="server"></asp:TextBox>
        <asp:requiredfieldvalidator id="stu" ValidationGroup="test" runat="server" ControlToValidate="txtnum" BackColor="Red">*学号不能为空</asp:requiredfieldvalidator><br />
        <asp:Button ID="btnadd" Text="添加" runat="server" ValidationGroup="test" OnClick="btnadd_Click"/><br />
        <asp:Button ID="Btnclose" runat="server" Text="关闭" OnClick="Btnclose_Click" />
    </div>
    </form>
</body>
</html>
