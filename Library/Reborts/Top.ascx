
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Top.ascx.cs" Inherits="Library.Reborts.Top" %>
<h2>图书馆借书还书系统</h2>
<asp:Button ID="BorrowBooks" runat="server" Text="借书" OnClick="BorrowBooks_Click" />
<asp:Button ID="ReturnBooks" runat="server" Text="还书" OnClick="ReturnBooks_Click" />