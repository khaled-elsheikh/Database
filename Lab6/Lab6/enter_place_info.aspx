<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="enter_place_info.aspx.cs" Inherits="Lab6.enter_city_info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lbl_name" runat="server" Text="Place name:   "></asp:Label>
        <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
        <asp:Label ID="lbl_long" runat="server" Text="Longitude:   "></asp:Label>
        <asp:TextBox ID="txt_long" runat="server"></asp:TextBox>
        <asp:Label ID="lbl_lat" runat="server" Text="Latitude:   "></asp:Label>
        <asp:TextBox ID="txt_lat" runat="server"></asp:TextBox>
        <asp:Label ID="lbl_date" runat="server" Text="Building date:   "></asp:Label>
        <asp:TextBox ID="txt_date" runat="server"></asp:TextBox>
        <asp:Button ID="btn_enter" runat="server" Text="Enter Data" onclick="enter"  />
    </div>
    </form>
</body>
</html>
