<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view_place_page.aspx.cs" Inherits="Lab6.view_place_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div><asp:HyperLink ID="Home" Enabled="true" Text="Home" NavigateUrl="~/ViewProfile.aspx" runat="server"></asp:HyperLink>
        <br />
        <asp:HyperLink ID="search" Enabled="true" Text="Search for members" NavigateUrl="~/Search_Members.aspx" runat="server"></asp:HyperLink>
        <br />
        <asp:HyperLink ID="search1" Enabled="true" Text="Search for places" NavigateUrl="~/Search_Places.aspx" runat="server"></asp:HyperLink>
        <br />
        <asp:HyperLink ID="logout" Enabled="true" Text="Logout" NavigateUrl="~/Logout.aspx" runat="server"></asp:HyperLink>
        <br />
        <br />
            <asp:FileUpload ID="FileUploadControl" runat="server" />
            <asp:Button ID="bt_upload" runat="server" Text="Upload" onclick="upload_image"  />
        <br />
            <asp:Label ID="lbl_comment" runat="server" Text="Post a comment"></asp:Label>
            <asp:TextBox ID="txt_comment" runat="server"></asp:TextBox>
            <asp:Button ID="btn_post" runat="server" Text="Post" onclick="post_comment"  />
        <br />
        <asp:Label ID="lbl_question" runat="server" Text="Ask a question"></asp:Label>
            <asp:TextBox ID="txt_question" runat="server"></asp:TextBox>
            <asp:Button ID="bt_ask" runat="server" Text="Ask" onclick="add_question"  />
        <br />  
            <asp:Label ID="lbl_criteria" runat="server" Text="Add a rating criteria to this place"></asp:Label>
            <asp:TextBox ID="txt_criteria" runat="server"></asp:TextBox>
            <asp:Button ID="btn_criteria" runat="server" Text="Add" onclick="add_criteria"  />
        <br />
         
    </div>
    </form>
</body>
</html>
