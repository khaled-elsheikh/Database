<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Lab6.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #TextArea1 {
            /*height: 137px;*/
            width: 503px;
        }
        #Text1 {
            height: 103px;
            width: 544px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink ID="home" Enabled="true" Text="HOME" NavigateUrl="~/Homepage.aspx" runat="server"></asp:HyperLink>
        <br />
        <br />
        <asp:Label ID="lbl_username" runat="server" Text="Email:   "></asp:Label>
        <asp:TextBox ID="txt_username" runat="server"></asp:TextBox>
        <asp:Label ID="lbl_password" runat="server" Text="Password:   "></asp:Label>
        <asp:TextBox ID="txt_password" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Button ID="btn_login" runat="server" Text="Login" onclick="signin"  />
        </div>
    </form>
    </body>
</html>
