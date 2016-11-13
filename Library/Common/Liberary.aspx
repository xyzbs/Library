<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Liberary.aspx.cs" Inherits="Library.Common.Liberary" %>
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
        欢迎<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>加入海大图书馆 <br/>           
            <uc1:top ID="toptext" runat="server"/>       
        <br />您的位置>>海大图书馆
    </div>
    </form>
</body>
</html>
