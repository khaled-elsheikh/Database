<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProfile.aspx.cs" Inherits="Lab6.ViewProfile" %>

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
        <asp:Label ID="lbl_message" runat="server" Visible="false" Text="Message:   "></asp:Label>
        <asp:TextBox ID="txt_message" runat="server" Visible ="false"></asp:TextBox>
        <asp:Button ID="btn_send" runat="server" Text="Send" onclick="send_msg" Visible ="false" />
        <br />
        <br />
            <asp:Label ID="lblProfile" runat="server" Text="Profile" Font-Size="20"></asp:Label>
        <br />
        <br />

        

    </div>
    </form>
</body>
</html>
