<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="WebApplication3.Customer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" class="gl">
          <customControls:Header ID="Header1" runat="server"></customControls:Header>
    <div>
    <asp:Label runat="server" ID="abc"></asp:Label>

        
        <div class="form-group"></div>
            <label runat="server" class="control-label col-sm-2" for="email">First Name:</label>
        <div class="col-sm-7">
            <asp:TextBox runat="server" ID="fname"  CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group"></div>
            <label runat="server" class="control-label col-sm-2" for="lastname">Last Name:</label>
        <div class="col-sm-7">
            <asp:TextBox runat="server" ID="lname"  CssClass="form-control"></asp:TextBox>
        </div>
        
        <div class="form-group"></div>
            <label runat="server" class="control-label col-sm-2" for="address">Permenant Address:</label>
        <div class="col-sm-7">
            <asp:TextBox runat="server" ID="addr1"  CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group"></div>
            <label runat="server" class="control-label col-sm-2" for="email">Resident Address:</label>
        <div class="col-sm-7">
            <asp:TextBox runat="server" ID="addr2"  CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group"></div>
            <label runat="server" class="control-label col-sm-2" for="email">Primary Email :</label>
        <div class="col-sm-7">
            <asp:TextBox runat="server" ID="email1"  CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group"></div>
            <label runat="server" class="control-label col-sm-2" for="email">Secondary Email:</label>
        <div class="col-sm-7">
            <asp:TextBox runat="server" ID="email2"  CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group"></div>
            <label runat="server" class="control-label col-sm-2" for="pass">Password:</label>
        <div class="col-sm-7">
          <asp:TextBox ID="password" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group"></div>
            <label runat="server" class="control-label col-sm-2" for="email">Contact No1:</label>
        <div class="col-sm-7">
         <asp:TextBox runat="server" ID="contact1" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group"></div>
            <label runat="server" class="control-label col-sm-2" for="email">Contact No2:</label>
        <div class="col-sm-7">
            <asp:TextBox runat="server" ID="contact2"  CssClass="form-control"></asp:TextBox>
        </div>
              <asp:Button runat="server" ID="btn" Text="Confirm order" OnClick="btn_Click" CssClass="btn btn-success"/>
        
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" CssClass="btn btn-warning" />
        <h2 class="text-center">Just sign in with registered email id</h2>

        <div class="form-group"></div>
            <label runat="server" class="control-label col-sm-2" for="email">Email:</label>
        <div class="col-sm-7">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>

        <div class="form-group"></div>
            <label runat="server" class="control-label col-sm-2" for="pwd">Password:</label>
        <div class="col-sm-7">
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </div>
        </br>
        
            <asp:Button ID="Confirm" runat="server" Text="Submit" OnClick="Confirm_Click" CssClass="btn btn-primary" />
      
 
        <asp:Label runat="server" ID="lblInfo"></asp:Label>
    </div>
    </form>
</body>
</html>
