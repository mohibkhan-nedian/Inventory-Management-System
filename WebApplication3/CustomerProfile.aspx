<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerProfile.aspx.cs" Inherits="WebApplication3.CustomerProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <customControls:Header2 ID="Header1" runat="server"></customControls:Header2>
        <asp:Label runat="server" ID="lblInfo"></asp:Label>
            
        Name :&nbsp;
        <asp:Label ID="name" runat="server" Text="Label"></asp:Label>
            
        <br />
        Regno:&nbsp;&nbsp;
        <asp:Label ID="regno" runat="server" Text="Label"></asp:Label>
            
        <br />
        Email1:
        <asp:Label ID="email1" runat="server" Text="Label"></asp:Label>
            
             <br />
        Email2:
        <asp:Label ID="email2" runat="server" Text="Label"></asp:Label>

             <br />
        Address1:
        <asp:Label ID="addr1" runat="server" Text="Label"></asp:Label>

             <br />
        Address2:
        <asp:Label ID="addr2" runat="server" Text="Label"></asp:Label>

             <br />
        Contact1:
        <asp:Label ID="Contact1" runat="server" Text="Label"></asp:Label>

             <br />
        Contact2:
        <asp:Label ID="contact2" runat="server" Text="Label"></asp:Label>

             <br />
        
        <asp:Button ID="Btn1"  runat="server" Text="View His Orders" OnClick="Btn1_Click"></asp:Button>
        
             <br />
        
        <asp:Button ID="Btn2"  runat="server" Text="View His Bills" OnClick="Btn2_Click"></asp:Button>
    </div>
    </form>
</body>
</html>
