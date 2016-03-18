<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

     <link rel="stylesheet" href="//code.jquery.com/ui/1.11.1/themes/smoothness/jquery-ui.css"/>
  <script src="//code.jquery.com/jquery-1.10.2.js"></script>
  <script src="//code.jquery.com/ui/1.11.1/jquery-ui.js"></script>
  <link rel="stylesheet" href="/resources/demos/style.css"/>
  <script>
      $(function () {
          $("#datepicker").datepicker({
              changeMonth: true,
              changeYear: true
          });
      });
  </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="div1" runat="server">
     <asp:DropDownList runat="server" ID="role"></asp:DropDownList>
        <br />
        <asp:Label runat="server" Text="First Name    "></asp:Label>
    <asp:TextBox runat="server" ID="fname" ></asp:TextBox>
        <br />

           <asp:Label runat="server" Text="Last Name    "></asp:Label>
    <asp:TextBox runat="server" ID="lname" ></asp:TextBox>
        <br />


        <p>Date: <input runat="server" type="text" id="datepicker"></p>



        

        <asp:DropDownList runat="server" ID="gender"></asp:DropDownList>
        <br />
        <br />
         <asp:Label runat="server" Text="User Name    "></asp:Label>
    <asp:TextBox runat="server" ID="username" ></asp:TextBox>
        <br />
        <br />

        <asp:Label runat="server" Text="Password    "></asp:Label>
    <asp:TextBox runat="server" ID="password" ></asp:TextBox>
        <br />
        <br />


        <asp:Button ID="Go" runat="server" Text="Sign up" OnClick="Go_Click" />

        <asp:Label runat="server" ID="lblInfo"></asp:Label>


        <br />
        <br />

             <asp:Label runat="server" Text="Address   "></asp:Label>
    <asp:TextBox runat="server" ID="address" ></asp:TextBox>
        <asp:Button runat="server" ID="h1" Text ="Add new" OnClick="h1_Click" ></asp:Button>
        <br />
        <br />

    </div>
    </form>
</body>
</html>
