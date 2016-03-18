<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header5.ascx.cs" Inherits="WebApplication3.Controls.header5" %>

<link href="css/bootstrap.min.css" rel="stylesheet">
<link href="css/bootstrap-theme.css" rel="stylesheet">

<nav class="navbar navbar-inverse">
  <div class="container-fluid">
    <div class="navbar-header">
      <a class="navbar-brand" href="#">Track Inventory</a>
    </div>
    <div>
      <ul class="nav navbar-nav">
        <li><a href="/ViewStaff.aspx">View Staff</a></li>
        <li><a href="/Show Sales.aspx">Show Sales</a></li>
        <li><a href="/chart.aspx">Compare Sales</a></li> 
         
      </ul>
      <ul class="nav navbar-nav navbar-right">
       <li><a href="/addrcont.aspx"><span class="glyphicon glyphicon-edit"></span>Edit Profile</a></li>
        <li><a href="/StaffLogin.aspx"><span class="glyphicon glyphicon-log-in"></span>Logout</a></li>
      </ul>
    </div>
  </div>
</nav>
