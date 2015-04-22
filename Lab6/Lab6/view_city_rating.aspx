<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view_city_rating.aspx.cs" Inherits="Lab6.view_city_rating" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink ID="Home" Enabled="true" Text="Home" NavigateUrl="~/ViewProfile.aspx" runat="server"></asp:HyperLink>
        <br />
        <asp:HyperLink ID="search" Enabled="true" Text="Search for members" NavigateUrl="~/Search_Members.aspx" runat="server"></asp:HyperLink>
        <br />
        <asp:HyperLink ID="search1" Enabled="true" Text="Search for places" NavigateUrl="~/Search_Places.aspx" runat="server"></asp:HyperLink>
        <br />
        <asp:HyperLink ID="logout" Enabled="true" Text="Logout" NavigateUrl="~/Logout.aspx" runat="server"></asp:HyperLink>
        <br />
        <br />
    </div>
    </form>
</body>
</html>
