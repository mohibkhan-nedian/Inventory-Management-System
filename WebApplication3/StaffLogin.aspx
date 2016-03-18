<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffLogin.aspx.cs" Inherits="WebApplication3.StaffLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet">
<link href="css/bootstrap-theme.css" rel="stylesheet">
    <title></title>
</head>
<body>

     <customControls:Header ID="Header1" runat="server"></customControls:Header>
   <h1 class="h1">Login </h1> 
<form  role="form" class="form-horizontal" runat="server">
  <div class="form-group">
    <label runat="server" class="control-label col-sm-2" for="email">Username:</label>
    <div class="col-sm-7">
      <input type="email" runat="server" class="form-control" id="email" placeholder="Enter Username">
    </div>
  </div>
  
  <div class="form-group">
    <label runat="server" class="control-label col-sm-2" for="pwd">Password:</label>
    <div class="col-sm-7"> 
      <input runat="server" type="password" class="form-control" id="pwd" placeholder="Enter password">
    </div>
  </div>
  
  <div class="form-group"> 
    <div class="col-sm-offset-2 col-sm-10">
      <div class="checkbox">
        <label><input runat="server" type="checkbox"> Remember me</label>
      </div>
    </div>
  </div>
  
  <div class="form-group"> 
    <div class="col-sm-offset-2 col-sm-10">
      <button  runat="server" type="submit" class="btn btn-success" id="submitid" OnServerClick="submitid_click" >Login</button>
    </div>
  </div>
  <div class="create-account">
				<p class=" col-sm-offset-2 col-sm-9">
					Don't have an account yet ?&nbsp; 
					<a href="/StaffSignup.aspx" runat="server" id="register" >Create an account</a>
				</p>
			</div>
</form>

</body>
</html>
