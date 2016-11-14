<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Words.aspx.cs" Inherits="Library.Common.Words" %>
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
         <uc1:top ID="top" runat="server"/><br />
        <asp:Button ID="history" runat="server" Text="留言历史" OnClick="history_Click" /><br />
        <asp:GridView ID="GridView1" runat="server" Visible="false">        
        </asp:GridView>
        留言板<br /><asp:TextBox ID="mywords" runat="server" TextMode="MultiLine" Height="94px" Width="309px"></asp:TextBox>
        <br /><asp:Button ID="btnWord" runat="server" Text="留言" OnClick="btnWord_Click" />
    </div>
    </form>
</body>
</html>
