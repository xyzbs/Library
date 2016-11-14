<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Library.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
    <div>
        学号:<asp:TextBox ID="txtstunum" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="must1" runat="server" ValidationGroup="test" ControlToValidate="txtstunum" BackColor="Red">*学号不能为空</asp:RequiredFieldValidator><br />
        姓名:<asp:TextBox ID="txtname"  runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="must2" runat="server" ValidationGroup="test" ControlToValidate="txtname" BackColor="Red">*姓名不能为空</asp:RequiredFieldValidator><br />
        用户名:<asp:TextBox ID="usename"  runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="test" ControlToValidate="txtname" BackColor="Red">*姓名不能为空</asp:RequiredFieldValidator><br />
        密码:<asp:TextBox ID ="txtpwd1" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="must3" runat="server" ControlToValidate="txtpwd1" BackColor="Red">*密码不能为空</asp:RequiredFieldValidator><br />
        确认密码:<asp:TextBox ID ="txtpwd2" runat="server" TextMode="Password"></asp:TextBox>
        <asp:CompareValidator ID="Compare" runat="server" ValidationGroup="test" ControlToCompare="txtpwd2" BackColor="Pink" ControlToValidate="txtpwd1">*密码不一致*</asp:CompareValidator><br />
        手机号:<asp:TextBox ID="txtmobile"  runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="must6" runat="server" ValidationGroup="test" ControlToValidate="txtmobile" BackColor="Red">*手机号不能为空</asp:RequiredFieldValidator><br />
        邮箱:<asp:TextBox ID="txtemail"  runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="test" BackColor="YellowGreen" runat="server" ControlToValidate="txtemail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" >*邮箱格式错误</asp:RegularExpressionValidator> <br />
        <asp:Button ID="btregite" Text="注册" runat="server" ValidationGroup="test" OnClick="btregite_Click" /> 
    </div>
    </form>
</body>
</html>
