<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="Lab6.Homepage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <asp:HyperLink ID="signup" Enabled="true" Text="Create New Account" NavigateUrl="~/signup.aspx" runat="server"></asp:HyperLink>
        <br />
            <asp:HyperLink ID="login" Enabled="true" Text="SignIn" NavigateUrl="~/login.aspx" runat="server"></asp:HyperLink>


    </div>
    </form>
</body>
</html>
