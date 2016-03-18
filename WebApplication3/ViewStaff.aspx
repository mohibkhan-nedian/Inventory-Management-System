<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewStaff.aspx.cs" Inherits="WebApplication3.ViewStaff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <link href="css/bootstrap.min.css" rel="stylesheet">
<link href="css/bootstrap-theme.css" rel="stylesheet">
    <title></title>
 

</head>
<body>
    <form id="form2" runat="server">
      <customControls:Header5 ID="Header1" runat="server"></customControls:Header5>
        <div>
        <table class="table">
           <tr>
    <td>Staff Id</td>
    <td>First Name</td>
    <td>Last  Name</td>
    <td>          </td>
    <td></td>
    </tr>
     
        <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_command" >
            <ItemTemplate>
             <%--    <asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"StaffID")%>' ></asp:label>
                 <asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Fname") %>'></asp:label> 
                 <asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Lname") %>'></asp:label> 
                <asp:Button runat="server" Text="View Profile"   CommandName ="btn" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"StaffID") %>' UseSubmitBehavior="false" CausesValidation="false" />
                 <asp:Button runat="server" Text="Delete" CommandName ="btn" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"StaffID") %>' UseSubmitBehavior="false" CausesValidation="false" /> 

                <br />--%>

                  <tr>
      <td>   <asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"StaffID")%>' ></asp:label>
              </td>
      <td> <asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Fname") %>'></asp:label> 
                 </td>
      <td> <asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Lname") %>'></asp:label> 
                </td>
      <td><div class="btn-group">
  		                <asp:Button runat="server" Text="View Profile" CssClass="btn btn-primary"   CommandName ="btn" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"StaffID") %>' UseSubmitBehavior="false" CausesValidation="false" />
                 
		 <asp:Button runat="server" Text="Delete" CssClass="btn btn-primary" CommandName ="btn1" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"StaffID") %>' UseSubmitBehavior="false" CausesValidation="false" /> 

        </div> 
      </td>
      
    
</tr>
   
                
            </ItemTemplate>
        </asp:Repeater>
</table>

    
    </div>
    </form>
</body>
</html>
