<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyData.aspx.cs" Inherits="Library.Common.MyData" %>
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
    <uc1:top ID="top" runat="server" />
        <br />您的位置>>海大图书馆>>我的资料
        <asp:GridView ID="GridView1"  BorderColor="Black" runat="server" AutoGenerateColumns="False"  Font-Size="12px" Width="530px">
          <Columns>
              <asp:TemplateField HeaderText="用户名">
                  <ControlStyle Width="60px" />
                  <ItemTemplate>
                      <asp:TextBox ID="txtname" runat="server" Text='<%#Eval("用户名") %>' ></asp:TextBox>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="手机号">
                  <ControlStyle Width="80px" />
                  <ItemTemplate>
                      <asp:TextBox ID="txtmobile" runat="server" Text='<%#Eval("手机号") %>'></asp:TextBox>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="邮箱">
                  <ControlStyle Width="120px" />
                  <ItemTemplate>
                      <asp:Label ID="txtemail" runat="server" Text='<%#Eval("邮箱") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="学号">
                  <ControlStyle Width="100px" />
                  <ItemTemplate>
                      <asp:Label ID="txtstu" runat="server" Text='<%#Eval("学号") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="余额">
                  <ControlStyle Width="50px" />
                  <ItemTemplate>
                      <asp:Label ID="txtmoney" runat="server" Text='<%#Eval("余额") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
          </Columns>
          <HeaderStyle BackColor="Azure" Font-Size="12px" HorizontalAlign="Center" />
            <RowStyle HorizontalAlign="Center" />
            <PagerStyle HorizontalAlign="Center" />
        </asp:GridView>
        <br />
        &nbsp;<asp:Button ID="update" runat="server" Text="更新数据" Width="367px" OnClick="update_Click"/><br />
        <asp:Button ID="rebtn" runat="server" Text="修改密码或邮箱" OnClick="rebtn_Click" />
    </div>
        <div id="reform" runat="server" visible="false">
                密码：<asp:TextBox ID="txtpwd1" runat="server" TextMode="Password"></asp:TextBox><br />
            确认密码：<asp:TextBox ID="txtpwd2" runat="server" TextMode="Password"></asp:TextBox>
             <asp:CompareValidator ID="Compare" runat="server" ControlToCompare="txtpwd2" BackColor="Pink" ControlToValidate="txtpwd1">*密码不一致*</asp:CompareValidator><br />
                邮箱：<asp:TextBox ID="email" runat="server"></asp:TextBox>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" BackColor="YellowGreen" runat="server" ControlToValidate="email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" >*邮箱格式错误</asp:RegularExpressionValidator> <br />
             <asp:Button ID="sendemail" runat="server" Text="确定" OnClick="sendemail_Click"/>
        </div>
    </form>
</body>
</html>
