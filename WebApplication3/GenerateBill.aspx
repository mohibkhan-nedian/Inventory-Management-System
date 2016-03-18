<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerateBill.aspx.cs" Inherits="WebApplication3.GenerateBill" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link href="css/style3.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript">
         function doPostBack(o) {
             __doPostBack(o.id, '');
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
         <customControls:Header2 ID="Header1" runat="server"></customControls:Header2>
    <div>
            
        <div class="content">
            <h1>Inventory Management System</h1>



            <asp:Label runat="server" ID="lbl1" Text="Amount Debit: "></asp:Label>
            <asp:Label runat="server" ID="Label1" Text=""></asp:Label>

            <br />
            <br />

            
            <asp:Label runat="server" ID="Label2" Text="Amount Credit: "></asp:Label>
            <asp:Label runat="server" ID="Label3" Text=""></asp:Label>

            <br />
            <br />

             
            <asp:Label runat="server" ID="Label4" Text="Total Balance Received: "></asp:Label>
            <asp:Label runat="server" ID="Label5" Text=""></asp:Label>

            <br />
            <br />
            
        </div>

    </div>
        <div>        &nbsp;&nbsp;
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button runat="server" Text="Print Bill"  OnClick="Unnamed_Click" ID="Button1" Width="77px" />
                                
             <asp:Button runat="server" Text="Go Back"  OnClick="Unnamed_Click" ID="Button2" />

        </div>




  
    </form>
</body>
</html>
