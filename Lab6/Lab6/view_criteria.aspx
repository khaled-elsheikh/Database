<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view_criteria.aspx.cs" Inherits="Lab6.view_criteria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink ID="Home" Enabled="true" Text="Home" NavigateUrl="~/manager_profile.aspx" runat="server"></asp:HyperLink>
        <br />
        <asp:HyperLink ID="logout" Enabled="true" Text="Logout" NavigateUrl="~/Logout.aspx" runat="server"></asp:HyperLink>
        <br />
        <br />
    </div>
    </form>
</body>
</html>
