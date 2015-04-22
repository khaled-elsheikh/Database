<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View_places_criteria.aspx.cs" Inherits="Lab6.View_places_criteria" %>

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
        <asp:HyperLink ID="HyperLink1" Enabled="true" Text="City" NavigateUrl="~/view_city_criteria.aspx" runat="server"></asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink2" Enabled="true" Text="Hotel" NavigateUrl="~/view_hotel_criteria.aspx" runat="server"></asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink3" Enabled="true" Text="Monument" NavigateUrl="~/view_monument_criteria.aspx" runat="server"></asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink4" Enabled="true" Text="Restaurant" NavigateUrl="~/view_restaurant_criteria.aspx" runat="server"></asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink5" Enabled="true" Text="Museum" NavigateUrl="~/view_museum_criteria.aspx" runat="server"></asp:HyperLink>
        <br />
    </div>
    </form>
</body>
</html>
