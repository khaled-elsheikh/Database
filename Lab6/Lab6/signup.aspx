<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="Lab6.signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink ID="home" Enabled="true" Text="HOME" NavigateUrl="~/Homepage.aspx" runat="server"></asp:HyperLink>
        <br />
        <br />
        <asp:Label ID="lbl_email" runat="server" Text="Email:   "></asp:Label>
        <asp:TextBox ID="txt_email" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID ="RequiredFieldValidator1" runat ="server" ControlToValidate ="txt_email" ErrorMessage = "Email is required" ForeColor ="Red"></asp:RequiredFieldValidator>
        <br />
        
        <asp:Label ID="lbl_password" runat="server" Text="Password:   "></asp:Label>
        <asp:TextBox ID="txt_password" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID ="RequiredFieldValidator2" runat ="server" ControlToValidate ="txt_email" ErrorMessage = "Password is required" ForeColor ="Red"></asp:RequiredFieldValidator>
        <br />

        <asp:Label ID="lbl_fname" runat="server" Text="First Name:   "></asp:Label>
        <asp:TextBox ID="txt_fname" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID ="RequiredFieldValidator3" runat ="server" ControlToValidate ="txt_email" ErrorMessage = "FirstName is required" ForeColor ="Red"></asp:RequiredFieldValidator>

        <br />

        <asp:Label ID="lbl_lname" runat="server" Text="Last Name:   "></asp:Label>
        <asp:TextBox ID="txt_lname" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID ="RequiredFieldValidator4" runat ="server" ControlToValidate ="txt_email" ErrorMessage = "LastName is required" ForeColor ="Red"></asp:RequiredFieldValidator>

        <br />

        <asp:Label ID="lbl_nationality" runat="server" Text="Nationality:   "></asp:Label>
        <asp:TextBox ID="txt_nationality" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lbl_address" runat="server" Text="Address:   "></asp:Label>
        <asp:TextBox ID="txt_address" runat="server"></asp:TextBox>
        <br />


        <asp:Button ID="btn_signup" runat="server" Text="Signup" onclick="signupp" />
    </div>
    </form>
</body>
</html>
