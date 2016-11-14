<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Top.ascx.cs" Inherits="Library.Common.Top" %>

<br />
<asp:Button ID="btndata" runat="server" Text="我的资料" OnClick="btndata_Click"/>
<asp:Button ID="btnhis" runat="server" Text="借阅历史" OnClick="btnhis_Click"/>
<asp:Button ID="btnbook" runat="server" Text="书籍查询" OnClick="btnbook_Click"/>
<asp:Button ID="btnword" runat="server" Text="留言历史" OnClick="btnword_Click"/>
<asp:Button ID="delete" runat="server" Text="注销" OnClick="delete_Click"/><br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:ImageButton ID="Image1" runat="server" Height="100px" Width="100px" OnClick="Image1_Click" />
<div style="margin-left: 200px">
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <asp:FileUpload ID="FileUpload1" runat="server"/>
        <asp:Button ID="btnupload" runat="server" Text="上传" OnClick="btnupload_Click" />
    </asp:Panel>
</div>

 
 


