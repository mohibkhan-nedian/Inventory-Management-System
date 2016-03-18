<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show Sales.aspx.cs" Inherits="WebApplication3.Show_Sales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <link href="css/bootstrap.min.css" rel="stylesheet">
<link href="css/bootstrap-theme.css" rel="stylesheet">
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

          $("#datepicker1").datepicker({
              changeMonth: true,
              changeYear: true
          });
      });
  </script>
</head>
<body>
    <form role="form" runat="server" class="gl">
     <customControls:Header5 ID="Header1" runat="server"></customControls:Header5>
        <div>
    
          <div class="form-group">
    <label class="control-label col-sm-2" for="email">From:</label>
    <div class="col-sm-7">
      <input type="date" class="form-control" runat="server" id="datepicker" placeholder="Enter Date">
    </div>
  </div>
        <br />
        <div class="form-group">
    <label class="control-label col-sm-2" for="email">To:</label>
    <div class="col-sm-7">
      <input type="date" class="form-control" runat="server" id="datepicker1" placeholder="Enter Date">
    </div>
  </div>
        <br />


            <asp:button runat="server" CssClass="btn-primary" Text ="Show" OnClick="Unnamed_Click" ></asp:button>


            
        		<div class="form-group">
    <label class="control-label col-sm-2" for="email">Total Balance Received:</label>
    <div class="col-sm-7">
      <asp:Label runat="server" CssClass="control-label" ID="bal1"></asp:Label>
    </div>
  </div>
        <br />
          		<div class="form-group">
    <label class="control-label col-sm-2" for="email">Expected Profit:</label>
    <div class="col-sm-7">
      <asp:label CssClass="control-label" runat="server" id="profit1" ></asp:label>
    </div>
  </div>
        <br />
           		<div class="form-group">
    <label class="control-label col-sm-2" for="email">Actual Profit:</label>
    <div class="col-sm-7">
      <asp:label CssClass="control-label" runat="server" id="profit2" ></asp:label>
    </div>
  </div>
         
    </div>
    </form>
</body>
</html>
