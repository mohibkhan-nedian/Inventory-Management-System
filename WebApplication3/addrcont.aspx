<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addrcont.aspx.cs" Inherits="WebApplication3.staffaddr" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href ="css/bootstrap-theme.css" rel="stylesheet" />
    <title></title> 
</head>
<body>
    <customControls:Header ID="Header1" runat="server"></customControls:Header>
    <form id="form1" runat="server" class="form-horizontal">
    <div>
         <div class="form-group">  
       <asp:Label Text="Staff ID  " ID="Staffid" runat="server" CssClass="control-label col-sm-2"></asp:Label>
       <div class="col-sm-7">
               <asp:TextBox ID="id" runat="server" Enabled="false"  CssClass="form-control"></asp:TextBox>
        </div>
         </div>
        <br />
      <div class="form-group">        
           <asp:Label Text ="Username  " runat="server" CssClass="control-label col-sm-2">Username</asp:Label>

      
         <div class="col-sm-7">
                <asp:TextBox ID="una" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
         </div>
         </div>
          <br />
         <div class="form-group">    
          <asp:Label Text ="Roleid  " runat="server" CssClass="control-label col-sm-2">Roleid</asp:Label>
                <div class="col-sm-7">
                      <asp:TextBox ID="role" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
       </div>
                      </div>
          <br />
              <div class="form-group">    
      <asp:Label Text ="Fname  " runat="server" CssClass="control-label col-sm-2"></asp:Label>
        <div class="col-sm-7">
            <asp:TextBox ID="fname" runat="server" CssClass="form-control"></asp:TextBox>
              </div>
         </div>
        <br />
                   <div class="form-group">    
        <asp:Label Text ="Lname  " runat="server" CssClass="control-label col-sm-2"></asp:Label>
       <div class="col-sm-7">
            <asp:TextBox ID="lname" runat="server" CssClass="form-control"></asp:TextBox>
             </div>
         </div>
    
        <br />  
                        <div class="form-group">    
         <asp:Label Text ="DOB " runat="server" CssClass="control-label col-sm-2"></asp:Label>
        <div class="col-sm-7">
                            <asp:TextBox ID="dob" runat="server" CssClass="form-control"></asp:TextBox>
      </div>
         </div>
        <br />
         <div class="form-group">    
          <asp:Label Text ="Password  " runat="server" CssClass="control-label col-sm-2"></asp:Label>
       
             <div class="col-sm-7">
                  <asp:TextBox ID="password" runat="server" CssClass="form-control"></asp:TextBox>
      </div>
         </div>
      
        <br />
              <div class="form-group">    
        <asp:Label Text ="Addr1  " runat="server" CssClass="control-label col-sm-2"></asp:Label>
       
                  <div class="col-sm-7">
                       <asp:TextBox ID="adres1" runat="server" CssClass="form-control"></asp:TextBox>
          </div>
         </div>
                    
        <br /> 
                   <div class="form-group">    
        <asp:Label Text ="Addr2  " runat="server" CssClass="control-label col-sm-2"></asp:Label>
       <div class="col-sm-7">
                        <asp:TextBox ID="adres2" runat="server" CssClass="form-control"></asp:TextBox>
          </div>
         </div>
      
        <br />
                        <div class="form-group">    
        <asp:Label Text ="Addr3  " runat="server" CssClass="control-label col-sm-2"></asp:Label>
        
                            <div class="col-sm-7">
                                <asp:TextBox ID="adres3" runat="server" CssClass="form-control"></asp:TextBox>
          </div>
         </div>
                             
        <br />
      
                             <div class="form-group">    
           <asp:Label Text ="Contact1  " runat="server" CssClass="control-label col-sm-2"></asp:Label>
       <div class="col-sm-7">
            <asp:TextBox ID="c1" runat="server" CssClass="form-control"></asp:TextBox>
           </div>
         </div>
          
         <br />
                                  <div class="form-group">    
        <asp:Label Text ="Contact2  " runat="server" CssClass="control-label col-sm-2"></asp:Label>
        <div class="col-sm-7">
            <asp:TextBox ID="c2" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
         </div>
        <div class="form-group">
       
       
         </div>
            </div>
            <br />
   <div class="form-group">    
           <asp:Label Text ="Contact3  " runat="server" CssClass="control-label col-sm-2"></asp:Label>
       <div class="col-sm-7">
            <asp:TextBox ID="c3" runat="server" CssClass="form-control"></asp:TextBox>
          </div>
         </div>
          <div style="padding-left: 1100px">
       <asp:Button Text="Save" runat="server" OnClick="update" CssClass="btn btn-primary" />
       </div>
               <br />
     

        <div class="form-group">    
         <asp:Label Text="" ID="lblInfo" BorderColor="Yellow" runat="server" CssClass="control-label col-sm-2"></asp:Label>
            
       
    </div>
    </form>
</body>
</html>
