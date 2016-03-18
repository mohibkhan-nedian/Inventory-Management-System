<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newCustomerRequest.aspx.cs" Inherits="WebApplication3.newCustomerRequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
         <link href="css/style1.css" rel="stylesheet" type="text/css" />
         <link href="css/bootstrap.min.css" rel="stylesheet">
<link href="css/bootstrap-theme.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <customControls:Header2 ID="Header1" runat="server"></customControls:Header2>
        <div class="container">
         <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" >
                            <ItemTemplate>
                            
                                 <div class="container1">
                              <asp:Label CssClass="control-label" runat="server" Text="First Name: "></asp:Label> 
                                        <asp:label CssClass="control-label" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"fname")%>' ></asp:label>
                                   <br />
                                    
                               <asp:Label runat="server" CssClass="control-label" Text="Last Name: "></asp:Label> 
                                      <asp:label runat="server" CssClass="control-label" Text='<%# DataBinder.Eval(Container.DataItem,"lname")%>' ></asp:label>
                                  <br />

                                
                                   <asp:Button CssClass="btn-default" runat="server" Text="Register Customer" CommandName ="btn" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"custid") %>' UseSubmitBehavior="false" CausesValidation="false" />
                                </div>
                        
                              
                            </ItemTemplate>
                        </asp:Repeater>
            </div>
        <asp:Label runat="server" ID="lblInfo"></asp:Label>
    </div>
    </form>
</body>
</html>
