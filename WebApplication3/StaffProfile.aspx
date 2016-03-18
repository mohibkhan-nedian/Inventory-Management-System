<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffProfile.aspx.cs" Inherits="WebApplication3.StaffProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:Label>StaffID:</asp:Label> 
        <asp:Label ID="staffno" runat="server" Text="Label"></asp:Label>

        <asp:Label>Name:</asp:Label> 
        <asp:Label ID="name" runat="server" Text="Label"></asp:Label>

        
        <asp:Label>Address:</asp:Label> 
        <asp:Label ID="address" runat="server" Text="Label"></asp:Label>

        <asp:Label>Contact:</asp:Label> 
        <asp:Label ID="contact" runat="server" Text="Label"></asp:Label>


        <asp:Label>Date of Birth:</asp:Label> 
        <asp:Label ID="dob" runat="server" Text="Label"></asp:Label>

        <asp:Label>Gender:</asp:Label> 
        <asp:Label ID="gender" runat="server" Text="Label"></asp:Label>

        <asp:Label>User Name:</asp:Label> 
        <asp:Label ID="user" runat="server" Text="Label"></asp:Label>

        <asp:Label>Password:</asp:Label> 
        <asp:Label ID="pass" runat="server" Text="Label"></asp:Label>

    </div>
    </form>
</body>
</html>
