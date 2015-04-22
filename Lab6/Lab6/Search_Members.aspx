<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search_Members.aspx.cs" Inherits="Lab6.Search_Members" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink ID="Home" Enabled="true" Text="Home   " NavigateUrl="~/ViewProfile.aspx" runat="server"></asp:HyperLink>
        <br />
        <asp:HyperLink ID="logout" Enabled="true" Text="Logout" NavigateUrl="~/Logout.aspx" runat="server"></asp:HyperLink>
        <br />
        <br />
        <asp:TextBox ID="Search_Bar" runat="server"></asp:TextBox>
        <asp:Button ID="btn_Search" runat="server" Text="Search" CommandName="Search_Members" onclick="view"/>
    </div>
    </form>
</body>
</html>
