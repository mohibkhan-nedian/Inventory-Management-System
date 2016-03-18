<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCustomers.aspx.cs" Inherits="WebApplication3.ViewCustomers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="css/bootstrap.min.css" rel="stylesheet">
<link href="css/bootstrap-theme.css" rel="stylesheet">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="Scriptmanager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            
            <ContentTemplate>
                 <customControls:Header2 ID="Header1" runat="server"></customControls:Header2>
    <div>
        <table class="table">
            <tr>
                <td>First Name </td>
                <td>Last Name  </td>
                <td>Regno      </td>
                <td>           </td
           
            </tr>
        
         <asp:Repeater ID="Repeater1" runat="server"  OnItemCommand="Repeater1_ItemCommand" >
                            
             <ItemTemplate>
                     
                         <tr>
                             <td>
                                        <asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Fname")%>' ></asp:label>
                                 </td>  
                                   <td> <asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Lname")%>' ></asp:label>
                                   </td>
                                    <td><asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Regno")%>' ></asp:label>
                                   </td>
                                       <td> <asp:Button runat="server" Text="View Profile" CommandName ="btn" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CID") %>' UseSubmitBehavior="false" CausesValidation="false" />
                                <asp:Button runat="server" Text="Delete" CommandName ="btn2" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CID") %>' UseSubmitBehavior="false" CausesValidation="false" />
                         </td>
                    </tr>                                
                            </ItemTemplate>
                        </asp:Repeater>

    </table>
    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
    </form>
</body>
</html>
